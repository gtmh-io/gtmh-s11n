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
    private readonly InstanceNode RootNode;

    public Widget()
    {
      InitializeComponent();
      this.RootNode = new InstanceNode( "Root" );
      this.m_TreeView.Nodes.Add(this.RootNode);
      this.m_TreeView.AfterSelect += OnNodeSelect;
    }

    private void OnNodeSelect(Object? sender, TreeViewEventArgs e)
    {
      m_SplitContainer.Panel2.Controls.Clear();
      if ( e.Node is InstanceNode @in )
      {
        var c = new InstanceView(@in, this);
        c.Dock = DockStyle.Fill;
        this.m_SplitContainer.Panel2.Controls.Add(c);
        if(@in == this.RootNode)
        {
          c.m_AssemblyPanel.Enabled = false;
        }
      }
      else if ( e.Node is ListNode ln )
      {
        var c = new GTMH.S11n.GUI.View.ListView(ln, this);
        c.Dock = DockStyle.Fill;
        this.m_SplitContainer.Panel2.Controls.Add(c);
      }
    }

    public void SetObject(string a_Assembly, string a_Class)
    {
      this.Clear();
      RootNode.Text=a_Class.Split('.').Last();
      RootNode.ToolTipText = a_Class;
      var pop = new Populator(this, RootNode);
      try
      {
        Instantiable.Visit(a_Assembly, a_Class, pop);
        m_TreeView.SelectedNode = RootNode;
      }
      catch(Exception e)
      {
        this.ShowErrorDialog($"Error: {e.Message}");
        this.Clear();
        return;
      }
    }

    private void Clear()
    {
      m_SplitContainer.Panel2.Controls.Clear();
      RootNode.Clear();
    }

    class Populator (Widget a_Control, InstanceNode a_Parent) : GTMH.S11n.IS11nVisitor
    {
      public Widget Control { get; } = a_Control;
      public InstanceNode Parent { get; } = a_Parent;

      public void Visit(string a_Name, string a_Type, bool a_Required)
      {
        var node = new InstanceNode(a_Name, a_Type, this.Control, Parent.Context);
        Parent.Nodes.Add(node);
      }

      public void VisitList(string a_Name, string a_Type, bool a_Required)
      {
        var node = new ListNode(a_Name, a_Type, a_Required, this.Control, Parent.Context);
        Parent.Nodes.Add(node);
      }

      public void VisitPOD(string a_Name)
      {
        Parent.AddArgument(a_Name);
      }

      public void VisitPOD(string a_Name, string a_DefaultValue)
      {
        Parent.AddArgument(a_Name, a_DefaultValue);
      }
    }
  }
}
