using System.ComponentModel;

namespace GTMH.S11n.GUI.Toy;

public partial class MainFrame : Form
{
  public MainFrame()
  {
    InitializeComponent();
  }

  protected override void OnLoad(EventArgs e)
  {
    base.OnLoad(e);
    this.LoadWindowState();
  }

  protected override void OnFormClosing(FormClosingEventArgs e)
  {
    this.SaveWindowState();
    base.OnFormClosing(e);
  }

  private void setObjectTypeToolStripMenuItem_Click(object sender, EventArgs e)
  {
    var dlg = new OpenFileDialog();
    dlg.Filter = ".Net Assembly|*.exe;*.dll";
    using(var ll = dlg.LastLocation("setObjectType"))
    {
      if ( dlg.ShowDialog(this) != DialogResult.OK )  return;
      ll.Commit();
    }
  }
}
