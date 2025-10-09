namespace GTMH.S11n.GUI
{
  partial class InstantiableControl
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
      m_Items = new ComboBox();
      SuspendLayout();
      // 
      // m_Items
      // 
      m_Items.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      m_Items.FormattingEnabled = true;
      m_Items.Location = new Point(3, 3);
      m_Items.Name = "m_Items";
      m_Items.Size = new Size(139, 23);
      m_Items.TabIndex = 0;
      // 
      // InstantiableControl
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(m_Items);
      Name = "InstantiableControl";
      Size = new Size(146, 29);
      ResumeLayout(false);
    }

    #endregion

    private ComboBox m_Items;
  }
}
