using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GTMH.S11n.GUI
{
  public partial class GenericS11nControl : UserControl
  {
    class Arg_t
    {
      public string Arg { get; }
      public string Value { get; set; }
      public Arg_t(string a_Arg, string a_Value)
      {
        this.Arg = a_Arg;
        this.Value = a_Value;
      }
    }
    BindingList<Arg_t> m_GridData = new BindingList<Arg_t>();

    private readonly TreeNode RootNode;

    public GenericS11nControl()
    {
      InitializeComponent();
      this.RootNode = m_TreeView.Nodes[0];
      //m_ArgsGrid.DataSource = m_GridData;
    }

    public void SetView(string a_Assembly, string a_Class)
    {
      RootNode.Text=a_Class.Split('.').Last();
      RootNode.ToolTipText = a_Class;
      var pop = new Populator(this);
    }
    class Populator (GenericS11nControl Control): GTMH.S11n.IS11nVisitor
    {
      public GenericS11nControl Control { get; } = Control;

      public void VisitMember(string a_Name, bool a_Required)
      {
        //Control.m_GridData.Add(new Arg_t(a_Name));
      }
      public void VisitInstance(string a_Name, string a_Type, bool a_Required)
      {
      }
      public void VisitInstanceList(string a_Name, string a_Type, bool a_Required)
      {
      }
    }
  }
}
