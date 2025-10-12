namespace GTMH.S11n.GUI
{
  partial class Widget
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if(disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      m_TreeView = new TreeView();
      m_SplitContainer = new SplitContainer();
      ((System.ComponentModel.ISupportInitialize)m_SplitContainer).BeginInit();
      m_SplitContainer.Panel1.SuspendLayout();
      m_SplitContainer.SuspendLayout();
      SuspendLayout();
      // 
      // m_TreeView
      // 
      m_TreeView.Dock = DockStyle.Fill;
      m_TreeView.Location = new Point(0, 0);
      m_TreeView.Name = "m_TreeView";
      m_TreeView.PathSeparator = "/";
      m_TreeView.Size = new Size(214, 560);
      m_TreeView.TabIndex = 0;
      // 
      // m_SplitContainer
      // 
      m_SplitContainer.Dock = DockStyle.Fill;
      m_SplitContainer.Location = new Point(0, 0);
      m_SplitContainer.Name = "m_SplitContainer";
      // 
      // m_SplitContainer.Panel1
      // 
      m_SplitContainer.Panel1.Controls.Add(m_TreeView);
      m_SplitContainer.Size = new Size(644, 560);
      m_SplitContainer.SplitterDistance = 214;
      m_SplitContainer.TabIndex = 1;
      // 
      // Widget
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(m_SplitContainer);
      Name = "Widget";
      Size = new Size(644, 560);
      m_SplitContainer.Panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)m_SplitContainer).EndInit();
      m_SplitContainer.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private TreeView m_TreeView;
    private SplitContainer m_SplitContainer;
  }
}
