using GTMH.S11n.GUI.Node;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GTMH.S11n.GUI
{
  public partial class InstanceView : UserControl
  {
    public InstanceView()
    {
      InitializeComponent();
    }

    public InstanceView(InstanceNode @in, Widget widget)
    {
      InitializeComponent();
      this.m_AssemblyTB.Text = @in.Assembly;
      if(@in.Type != "")
      {
        this.m_TypeSelector.Items.Add(@in.Type);
        this.m_TypeSelector.SelectedItem = @in.Type;
      }
      foreach(var arg in @in.POD)
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
  }
}
