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
    Widget m_Control;
    public ListView()
    {
      InitializeComponent();
      m_Control = new Widget();
    }

    public ListView(ListNode ln, Widget widget)
    {
      InitializeComponent();
      m_ListView.DataSource = m_GridData;
      m_Node = ln;
      m_Control = widget;
      m_ListView.SelectionChanged += (_,__)=>OnListSelectionChanged();
      PopulateListView();
    }

    private void PopulateListView()
    {
      if(m_Node == null)
        return;
      foreach(InstanceNode node in m_Node.Nodes)
      {
        if(node.ClassName == "")
          m_GridData.Add(new Item());
        else
          m_GridData.Add(new Item { Type = node.ClassName });
      }
    }

    private void OnListSelectionChanged()
    {
      m_RemButton.Enabled = (m_ListView.SelectedRows.Count > 0);
      if(m_ListView.SelectedRows.Count == 0)
      {
        m_UpButton.Enabled = false;
        m_DownButton.Enabled = false;
      }
      else
      {
        var idx = m_ListView.SelectedRows[0].Index;
        m_UpButton.Enabled = (idx > 0);
        m_DownButton.Enabled = (idx < m_GridData.Count - 1);
      }
    }

    private void m_AddButton_Click(object sender, EventArgs e)
    {
      if(m_Node == null)
        return;
      var name = m_Node.Nodes.Count.ToString();
      var @in = new InstanceNode(name, m_Node.InterfaceType, m_Node.Control, m_Node.Context);
      m_Node.Nodes.Add(@in);
      m_GridData.Add(new Item());
      m_Control.SetDirty();
    }

    private void m_RemButton_Click(object sender, EventArgs e)
    {
      if(m_Node == null)
        return;
      var idx = m_ListView.SelectedRows[0].Index;
      m_Node.Nodes.RemoveAt(idx);
      var currIdx = 0;
      foreach(InstanceNode node in m_Node.Nodes)
      {
        node.ResetName(currIdx.ToString());
        ++currIdx;
      }
      m_GridData.Clear();
      m_Control.SetDirty();
      PopulateListView();
    }

    private void m_UpButton_Click(object sender, EventArgs e)
    {
      if ( m_Node == null ) return;
      var idx = m_ListView.SelectedRows.Count> 0 ? m_ListView.SelectedRows[0].Index : -1;
      if ( idx == -1 || idx == 0 ) return;
      var tmp = m_Node.Nodes[idx];
      m_Node.Nodes.RemoveAt(idx);
      m_Node.Nodes.Insert(idx-1, tmp);
      var currIdx = 0;
      foreach(InstanceNode node in m_Node.Nodes)
      {
        node.ResetName(currIdx.ToString());
        ++currIdx;
      }
      m_GridData.Clear();
      PopulateListView();
      m_ListView.ClearSelection();
      m_ListView.Rows[idx-1].Selected=true;
      this.OnListSelectionChanged();
      m_Control.SetDirty();
    }

    private void m_DownButton_Click(object sender, EventArgs e)
    {
      if ( m_Node==null ) return;
      var idx = m_ListView.SelectedRows.Count> 0 ? m_ListView.SelectedRows[0].Index : -1;
      if ( idx == -1 || idx == m_ListView.RowCount-1) return;
      var tmp = m_Node.Nodes[idx];
      m_Node.Nodes.RemoveAt(idx);
      m_Node.Nodes.Insert(idx+1, tmp);
      var currIdx = 0;
      foreach(InstanceNode node in m_Node.Nodes)
      {
        node.ResetName(currIdx.ToString());
        ++currIdx;
      }
      m_GridData.Clear();
      PopulateListView();
      m_ListView.ClearSelection();
      m_ListView.Rows[idx+1].Selected=true;
      this.OnListSelectionChanged();
      m_Control.SetDirty();
    }
  }
}
