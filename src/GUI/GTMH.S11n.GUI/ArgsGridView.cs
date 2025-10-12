using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GTMH.S11n.GUI
{
  public partial class ArgsGridView : UserControl
  {
    class ArgRecord
    {
      public string Arg { get; }
      public string ? Value { get; set; }
      [Browsable(false)] // not visible
      public string? Default { get; set; }
      public ArgRecord(string a_Name)
      {
        Arg = a_Name;
      }
    }
    BindingList<ArgRecord> m_GridData = new();
    public ArgsGridView()
    {
      InitializeComponent();
      m_Grid.DataSource = m_GridData;
    }

    public void Add(string a_Name, string ? a_Value)
    {
      m_GridData.Add(new ArgRecord(a_Name));
    }

    public void Add(string a_Name, string ? a_Value, string a_DefaultValue)
    {
      var rec = new ArgRecord(a_Name);
      rec.Default = a_DefaultValue;
      m_GridData.Add(rec);
    }

    internal void Clear()
    {
      m_GridData.Clear();
    }
  }
}
