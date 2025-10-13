using GTMH.S11n.GUI.Node;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GTMH.S11n.GUI.View
{
  public partial class ListView : UserControl
  {
    class Item
    {
      public string? Type { get; init; }
    }
    BindingList<Item> m_GridData = new();
    ListNode? m_Node;
    public ListView()
    {
      InitializeComponent();
    }

    public ListView(ListNode ln, Widget widget)
    {
      InitializeComponent();
      m_ListView.DataSource = m_GridData;
      m_Node = ln;
      m_ListView.SelectionChanged += OnListSelectionChanged;
      PopulateListView();
    }

    private void PopulateListView()
    {
      if ( m_Node == null ) return;
      foreach(InstanceNode node in m_Node.Nodes)
      {
        if(node.ClassName == "")
          m_GridData.Add(new Item());
        else
          m_GridData.Add(new Item { Type = node.ClassName });
      }
    }

    private void OnListSelectionChanged(object? sender, EventArgs ea)
    {
      m_RemButton.Enabled = (m_ListView.SelectedRows.Count > 0);
    }

    private void m_AddButton_Click(object sender, EventArgs e)
    {
      if(m_Node == null) return;
      var name = m_Node.Nodes.Count.ToString();
      var @in = new InstanceNode(name, m_Node.InterfaceType, m_Node.Control, m_Node.Context);
      m_Node.Nodes.Add(@in);
      m_GridData.Add(new Item());
    }

    private void m_RemButton_Click(object sender, EventArgs e)
    {
      if ( m_Node == null ) return;
      var idx = m_ListView.SelectedRows[0].Index;
      m_Node.Nodes.RemoveAt(idx);
      var currIdx = 0;
      foreach(InstanceNode node in m_Node.Nodes)
      {
        node.ResetName(currIdx.ToString());
        ++currIdx;
      }
      m_GridData.Clear();
      PopulateListView();
    }
  }
}
