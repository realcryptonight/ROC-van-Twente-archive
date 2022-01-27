
namespace MDI
{
    partial class opgave3
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
            this.start = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.AutoSize = true;
            this.start.Font = new System.Drawing.Font("Harlow Solid Italic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.start.Location = new System.Drawing.Point(320, 251);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(186, 51);
            this.start.TabIndex = 0;
            this.start.Text = "Like zien?";
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // opgave3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.start);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "opgave3";
            this.Text = "opgave3";
            this.Load += new System.EventHandler(this.opgave3_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.opgave3_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.opgave3_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label start;
    }
}