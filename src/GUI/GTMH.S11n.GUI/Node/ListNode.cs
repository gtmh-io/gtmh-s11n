using System;
using System.Collections.Generic;
using System.Text;

namespace GTMH.S11n.GUI.Node;
public class ListNode : TreeNode
{
  public ListNode(string a_Name, string a_Type, bool a_Required, Widget control, string a_ParentContext)
  {
    this.Text = a_Name;
    this.ToolTipText = "Right click to add/remove instances";
  }
}
