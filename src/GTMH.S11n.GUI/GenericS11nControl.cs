using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GTMH.S11n.GUI
{
  public partial class GenericS11nControl : UserControl
  {
    private readonly TreeNode RootNode;

    public GenericS11nControl()
    {
      InitializeComponent();
      this.RootNode = m_TreeView.Nodes[0];
    }

    private void SetView(Control a_Control)
    {
      m_SplitContainer.Panel2.Controls.Clear();
      a_Control.Dock = DockStyle.Fill;
      m_SplitContainer.Panel2.Controls.Add(a_Control);
    }
  }
}
