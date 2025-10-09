namespace GTMH.S11n.GUI
{
  partial class ArgsGridView
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
      m_Grid = new DataGridView();
      ((System.ComponentModel.ISupportInitialize)m_Grid).BeginInit();
      SuspendLayout();
      // 
      // m_Grid
      // 
      m_Grid.AllowUserToAddRows = false;
      m_Grid.AllowUserToDeleteRows = false;
      m_Grid.AllowUserToResizeRows = false;
      m_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      m_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      m_Grid.Dock = DockStyle.Fill;
      m_Grid.Location = new Point(0, 0);
      m_Grid.MultiSelect = false;
      m_Grid.Name = "m_Grid";
      m_Grid.RowHeadersVisible = false;
      m_Grid.Size = new Size(150, 150);
      m_Grid.TabIndex = 2;
      // 
      // ArgsGridView
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(m_Grid);
      Name = "ArgsGridView";
      ((System.ComponentModel.ISupportInitialize)m_Grid).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private DataGridView m_Grid;
  }
}
