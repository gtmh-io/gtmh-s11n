namespace GTMH.S11n.GUI.View
{
  partial class ListView
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
      m_ListView = new DataGridView();
      m_AddButton = new Button();
      m_RemButton = new Button();
      m_UpButton = new Button();
      m_DownButton = new Button();
      ((System.ComponentModel.ISupportInitialize)m_ListView).BeginInit();
      SuspendLayout();
      // 
      // m_ListView
      // 
      m_ListView.AllowUserToAddRows = false;
      m_ListView.AllowUserToDeleteRows = false;
      m_ListView.AllowUserToResizeRows = false;
      m_ListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      m_ListView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      m_ListView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      m_ListView.Location = new Point(0, 0);
      m_ListView.Name = "m_ListView";
      m_ListView.ReadOnly = true;
      m_ListView.RowHeadersVisible = false;
      m_ListView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      m_ListView.Size = new Size(568, 418);
      m_ListView.TabIndex = 0;
      // 
      // m_AddButton
      // 
      m_AddButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      m_AddButton.Location = new Point(438, 424);
      m_AddButton.Name = "m_AddButton";
      m_AddButton.Size = new Size(63, 21);
      m_AddButton.TabIndex = 1;
      m_AddButton.Text = "Add";
      m_AddButton.UseVisualStyleBackColor = true;
      m_AddButton.Click += m_AddButton_Click;
      // 
      // m_RemButton
      // 
      m_RemButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      m_RemButton.Enabled = false;
      m_RemButton.Location = new Point(502, 424);
      m_RemButton.Name = "m_RemButton";
      m_RemButton.Size = new Size(63, 21);
      m_RemButton.TabIndex = 1;
      m_RemButton.Text = "Remove";
      m_RemButton.UseVisualStyleBackColor = true;
      m_RemButton.Click += m_RemButton_Click;
      // 
      // m_UpButton
      // 
      m_UpButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      m_UpButton.Enabled = false;
      m_UpButton.Location = new Point(3, 424);
      m_UpButton.Name = "m_UpButton";
      m_UpButton.Size = new Size(63, 21);
      m_UpButton.TabIndex = 1;
      m_UpButton.Text = "Up";
      m_UpButton.UseVisualStyleBackColor = true;
      m_UpButton.Click += m_UpButton_Click;
      // 
      // m_DownButton
      // 
      m_DownButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      m_DownButton.Enabled = false;
      m_DownButton.Location = new Point(67, 424);
      m_DownButton.Name = "m_DownButton";
      m_DownButton.Size = new Size(63, 21);
      m_DownButton.TabIndex = 1;
      m_DownButton.Text = "Down";
      m_DownButton.UseVisualStyleBackColor = true;
      m_DownButton.Click += m_DownButton_Click;
      // 
      // ListView
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(m_DownButton);
      Controls.Add(m_RemButton);
      Controls.Add(m_UpButton);
      Controls.Add(m_AddButton);
      Controls.Add(m_ListView);
      Name = "ListView";
      Size = new Size(568, 450);
      ((System.ComponentModel.ISupportInitialize)m_ListView).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private DataGridView m_ListView;
    private Button m_AddButton;
    private Button m_RemButton;
    private Button m_UpButton;
    private Button m_DownButton;
  }
}
