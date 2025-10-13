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

  private void saveToolStripMenuItem_Click(object sender, EventArgs e)
  {
    var dlg = new SaveFileDialog();
    dlg.Filter = "Text File|*.txt|All Files|*.*";
    using(var ll = dlg.LastLocation("saveLoadLoc"))
    {
      if(dlg.ShowDialog(this) != DialogResult.OK)
        return;
      ll.Commit();
    }
    try
    {
      using(var stream = new StreamWriter(new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write, FileShare.None)))
      {
        foreach(var kvp in m_View.GetDictionaryConfig())
        {
          stream.WriteLine($"{kvp.Key}={kvp.Value}");
        }
      }

    }
    catch(Exception ex)
    {
      this.ShowErrorDialog($"Error: {ex.Message}");
      return;
    }

  }

  private void loadToolStripMenuItem_Click(object sender, EventArgs e)
  {
    var dlg = new OpenFileDialog();
    dlg.Filter = "Text File|*.txt|All Files|*.*";
    using(var ll = dlg.LastLocation("saveLoadLoc"))
    {
      if(dlg.ShowDialog(this) != DialogResult.OK)
        return;
      ll.Commit();
    }
    try
    {
      using(var stream = new StreamReader(new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read, FileShare.Read)))
      {
        var dict = new Dictionary<string, string>();
        string? line;
        while((line = stream.ReadLine()) != null)
        {
          var eq = line.IndexOf('=');
          if(eq < 0)
            continue;
          var key = line.Substring(0, eq).Trim();
          var val = line.Substring(eq + 1).Trim();
          dict[key] = val;
        }
        m_View.SetDictionaryConfig(dict);
      }
    }
    catch(Exception ex)
    {
      this.ShowErrorDialog($"Error: {ex.Message}");
      return;
    }
  }

  private void instantiateToolStripMenuItem_Click(object sender, EventArgs ea)
  {
    if ( m_View.ClassName == null || m_View.Assembly==null)
    {
      this.ShowInfoDialog("No type selected");
      return;
    }
    var s11n = m_View.GetDictionaryConfig();
    try
    {
      // in normal use we'd have the concrete type of the class
      // but here we don't so look for constructor via reflection
      var ass = Assembly.LoadFrom(m_View.Assembly);
      var ty = ass.GetTypes().Where(_=>_.FullName==m_View.ClassName).Single();
      var c = ty.GetConstructors(System.Reflection.BindingFlags.Public|System.Reflection.BindingFlags.Instance).Where(_=>Instantiable.IsConstructible(_)).Single();

      var args = new DictionaryConfig(s11n).ForInit(m_View.LoadContext); 
      c.Invoke(new[] { args } );

      this.ShowInfoDialog($"Instantiated {m_View.ClassName} from assembly {m_View.Assembly}");
    }
    catch(Exception e)
    {
      this.ShowErrorDialog($"Error: {e.Message}");
      return;
    }
  }
}
