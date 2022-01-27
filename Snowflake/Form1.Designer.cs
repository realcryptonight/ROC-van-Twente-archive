namespace Snowflake
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
            this.start1 = new System.Windows.Forms.Button();
            this.start2 = new System.Windows.Forms.Button();
            this.start3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start1
            // 
            this.start1.Location = new System.Drawing.Point(31, 23);
            this.start1.Name = "start1";
            this.start1.Size = new System.Drawing.Size(112, 48);
            this.start1.TabIndex = 0;
            this.start1.Text = "start 1";
            this.start1.UseVisualStyleBackColor = true;
            this.start1.Click += new System.EventHandler(this.start1_Click);
            // 
            // start2
            // 
            this.start2.Location = new System.Drawing.Point(149, 23);
            this.start2.Name = "start2";
            this.start2.Size = new System.Drawing.Size(112, 48);
            this.start2.TabIndex = 1;
            this.start2.Text = "start 2";
            this.start2.UseVisualStyleBackColor = true;
            this.start2.Click += new System.EventHandler(this.start2_Click);
            // 
            // start3
            // 
            this.start3.Location = new System.Drawing.Point(267, 23);
            this.start3.Name = "start3";
            this.start3.Size = new System.Drawing.Size(122, 48);
            this.start3.TabIndex = 2;
            this.start3.Text = "start 3";
            this.start3.UseVisualStyleBackColor = true;
            this.start3.Click += new System.EventHandler(this.start3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.start3);
            this.Controls.Add(this.start2);
            this.Controls.Add(this.start1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button start1;
        private System.Windows.Forms.Button start2;
        private System.Windows.Forms.Button start3;
    }
}

