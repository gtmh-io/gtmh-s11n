using GTMH.S11n.GUI.Node;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GTMH.S11n.GUI.View
{
  public partial class ListView : UserControl
  {
    public ListView()
    {
      InitializeComponent();
    }

    public ListView(ListNode ln, Widget widget)
    {
      InitializeComponent();
    }
  }
}
