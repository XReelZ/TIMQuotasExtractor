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
      this.lblTitle = new System.Windows.Forms.Label();
      this.dlgSave = new System.Windows.Forms.SaveFileDialog();
      this.chbVanilla = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // btnSelectFolder
      // 
      this.btnSelectFolder.Location = new System.Drawing.Point(13, 66);
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
      this.lblSelectedFolder.Location = new System.Drawing.Point(94, 71);
      this.lblSelectedFolder.Name = "lblSelectedFolder";
      this.lblSelectedFolder.Size = new System.Drawing.Size(39, 13);
      this.lblSelectedFolder.TabIndex = 1;
      this.lblSelectedFolder.Text = "[Label]";
      // 
      // btnExtractQuotas
      // 
      this.btnExtractQuotas.Location = new System.Drawing.Point(13, 96);
      this.btnExtractQuotas.Name = "btnExtractQuotas";
      this.btnExtractQuotas.Size = new System.Drawing.Size(75, 23);
      this.btnExtractQuotas.TabIndex = 2;
      this.btnExtractQuotas.Text = "Extract";
      this.btnExtractQuotas.UseVisualStyleBackColor = true;
      this.btnExtractQuotas.Click += new System.EventHandler(this.btnExtractQuotas_Click);
      // 
      // lblTitle
      // 
      this.lblTitle.AutoSize = true;
      this.lblTitle.Location = new System.Drawing.Point(13, 13);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(191, 13);
      this.lblTitle.TabIndex = 3;
      this.lblTitle.Text = "Select Main folder of Space Engineers ";
      // 
      // dlgSave
      // 
      this.dlgSave.DefaultExt = "txt";
      this.dlgSave.Filter = "Text files (*.txt)|*.txt";
      // 
      // chbVanilla
      // 
      this.chbVanilla.AutoSize = true;
      this.chbVanilla.Location = new System.Drawing.Point(13, 43);
      this.chbVanilla.Name = "chbVanilla";
      this.chbVanilla.Size = new System.Drawing.Size(130, 17);
      this.chbVanilla.TabIndex = 4;
      this.chbVanilla.Text = "Vanilla Only Blueprints";
      this.chbVanilla.UseVisualStyleBackColor = true;
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(625, 130);
      this.Controls.Add(this.chbVanilla);
      this.Controls.Add(this.lblTitle);
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
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.SaveFileDialog dlgSave;
    private System.Windows.Forms.CheckBox chbVanilla;
  }
}

