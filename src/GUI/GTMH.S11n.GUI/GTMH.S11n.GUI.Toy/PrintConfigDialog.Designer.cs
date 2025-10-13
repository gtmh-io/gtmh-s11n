namespace GTMH.S11n.GUI.Toy
{
  partial class PrintConfigDialog
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      m_Content = new TextBox();
      button1 = new Button();
      SuspendLayout();
      // 
      // m_Content
      // 
      m_Content.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      m_Content.Location = new Point(2, 4);
      m_Content.Multiline = true;
      m_Content.Name = "m_Content";
      m_Content.ScrollBars = ScrollBars.Both;
      m_Content.Size = new Size(685, 387);
      m_Content.TabIndex = 0;
      // 
      // button1
      // 
      button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      button1.DialogResult = DialogResult.OK;
      button1.Location = new Point(591, 397);
      button1.Name = "button1";
      button1.Size = new Size(81, 26);
      button1.TabIndex = 1;
      button1.Text = "Close";
      button1.UseVisualStyleBackColor = true;
      // 
      // PrintConfigDialog
      // 
      AcceptButton = button1;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = button1;
      ClientSize = new Size(689, 426);
      Controls.Add(button1);
      Controls.Add(m_Content);
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "PrintConfigDialog";
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterParent;
      Text = "PrintConfigDialog";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private TextBox m_Content;
    private Button button1;
  }
}