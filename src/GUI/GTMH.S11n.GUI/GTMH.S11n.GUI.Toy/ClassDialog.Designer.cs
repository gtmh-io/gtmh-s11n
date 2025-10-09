namespace GTMH.S11n.GUI.Toy
{
  partial class ClassDialog
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
      groupBox1 = new GroupBox();
      m_Classes = new ComboBox();
      m_CancelButton = new Button();
      m_OKButton = new Button();
      groupBox1.SuspendLayout();
      SuspendLayout();
      // 
      // groupBox1
      // 
      groupBox1.Controls.Add(m_Classes);
      groupBox1.Location = new Point(11, 8);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new Size(241, 55);
      groupBox1.TabIndex = 0;
      groupBox1.TabStop = false;
      groupBox1.Text = "Class";
      // 
      // m_Classes
      // 
      m_Classes.FormattingEnabled = true;
      m_Classes.Location = new Point(6, 22);
      m_Classes.Name = "m_Classes";
      m_Classes.Size = new Size(229, 23);
      m_Classes.TabIndex = 0;
      // 
      // m_CancelButton
      // 
      m_CancelButton.DialogResult = DialogResult.Cancel;
      m_CancelButton.Location = new Point(188, 69);
      m_CancelButton.Name = "m_CancelButton";
      m_CancelButton.Size = new Size(58, 22);
      m_CancelButton.TabIndex = 1;
      m_CancelButton.Text = "Cancel";
      m_CancelButton.UseVisualStyleBackColor = true;
      // 
      // m_OKButton
      // 
      m_OKButton.DialogResult = DialogResult.OK;
      m_OKButton.Location = new Point(124, 69);
      m_OKButton.Name = "m_OKButton";
      m_OKButton.Size = new Size(58, 22);
      m_OKButton.TabIndex = 1;
      m_OKButton.Text = "OK";
      m_OKButton.UseVisualStyleBackColor = true;
      // 
      // ClassDialog
      // 
      AcceptButton = m_OKButton;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = m_CancelButton;
      ClientSize = new Size(254, 95);
      Controls.Add(m_OKButton);
      Controls.Add(m_CancelButton);
      Controls.Add(groupBox1);
      FormBorderStyle = FormBorderStyle.FixedDialog;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "ClassDialog";
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterParent;
      Text = "Select Class";
      groupBox1.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBox1;
    private ComboBox m_Classes;
    private Button m_CancelButton;
    private Button m_OKButton;
  }
}