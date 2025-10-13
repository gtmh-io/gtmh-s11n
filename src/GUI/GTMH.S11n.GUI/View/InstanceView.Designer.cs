


namespace GTMH.S11n.GUI
{
  partial class InstanceView
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
      m_Args = new ArgsGridView();
      m_AssemblyPanel = new Panel();
      m_TypeSelector = new ComboBox();
      m_ClearButton = new Button();
      m_BrowseButton = new Button();
      m_AssemblyTB = new TextBox();
      label2 = new Label();
      label1 = new Label();
      m_AssemblyPanel.SuspendLayout();
      SuspendLayout();
      // 
      // m_Args
      // 
      m_Args.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      m_Args.Location = new Point(3, 68);
      m_Args.Name = "m_Args";
      m_Args.Size = new Size(434, 492);
      m_Args.TabIndex = 3;
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
      m_AssemblyPanel.Location = new Point(4, 3);
      m_AssemblyPanel.Name = "m_AssemblyPanel";
      m_AssemblyPanel.Size = new Size(433, 65);
      m_AssemblyPanel.TabIndex = 2;
      // 
      // m_TypeSelector
      // 
      m_TypeSelector.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      m_TypeSelector.DropDownStyle = ComboBoxStyle.DropDownList;
      m_TypeSelector.FormattingEnabled = true;
      m_TypeSelector.Location = new Point(65, 36);
      m_TypeSelector.Name = "m_TypeSelector";
      m_TypeSelector.Size = new Size(303, 23);
      m_TypeSelector.TabIndex = 3;
      m_TypeSelector.SelectedIndexChanged += m_TypeSelector_SelectedIndexChanged;
      // 
      // m_ClearButton
      // 
      m_ClearButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      m_ClearButton.Location = new Point(374, 36);
      m_ClearButton.Name = "m_ClearButton";
      m_ClearButton.Size = new Size(56, 23);
      m_ClearButton.TabIndex = 2;
      m_ClearButton.Text = "Clear";
      m_ClearButton.UseVisualStyleBackColor = true;
      m_ClearButton.Click += this.m_ClearButton_Click;
      // 
      // m_BrowseButton
      // 
      m_BrowseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      m_BrowseButton.Location = new Point(374, 7);
      m_BrowseButton.Name = "m_BrowseButton";
      m_BrowseButton.Size = new Size(56, 23);
      m_BrowseButton.TabIndex = 2;
      m_BrowseButton.Text = "Browse";
      m_BrowseButton.UseVisualStyleBackColor = true;
      m_BrowseButton.Click += m_BrowseButton_Click_1;
      // 
      // m_AssemblyTB
      // 
      m_AssemblyTB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      m_AssemblyTB.Location = new Point(65, 7);
      m_AssemblyTB.Name = "m_AssemblyTB";
      m_AssemblyTB.ReadOnly = true;
      m_AssemblyTB.Size = new Size(303, 23);
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
      // InstanceView
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(m_Args);
      Controls.Add(m_AssemblyPanel);
      Name = "InstanceView";
      Size = new Size(440, 563);
      m_AssemblyPanel.ResumeLayout(false);
      m_AssemblyPanel.PerformLayout();
      ResumeLayout(false);
    }



    #endregion

    private ArgsGridView m_Args;
    private ComboBox m_TypeSelector;
    private Button m_ClearButton;
    private Button m_BrowseButton;
    private TextBox m_AssemblyTB;
    private Label label2;
    private Label label1;
    public Panel m_AssemblyPanel;
  }
}
