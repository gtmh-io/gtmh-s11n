using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GTMH.S11n.GUI.Node;
using GTMH.S11n.Reflection;

namespace GTMH.S11n.GUI
{
  public partial class Widget : UserControl
  {
    private InstanceNode RootNode { get; set; }

    public string? Assembly { get; private set; } = null;
    public string ? ClassName { get; private set; } = null;

    public LoadContext LoadContext { get; private set;} = new LoadContext();

    Font m_FontUnconfigured;
    Font m_FontConfigured;
    public Widget()
    {
      InitializeComponent();
      this.RootNode = new InstanceNode( "Root", this );
      this.m_TreeView.Nodes.Add(this.RootNode);
      this.m_TreeView.AfterSelect += OnNodeSelect;

      m_FontConfigured = this.RootNode.NodeFont ?? m_TreeView.Font;
      m_FontUnconfigured = new Font(m_FontConfigured, FontStyle.Bold);
    }

    private void OnNodeSelect(Object? sender, TreeViewEventArgs ea)
    {
      m_SplitContainer.Panel2.Controls.Clear();
      try
      {
        if(ea.Node is InstanceNode @in)
        {
          var c = new InstanceView(@in, this);
          c.Dock = DockStyle.Fill;
          this.m_SplitContainer.Panel2.Controls.Add(c);
          if(@in == this.RootNode)
          {
            c.m_AssemblyPanel.Enabled = false;
          }
        }
        else if(ea.Node is ListNode ln)
        {
          var c = new GTMH.S11n.GUI.View.ListView(ln, this);
          c.Dock = DockStyle.Fill;
          this.m_SplitContainer.Panel2.Controls.Add(c);
        }
      }
      catch(Exception e)
      {
        var c = new GTMH.S11n.GUI.View.ErrorView();
        c.m_ErrorText.Text = e.ToString();
        c.Dock = DockStyle.Fill;
        this.m_SplitContainer.Panel2.Controls.Add(c);
      }
    }

    public void ShowError(Exception e)
    {
      this.ShowErrorDialog($"Error: {e.Message}");
      m_SplitContainer.Panel2.Controls.Clear();
      var c = new GTMH.S11n.GUI.View.ErrorView();
      c.m_ErrorText.Text = e.ToString();
      c.Dock = DockStyle.Fill;
      this.m_SplitContainer.Panel2.Controls.Add(c);
    }


    private void Clear()
    {
      m_SplitContainer.Panel2.Controls.Clear();
      RootNode.Clear();
    }

    public void SetDirty()
    {
      // TODO - callback or event
      this.UpdateVisualCues();
    }

    private void UpdateVisualCues()
    {
      Action<TreeNode,bool> setConfigComplete = (node, configured)=>
      {
        node.NodeFont = configured ? m_FontConfigured : m_FontUnconfigured;
      };
      // gather all unconfigured nodes
      List<TreeNode> unconfiguredNodes = new();
      // need only check the instance nodes
      Action<TreeNode> gatherUnconfigured = _=> { };
      gatherUnconfigured = n =>
      {
        setConfigComplete(n, true);
        if(n is InstanceNode @in)
        {
          if(!@in.IsConfigComplete()) unconfiguredNodes.Add(n);
        }
        foreach(TreeNode ch in n.Nodes) gatherUnconfigured(ch);
      };
      gatherUnconfigured(RootNode);

      Action<TreeNode> setConfigBranchIncomplete = n=> { };
      setConfigBranchIncomplete = n=>
      {
        setConfigComplete(n, false);
        if( n.Parent != null) setConfigBranchIncomplete(n.Parent);
      };
      foreach(var n in unconfiguredNodes)
      {
        setConfigBranchIncomplete(n);
      }
    }

    /// <summary>
    /// Replace the given node in the tree with the provided one
    /// </summary>
    internal void UpdateNode(InstanceNode a_Node, InstanceNode a_WithValue) =>this.UpdateNodeImpl(a_Node, a_WithValue, true);
    private void UpdateNodeImpl(InstanceNode m_Node, InstanceNode a_WithValue, bool a_WithDirty)
    {
      var parent = m_Node.Parent;
      if(parent == null)
      {
        // replacing the root node
        m_TreeView.Nodes.Clear();
        this.RootNode = a_WithValue;
        m_TreeView.Nodes.Add(this.RootNode);
      }
      else
      {
        var idx = parent.Nodes.IndexOf(m_Node);
        parent.Nodes.RemoveAt(idx);
        parent.Nodes.Insert(idx, a_WithValue);
      }
      m_TreeView.SelectedNode = a_WithValue;
      if ( a_WithDirty) this.SetDirty();
      else this.UpdateVisualCues();
    }

    public Dictionary<string,string> GetDictionaryConfig()
    {
      Dictionary<string,string> rval = new();
      Action<TreeNode> appendConfig = n=> { };
      appendConfig = n=>
      {
        if ( n is InstanceNode @in )
        {
          @in.AppendNodeConfig(rval);
        }
        else if ( n is ListNode ln )
        {
          ln.AppendNodeConfig(rval);
        }
        foreach(TreeNode ch in n.Nodes)
        {
          appendConfig(ch);
        }
      };
      appendConfig(RootNode);

      return rval;
    }

    public void SetObject(string a_Assembly, string a_Class)
    {
      this.Clear();
      RootNode.Text=a_Class.Split('.').Last();
      RootNode.ToolTipText = a_Class;
      var pop = new StructurePopulator(this, RootNode);
      try
      {
        Instantiable.Visit(a_Assembly, a_Class, pop);
        m_TreeView.SelectedNode = RootNode;
        this.Assembly = a_Assembly;
        this.ClassName = a_Class;
        LoadContext = new LoadContext( a_Assembly);
      }
      catch(Exception e)
      {
        this.ShowErrorDialog($"Error: {e.Message}");
        this.Clear();
        return;
      }
      this.SetDirty();
    }

    public class StructurePopulator (Widget a_Control, InstanceNode a_Parent) : GTMH.S11n.IS11nVisitor
    {
      public Widget Control { get; } = a_Control;
      public InstanceNode Parent { get; } = a_Parent;

      public virtual void Visit(string a_Name, Type a_Type, bool a_Required)
      {
        var node = new InstanceNode(a_Name, a_Type, this.Control, Parent.Context);
        Parent.Nodes.Add(node);
      }

      public virtual void VisitList(string a_Name, Type a_Type, bool a_Required)
      {
        var node = new ListNode(a_Name, a_Type, a_Required, this.Control, Parent.Context);
        Parent.Nodes.Add(node);
      }

      public virtual void VisitPOD(string a_Name)
      {
        Parent.AddArgument(a_Name);
      }

      public virtual void VisitPOD(string a_Name, string a_DefaultValue)
      {
        Parent.AddArgument(a_Name, a_DefaultValue);
      }
    }

    public void SetDictionaryConfig(Dictionary<string, string> a_Config)
    {
      if ( Assembly == null || ClassName == null )
      {
        throw new InvalidOperationException("Widget not configured with an object");
      }
      // have a clean temlate to work with
      RootNode.Nodes.Clear();
      var pop = new ContentPopulator(this, RootNode, a_Config);
      try
      {
        Instantiable.Visit(Assembly, ClassName, pop);
        m_TreeView.SelectedNode = RootNode;
        this.UpdateVisualCues();
      }
      catch(Exception e)
      {
        this.ShowErrorDialog($"Error: {e.Message}");
        this.Clear();
        return;
      }
    }

    class ContentPopulator(Widget a_Control, InstanceNode a_Parent, Dictionary<string, string> a_Content) : StructurePopulator(a_Control, a_Parent)
    {
      (string, string) parseAssembly(string value)
      {
        var idx = value.IndexOf(',');
        if ( base.Control.Assembly==null) throw new InvalidOperationException("Widget not configured with an assembly");
        if ( idx < 0 ) return (value, base.Control.Assembly);
        else return (value.Substring(0, idx).Trim(), value.Substring(idx+1).Trim());
      }
      private readonly Dictionary<string, string> Config = a_Content;
      string KeyFor(string a_Name) => Parent.Context == "" ? a_Name : $"{Parent.Context}.{a_Name}";
      public override void Visit(string a_Name, Type a_Type, bool a_Required)
      {
        base.Visit(a_Name, a_Type, a_Required);
        if ( Config.TryGetValue( KeyFor(a_Name), out var instanceConfig ) )
        {
          // it will be the last node added
          var (cls, assembly) = parseAssembly(instanceConfig);
          var originalNode=(InstanceNode)Parent.Nodes[Parent.Nodes.Count - 1];
          var node = originalNode.Copy(assembly, cls);
          Control.UpdateNodeImpl(originalNode, node, false);
          var pop = new ContentPopulator(Control, node, Config);
          Instantiable.Visit(assembly, cls, pop);
        }
      }
      public override void VisitList(string a_Name, Type a_Type, bool a_Required)
      {
        base.VisitList(a_Name, a_Type, a_Required);
        var arrayLenKey = $"{KeyFor(a_Name)}.Array-Length";
        if(Config.TryGetValue(arrayLenKey, out var strVar)&&int.TryParse(strVar, out var arrayLen)&&arrayLen>0)
        {
          var listNode = (ListNode)Parent.Nodes[Parent.Nodes.Count - 1];
          listNode.SetLength(arrayLen);
          for(var idx = 0; idx != arrayLen; ++idx)
          {
            // close to of cut and paste regrettably expedient here
            var keyIC = $"{KeyFor($"{a_Name}.{idx}")}";
            if(Config.TryGetValue(keyIC, out var instanceConfig))
            {
              var (cls, assembly) = parseAssembly(instanceConfig);
              var originalNode=(InstanceNode)listNode.Nodes[idx];
              var node = originalNode.Copy(assembly, cls);
              Control.UpdateNodeImpl(originalNode, node, false);
              var pop = new ContentPopulator(Control, node, Config);
              Instantiable.Visit(assembly, cls, pop);
            }
          }
        }
      }
      public override void VisitPOD(string a_Name)
      {
        base.VisitPOD(a_Name);
        if(Config.TryGetValue(KeyFor(a_Name), out var value))
        {
          Parent.SetArgValue(a_Name, value);
        }
      }
      public override void VisitPOD(string a_Name, string a_DefaultValue)
      {
        base.VisitPOD(a_Name, a_DefaultValue);
        if(Config.TryGetValue(KeyFor(a_Name), out var value))
        {
          Parent.SetArgValue(a_Name, value);
        }
      }
    }
  }
}
