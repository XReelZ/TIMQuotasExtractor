namespace TIMQuotasExtractor
{
  partial class Main
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
      if (disposing && (components != null))
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
      this.btnSelectFolder = new System.Windows.Forms.Button();
      this.dlgBrowse = new System.Windows.Forms.FolderBrowserDialog();
      this.lblSelectedFolder = new System.Windows.Forms.Label();
      this.btnExtractQuotas = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.dlgSave = new System.Windows.Forms.SaveFileDialog();
      this.SuspendLayout();
      // 
      // btnSelectFolder
      // 
      this.btnSelectFolder.Location = new System.Drawing.Point(13, 42);
      this.btnSelectFolder.Name = "btnSelectFolder";
      this.btnSelectFolder.Size = new System.Drawing.Size(75, 23);
      this.btnSelectFolder.TabIndex = 0;
      this.btnSelectFolder.Text = "Browse...";
      this.btnSelectFolder.UseVisualStyleBackColor = true;
      this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
      // 
      // dlgBrowse
      // 
      this.dlgBrowse.ShowNewFolderButton = false;
      // 
      // lblSelectedFolder
      // 
      this.lblSelectedFolder.AutoSize = true;
      this.lblSelectedFolder.Location = new System.Drawing.Point(94, 47);
      this.lblSelectedFolder.Name = "lblSelectedFolder";
      this.lblSelectedFolder.Size = new System.Drawing.Size(0, 13);
      this.lblSelectedFolder.TabIndex = 1;
      // 
      // btnExtractQuotas
      // 
      this.btnExtractQuotas.Location = new System.Drawing.Point(13, 72);
      this.btnExtractQuotas.Name = "btnExtractQuotas";
      this.btnExtractQuotas.Size = new System.Drawing.Size(75, 23);
      this.btnExtractQuotas.TabIndex = 2;
      this.btnExtractQuotas.Text = "Extract";
      this.btnExtractQuotas.UseVisualStyleBackColor = true;
      this.btnExtractQuotas.Click += new System.EventHandler(this.btnExtractQuotas_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(191, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Select Main folder of Space Engineers ";
      // 
      // dlgSave
      // 
      this.dlgSave.DefaultExt = "txt";
      this.dlgSave.Filter = "Text files (*.txt)|*.txt";
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(625, 105);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnExtractQuotas);
      this.Controls.Add(this.lblSelectedFolder);
      this.Controls.Add(this.btnSelectFolder);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "Main";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Tim Quotas Extractor";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog dlgBrowse;
        private System.Windows.Forms.Label lblSelectedFolder;
    private System.Windows.Forms.Button btnExtractQuotas;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.SaveFileDialog dlgSave;
  }
}

