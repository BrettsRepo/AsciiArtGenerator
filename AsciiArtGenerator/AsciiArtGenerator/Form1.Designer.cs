using System.Collections.Generic;

namespace AsciiArtGenerator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private List<string> searchTerms = new List<string>();

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnUpload = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.richTextBoxAsciiArt = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnLoadFromUrl = new System.Windows.Forms.Button();
            this.btnRandomize = new System.Windows.Forms.Button();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReveal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(796, 11);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(120, 23);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload Image";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(16, 82);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 300);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // richTextBoxAsciiArt
            // 
            this.richTextBoxAsciiArt.Location = new System.Drawing.Point(422, 82);
            this.richTextBoxAsciiArt.Name = "richTextBoxAsciiArt";
            this.richTextBoxAsciiArt.ReadOnly = true;
            this.richTextBoxAsciiArt.Size = new System.Drawing.Size(550, 459);
            this.richTextBoxAsciiArt.TabIndex = 2;
            this.richTextBoxAsciiArt.Text = "";
            this.richTextBoxAsciiArt.Click += new System.EventHandler(this.richTextBoxAsciiArt_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(796, 40);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save ASCII";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(264, 14);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(400, 20);
            this.txtUrl.TabIndex = 4;
            // 
            // btnLoadFromUrl
            // 
            this.btnLoadFromUrl.Location = new System.Drawing.Point(670, 12);
            this.btnLoadFromUrl.Name = "btnLoadFromUrl";
            this.btnLoadFromUrl.Size = new System.Drawing.Size(120, 23);
            this.btnLoadFromUrl.TabIndex = 5;
            this.btnLoadFromUrl.Text = "Load from URL";
            this.btnLoadFromUrl.UseVisualStyleBackColor = true;
            this.btnLoadFromUrl.Click += new System.EventHandler(this.btnLoadFromUrl_Click);
            // 
            // btnRandomize
            // 
            this.btnRandomize.Location = new System.Drawing.Point(12, 12);
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(120, 23);
            this.btnRandomize.TabIndex = 6;
            this.btnRandomize.Text = "&Randomize";
            this.btnRandomize.UseVisualStyleBackColor = true;
            this.btnRandomize.Click += new System.EventHandler(this.btnRandomize_Click);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(12, 41);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(120, 23);
            this.btnCopyToClipboard.TabIndex = 7;
            this.btnCopyToClipboard.Text = "Copy to &Clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(138, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Cl&ear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReveal
            // 
            this.btnReveal.Location = new System.Drawing.Point(138, 40);
            this.btnReveal.Name = "btnReveal";
            this.btnReveal.Size = new System.Drawing.Size(120, 23);
            this.btnReveal.TabIndex = 10;
            this.btnReveal.Text = "Re&veal Image";
            this.btnReveal.UseVisualStyleBackColor = true;
            this.btnReveal.Click += new System.EventHandler(this.btnReveal_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(984, 582);
            this.Controls.Add(this.btnReveal);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.btnRandomize);
            this.Controls.Add(this.btnLoadFromUrl);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.richTextBoxAsciiArt);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnUpload);
            this.Name = "Form1";
            this.Text = "ASCII Art Generator";
            this.Click += new System.EventHandler(this.Form1_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.RichTextBox richTextBoxAsciiArt;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnLoadFromUrl;
        private System.Windows.Forms.Button btnRandomize;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnReveal;
    }
}
