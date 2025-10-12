using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GTMH.S11n.GUI.Toy
{
  public partial class ClassDialog : Form
  {
    public ClassDialog()
    {
      InitializeComponent();
    }
    public ClassDialog(IEnumerable<string> a_Items)
    {
      InitializeComponent();
      foreach(var item in a_Items.OrderBy(_=>_)) m_Classes.Items.Add(item);
    }
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      if(m_Classes.SelectedItem == null && this.DialogResult!=DialogResult.Cancel)
      {
        e.Cancel = true;
        return;
      }
      base.OnFormClosing(e);
    }
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603 // Possible null reference return.
    public string SelectedItem => (string)m_Classes.SelectedItem; // shouldn't be calling this if cxl
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
  }
}
