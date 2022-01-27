namespace Zipper
{
    partial class Form1
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
            this.zipfile = new System.Windows.Forms.Button();
            this.unzipfile = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.choosefile = new System.Windows.Forms.Button();
            this.selectedfile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // zipfile
            // 
            this.zipfile.Enabled = false;
            this.zipfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.zipfile.Location = new System.Drawing.Point(12, 12);
            this.zipfile.Name = "zipfile";
            this.zipfile.Size = new System.Drawing.Size(152, 68);
            this.zipfile.TabIndex = 0;
            this.zipfile.Text = "Zip file";
            this.zipfile.UseVisualStyleBackColor = true;
            this.zipfile.Click += new System.EventHandler(this.zipfile_Click);
            // 
            // unzipfile
            // 
            this.unzipfile.Enabled = false;
            this.unzipfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.unzipfile.Location = new System.Drawing.Point(636, 12);
            this.unzipfile.Name = "unzipfile";
            this.unzipfile.Size = new System.Drawing.Size(152, 68);
            this.unzipfile.TabIndex = 1;
            this.unzipfile.Text = "Unzip file";
            this.unzipfile.UseVisualStyleBackColor = true;
            this.unzipfile.Click += new System.EventHandler(this.unzipfile_Click);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(12, 86);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(776, 278);
            this.output.TabIndex = 2;
            // 
            // choosefile
            // 
            this.choosefile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.choosefile.Location = new System.Drawing.Point(12, 370);
            this.choosefile.Name = "choosefile";
            this.choosefile.Size = new System.Drawing.Size(152, 68);
            this.choosefile.TabIndex = 3;
            this.choosefile.Text = "Choose file";
            this.choosefile.UseVisualStyleBackColor = true;
            this.choosefile.Click += new System.EventHandler(this.choosefile_Click);
            // 
            // selectedfile
            // 
            this.selectedfile.FileName = "select file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.choosefile);
            this.Controls.Add(this.output);
            this.Controls.Add(this.unzipfile);
            this.Controls.Add(this.zipfile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zipfile;
        private System.Windows.Forms.Button unzipfile;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button choosefile;
        private System.Windows.Forms.OpenFileDialog selectedfile;
    }
}

