using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n.GUI.Node;
public class ListNode : TreeNode
{
  public readonly string Context;
  public Type InterfaceType { get; }
  public Widget Control { get; }

  public ListNode(string a_Name, Type a_Type, bool a_Required, Widget control, string a_ParentContext)
  {
    this.Text = a_Name;
    this.ToolTipText = "Right click to add/remove instances";
    Context = a_ParentContext == "" ? a_Name : $"{a_ParentContext}.{a_Name}";
    InterfaceType = a_Type;
    Control =control;
  }

  internal void AppendNodeConfig(Dictionary<string, string> rval)
  {
    rval.Add($"{Context}.Array-Length", this.Nodes.Count.ToString());
  }
}
