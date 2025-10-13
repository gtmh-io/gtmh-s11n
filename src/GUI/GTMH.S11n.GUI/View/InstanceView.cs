using GTMH.S11n.GUI.Node;
using GTMH.S11n.Reflection;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GTMH.S11n.GUI;

public partial class InstanceView : UserControl
{
  InstanceNode m_Node;
  Widget m_Widget;
  private bool m_Suppress = true;
  public InstanceView()
  {
    InitializeComponent();
    m_Widget = new Widget(); // placeholder
    m_Node= new InstanceNode("Instance", m_Widget); // placholder
  }

  public InstanceView(InstanceNode @in, Widget widget)
  {
    InitializeComponent();
    m_Node = @in;
    m_Widget = widget;
    PopulateArgs();
    if(m_Node.Assembly != "")
    {
      m_AssemblyTB.Text = m_Node.Assembly;
      foreach(var ty in Instantiable.Find(m_Node.Assembly, m_Node.InterfaceType).OrderBy(_=>_))
      {
        m_TypeSelector.Items.Add(ty);
        if ( ty == m_Node.ClassName ) m_TypeSelector.SelectedItem = ty;
      }
    }
    m_Suppress = false;
  }

  private void PopulateArgs()
  {
    foreach(var arg in m_Node.POD)
    {
      if(arg.Value.DefaultValue != null)
      {
        this.m_Args.Add(arg.Key, arg.Value.Value, arg.Value.DefaultValue);
      }
      else
      {
        this.m_Args.Add(arg.Key, arg.Value.Value);
      }
    }
  }

  private void m_ClearButton_Click(object sender, EventArgs e)
  {
    m_TypeSelector.SelectedItem = null;
    m_AssemblyTB.Text="";
  }

  private void m_TypeSelector_SelectedIndexChanged(object sender, EventArgs ea)
  {
    if ( m_Suppress ) return;
    if(m_TypeSelector.SelectedItem == null)
    {
      m_Node.Clear();
      m_Args.Clear();
      return;
    }

    var node = m_Node.Copy(m_AssemblyTB.Text, (string)m_TypeSelector.SelectedItem);
    var pop = new Widget.Populator(m_Widget, node);
    try
    {
      Instantiable.Visit(m_AssemblyTB.Text, (string)m_TypeSelector.SelectedItem, pop);
    }
    catch(Exception e)
    {
      m_Widget.ShowError(e);
      return;
    }

    m_Widget.Update(m_Node, node);
  }

  private void m_BrowseButton_Click_1(object sender, EventArgs ea)
  {
    var dlg = new OpenFileDialog();
    dlg.Filter = ".Net Assembly|*.dll";
    using(var ll = dlg.LastLocation(m_Node.InterfaceType==null?$"InstanceView.{m_Node.Context}.Browse":$"InstanceView.{m_Node.Context}.{m_Node.InterfaceType.FullName}.Browse", m_Widget.LoadContext.Directory))
    {
      if ( dlg.ShowDialog(this) != DialogResult.OK )  return;
      ll.Commit();
    }
    try
    {
      m_TypeSelector.Items.Clear();
      foreach(var ty in Instantiable.Find(dlg.FileName, m_Node.InterfaceType).OrderBy(_=>_))
      {
        m_TypeSelector.Items.Add(ty);
      }
      m_AssemblyTB.Text = dlg.FileName;
    }
    catch(Exception e)
    {
      m_Widget.ShowError(e);
      return;
    }
  }
}
