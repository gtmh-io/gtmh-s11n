namespace GTMH.S11n.GUI
{
  partial class GenericS11nControl
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
      TreeNode treeNode2 = new TreeNode("RootNode");
      m_TreeView = new TreeView();
      m_SplitContainer = new SplitContainer();
      m_AssemblyPanel = new Panel();
      m_TypeSelector = new ComboBox();
      m_ClearButton = new Button();
      m_BrowseButton = new Button();
      m_AssemblyTB = new TextBox();
      label2 = new Label();
      label1 = new Label();
      m_Args = new ArgsGridView();
      ((System.ComponentModel.ISupportInitialize)m_SplitContainer).BeginInit();
      m_SplitContainer.Panel1.SuspendLayout();
      m_SplitContainer.Panel2.SuspendLayout();
      m_SplitContainer.SuspendLayout();
      m_AssemblyPanel.SuspendLayout();
      SuspendLayout();
      // 
      // m_TreeView
      // 
      m_TreeView.Dock = DockStyle.Fill;
      m_TreeView.Location = new Point(0, 0);
      m_TreeView.Name = "m_TreeView";
      treeNode2.Name = "m_RootNode";
      treeNode2.Text = "RootNode";
      m_TreeView.Nodes.AddRange(new TreeNode[] { treeNode2 });
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
      // 
      // m_SplitContainer.Panel2
      // 
      m_SplitContainer.Panel2.Controls.Add(m_Args);
      m_SplitContainer.Panel2.Controls.Add(m_AssemblyPanel);
      m_SplitContainer.Size = new Size(644, 560);
      m_SplitContainer.SplitterDistance = 214;
      m_SplitContainer.TabIndex = 1;
      // 
      // m_AssemblyPanel
      // 
      m_AssemblyPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      m_AssemblyPanel.Controls.Add(m_TypeSelector);
      m_AssemblyPanel.Controls.Add(m_ClearButton);
      m_AssemblyPanel.Controls.Add(m_BrowseButton);
      m_AssemblyPanel.Controls.Add(m_AssemblyTB);
      m_AssemblyPanel.Controls.Add(label2);
      m_AssemblyPanel.Controls.Add(label1);
      m_AssemblyPanel.Location = new Point(3, 3);
      m_AssemblyPanel.Name = "m_AssemblyPanel";
      m_AssemblyPanel.Size = new Size(420, 65);
      m_AssemblyPanel.TabIndex = 0;
      // 
      // m_TypeSelector
      // 
      m_TypeSelector.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      m_TypeSelector.DropDownStyle = ComboBoxStyle.DropDownList;
      m_TypeSelector.FormattingEnabled = true;
      m_TypeSelector.Location = new Point(65, 36);
      m_TypeSelector.Name = "m_TypeSelector";
      m_TypeSelector.Size = new Size(287, 23);
      m_TypeSelector.TabIndex = 3;
      // 
      // m_ClearButton
      // 
      m_ClearButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      m_ClearButton.Location = new Point(358, 36);
      m_ClearButton.Name = "m_ClearButton";
      m_ClearButton.Size = new Size(56, 23);
      m_ClearButton.TabIndex = 2;
      m_ClearButton.Text = "Clear";
      m_ClearButton.UseVisualStyleBackColor = true;
      // 
      // m_BrowseButton
      // 
      m_BrowseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      m_BrowseButton.Location = new Point(358, 6);
      m_BrowseButton.Name = "m_BrowseButton";
      m_BrowseButton.Size = new Size(56, 23);
      m_BrowseButton.TabIndex = 2;
      m_BrowseButton.Text = "Browse";
      m_BrowseButton.UseVisualStyleBackColor = true;
      // 
      // m_AssemblyTB
      // 
      m_AssemblyTB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      m_AssemblyTB.Location = new Point(65, 7);
      m_AssemblyTB.Name = "m_AssemblyTB";
      m_AssemblyTB.ReadOnly = true;
      m_AssemblyTB.Size = new Size(285, 23);
      m_AssemblyTB.TabIndex = 1;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(6, 39);
      label2.Name = "label2";
      label2.Size = new Size(32, 15);
      label2.TabIndex = 0;
      label2.Text = "Type";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(6, 10);
      label1.Name = "label1";
      label1.Size = new Size(58, 15);
      label1.TabIndex = 0;
      label1.Text = "Assembly";
      // 
      // m_Args
      // 
      m_Args.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      m_Args.Location = new Point(2, 68);
      m_Args.Name = "m_Args";
      m_Args.Size = new Size(421, 489);
      m_Args.TabIndex = 1;
      // 
      // GenericS11nControl
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(m_SplitContainer);
      Name = "GenericS11nControl";
      Size = new Size(644, 560);
      m_SplitContainer.Panel1.ResumeLayout(false);
      m_SplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)m_SplitContainer).EndInit();
      m_SplitContainer.ResumeLayout(false);
      m_AssemblyPanel.ResumeLayout(false);
      m_AssemblyPanel.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private TreeView m_TreeView;
    private SplitContainer m_SplitContainer;
    private Panel m_AssemblyPanel;
    private ComboBox m_TypeSelector;
    private Button m_BrowseButton;
    private TextBox m_AssemblyTB;
    private Label label2;
    private Label label1;
    private Button m_ClearButton;
    private ArgsGridView m_Args;
  }
}
