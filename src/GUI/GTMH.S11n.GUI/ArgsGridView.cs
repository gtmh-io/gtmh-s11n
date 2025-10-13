using GTMH.S11n.GUI.Node;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GTMH.S11n.GUI;
public partial class ArgsGridView : UserControl
{
  InstanceNode ? m_ViewData;
  class ArgRecord
  {
    public string Arg { get; }
    public string? Value { get; set; }
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
    m_Grid.CellEndEdit += OnCellEndEdit;
  }

  private void OnCellEndEdit(object? sender, DataGridViewCellEventArgs e)
  {
    if ( m_ViewData == null ) return;
    var row = m_GridData[e.RowIndex];
    m_ViewData.SetArgValue(row.Arg, row.Value);
  }

  public void Add(string a_Name, string? a_Value)
  {
    var ar = new ArgRecord(a_Name);
    ar.Value = a_Value;
    m_GridData.Add(ar);
  }

  public void Add(string a_Name, string? a_Value, string a_DefaultValue)
  {
    var rec = new ArgRecord(a_Name);
    rec.Default = a_DefaultValue;
    m_GridData.Add(rec);
  }

  internal void Clear()
  {
    m_GridData.Clear();
  }

  internal void SetViewData(InstanceNode @in)
  {
    m_ViewData = @in;
    foreach(var arg in m_ViewData.POD)
    {
      if(arg.Value.DefaultValue != null)
      {
        this.Add(arg.Key, arg.Value.Value, arg.Value.DefaultValue);
      }
      else
      {
        this.Add(arg.Key, arg.Value.Value);
      }
    }
  }
}
