using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n.GUI.Node
{
  public class InstanceNode : System.Windows.Forms.TreeNode
  {
    public string Context { get; init; }
    public string Assembly { get; }
    public string Type { get; }

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
    public InstanceNode(string a_Name)
    {
      this.Text=a_Name;
      Context = "";
      Assembly = "";
      Type = "";
    }
    public InstanceNode(string a_Name, string a_Type, Widget a_Control, string a_ParentContext)
    {
      this.Text = a_Name;
      var split = a_Type.Split(',');
      if(split.Length > 1)
      {
        Assembly=split[0];
        Type = split[1];
      }
      else
      {
        Assembly = "";
        Type=a_Type;
      }
      Context = a_ParentContext == "" ? a_Name : $"{a_ParentContext}.{a_Name}";
    }

    public void Clear()
    {
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
  }
}
