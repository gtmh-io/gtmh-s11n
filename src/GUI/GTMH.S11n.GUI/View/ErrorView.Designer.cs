namespace GTMH.S11n.GUI.View
{
  partial class ErrorView
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
      m_ErrorText = new TextBox();
      SuspendLayout();
      // 
      // m_ErrorText
      // 
      m_ErrorText.Dock = DockStyle.Fill;
      m_ErrorText.Location = new Point(0, 0);
      m_ErrorText.Multiline = true;
      m_ErrorText.Name = "m_ErrorText";
      m_ErrorText.Size = new Size(651, 604);
      m_ErrorText.TabIndex = 0;
      // 
      // ErrorView
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(m_ErrorText);
      Name = "ErrorView";
      Size = new Size(651, 604);
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    public TextBox m_ErrorText;
  }
}
