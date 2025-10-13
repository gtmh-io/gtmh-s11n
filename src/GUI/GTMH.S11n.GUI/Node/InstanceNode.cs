using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Text;
using System.Web;

namespace GTMH.S11n.GUI.Node
{
  public class InstanceNode : System.Windows.Forms.TreeNode
  {
    public string Context { get; private set; }
    public Type? InterfaceType { get; }
    public string Assembly { get; set; } = "";
    public string ClassName { get; set; } = "";
    Widget m_Control;

    public class ArgData
    {
      public string? DefaultValue { get; init; }
      public string? Value { get; set; }
    }
    private Dictionary<string, ArgData> m_Arguments = new Dictionary<string, ArgData>();
    public IEnumerable<KeyValuePair<string, ArgData>> POD => m_Arguments;

    /// <summary>
    /// Root node
    /// </summary>
    public InstanceNode(string a_Name, Widget a_Control)
    {
      if ( string.IsNullOrEmpty(a_Name) ) throw new ArgumentException("a_Name must not be empty");
      this.Text=a_Name;
      Context = "";
      InterfaceType = null;
      m_Control = a_Control;
    }

    public InstanceNode(string a_Name, Type a_Type, Widget a_Control, string a_ParentContext)
    {
      if ( string.IsNullOrEmpty(a_Name) ) throw new ArgumentException("a_Name must not be empty");
      this.Text = a_Name;
      InterfaceType = a_Type;
      Context = a_ParentContext == "" ? a_Name : $"{a_ParentContext}.{a_Name}";
      m_Control = a_Control;
    }

    public void ResetName(string a_Name)
    {
      var components = Context.Split('.').Reverse().Skip(1).Reverse();
      this.Text = a_Name;
      this.Context = string.Join('.', components.Append(a_Name));
    }

    private InstanceNode(string a_Name, Type? a_Type, Widget a_Control, string a_Context, string a_Assembly, string a_ClassName)
    {
      this.Text = a_Name;
      InterfaceType = a_Type;
      Context = a_Context;
      Assembly = a_Assembly;
      ClassName = a_ClassName;
      m_Control = a_Control;
    }

    public InstanceNode Copy(string a_Assembly, string a_ClassName)
    {
      if ( InterfaceType==null ) return new InstanceNode(this.Text, m_Control) { Assembly = a_Assembly, ClassName = a_ClassName };
      else return new InstanceNode (this.Text, this.InterfaceType, m_Control, this.Context, a_Assembly, a_ClassName );
    }

    public void Clear()
    {
      this.Assembly = "";
      this.ClassName = "";
      this.Nodes.Clear();
      m_Arguments.Clear();
    }

    internal void AddArgument(string a_Name)
    {
      m_Arguments.Add(a_Name, new ArgData() { DefaultValue = null, Value = null });
    }

    internal void AddArgument(string a_Name, string a_DefaultValue)
    {
      m_Arguments.Add(a_Name, new ArgData() { DefaultValue = a_DefaultValue, Value = null });
    }

    public void SetArgValue(string a_ArgName, string? a_Value)
    {
      if ( m_Arguments.TryGetValue(a_ArgName, out var arg) )
      {
        arg.Value = a_Value;
      }
    }

    internal void AppendNodeConfig(Dictionary<string, string> rval)
    {
      if ( Assembly != "" && ClassName != "" )
      {
        rval.Add($"{Context}", ClassName);
      }
      foreach(var arg in m_Arguments)
      {
        if(arg.Value.Value != null)
        {
          rval.Add($"{Context}.{arg.Key}", arg.Value.Value);
        }
      }
    }
  }
}
