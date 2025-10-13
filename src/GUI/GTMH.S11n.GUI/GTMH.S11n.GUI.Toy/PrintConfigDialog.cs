using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GTMH.S11n.GUI.Toy
{
  public partial class PrintConfigDialog : Form
  {
    public PrintConfigDialog()
    {
      InitializeComponent();
    }
    public PrintConfigDialog(Dictionary<string, string> a_Config)
    {
      InitializeComponent();
      var content = new StringBuilder();
      content.AppendLine("var cfg = new DictionaryConfig()");
      content.AppendLine("{");
      foreach(var kvp in a_Config)
      {
        content.AppendLine($"\t{{ \"{kvp.Key}\", \"{kvp.Value}\" }},");
      }
      content.AppendLine("];");

      m_Content.Text =content.ToString();
    }
  }
}
