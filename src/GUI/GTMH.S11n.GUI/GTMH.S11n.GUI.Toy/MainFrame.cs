using GTMH.S11n.Reflection;

using System.ComponentModel;
using System.Reflection;

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

  private void setObjectTypeToolStripMenuItem_Click(object sender, EventArgs ea)
  {
    var dlg = new OpenFileDialog();
    dlg.Filter = ".Net Assembly|*.dll";
    using(var ll = dlg.LastLocation("setObjectType"))
    {
      if(dlg.ShowDialog(this) != DialogResult.OK)
        return;
      ll.Commit();
    }

    string[] ible;
    try
    {
      ible = Instantiable.Find(dlg.FileName, null).ToArray();
    }
    catch(Exception e)
    {
      this.ShowErrorDialog($"Error: {e.Message}");
      return;
    }
    if(!ible.Any())
    {
      this.ShowInfoDialog("The selected assembly contained no instantiable types");
      return;
    }

    var clsDlg = new ClassDialog(ible);
    if(clsDlg.ShowDialog(this) != DialogResult.OK)
      return;

    m_View.SetObject(dlg.FileName, clsDlg.SelectedItem);
  }

  private void printConfigToolStripMenuItem_Click(object sender, EventArgs e)
  {
    var dlg = new PrintConfigDialog(m_View.GetDictionaryConfig());
    dlg.ShowDialog(this);
  }
}
