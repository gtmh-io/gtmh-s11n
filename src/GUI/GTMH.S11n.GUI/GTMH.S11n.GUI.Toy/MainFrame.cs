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
    dlg.Filter = ".Net Assembly|*.exe;*.dll";
    using(var ll = dlg.LastLocation("setObjectType"))
    {
      if ( dlg.ShowDialog(this) != DialogResult.OK )  return;
      ll.Commit();
    }

    Assembly ass;
    try
    {
      ass = System.Reflection.Assembly.LoadFrom(dlg.FileName);
    }
    catch(Exception e)
    {
      this.ShowErrorDialog($"Error: {e.Message}");
      return;
    }
    var ic =new InstantiableControl(ass, null);
    if(!ic.Any())
    {
      this.ShowInfoDialog("The selected assembly contained no instantiable types");
      return;
    }
  }
  //public static IEnumerable<string> FindInstantiable(
}
