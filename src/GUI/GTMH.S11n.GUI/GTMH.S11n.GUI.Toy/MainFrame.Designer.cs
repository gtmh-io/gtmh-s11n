namespace GTMH.S11n.GUI.Toy;

partial class MainFrame
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

  #region Windows Form Designer generated code

  /// <summary>
  ///  Required method for Designer support - do not modify
  ///  the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent()
  {
    menuStrip1 = new MenuStrip();
    fileToolStripMenuItem = new ToolStripMenuItem();
    setObjectTypeToolStripMenuItem = new ToolStripMenuItem();
    m_StatusStrip = new StatusStrip();
    m_View = new GenericS11nControl();
    menuStrip1.SuspendLayout();
    SuspendLayout();
    // 
    // menuStrip1
    // 
    menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
    menuStrip1.Location = new Point(0, 0);
    menuStrip1.Name = "menuStrip1";
    menuStrip1.Size = new Size(800, 24);
    menuStrip1.TabIndex = 0;
    menuStrip1.Text = "menuStrip1";
    // 
    // fileToolStripMenuItem
    // 
    fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setObjectTypeToolStripMenuItem });
    fileToolStripMenuItem.Name = "fileToolStripMenuItem";
    fileToolStripMenuItem.Size = new Size(37, 20);
    fileToolStripMenuItem.Text = "&File";
    // 
    // setObjectTypeToolStripMenuItem
    // 
    setObjectTypeToolStripMenuItem.Name = "setObjectTypeToolStripMenuItem";
    setObjectTypeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
    setObjectTypeToolStripMenuItem.Size = new Size(199, 22);
    setObjectTypeToolStripMenuItem.Text = "Set &Object Type";
    setObjectTypeToolStripMenuItem.Click += setObjectTypeToolStripMenuItem_Click;
    // 
    // m_StatusStrip
    // 
    m_StatusStrip.Location = new Point(0, 428);
    m_StatusStrip.Name = "m_StatusStrip";
    m_StatusStrip.Size = new Size(800, 22);
    m_StatusStrip.TabIndex = 1;
    m_StatusStrip.Text = "statusStrip1";
    // 
    // m_View
    // 
    m_View.Dock = DockStyle.Fill;
    m_View.Location = new Point(0, 24);
    m_View.Name = "m_View";
    m_View.Size = new Size(800, 404);
    m_View.TabIndex = 2;
    // 
    // MainFrame
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(800, 450);
    Controls.Add(m_View);
    Controls.Add(m_StatusStrip);
    Controls.Add(menuStrip1);
    MainMenuStrip = menuStrip1;
    Name = "MainFrame";
    Text = "Instance Configurator";
    menuStrip1.ResumeLayout(false);
    menuStrip1.PerformLayout();
    ResumeLayout(false);
    PerformLayout();
  }

  #endregion

  private MenuStrip menuStrip1;
  private ToolStripMenuItem fileToolStripMenuItem;
  private StatusStrip m_StatusStrip;
  private GenericS11nControl m_View;
  private ToolStripMenuItem setObjectTypeToolStripMenuItem;
}
