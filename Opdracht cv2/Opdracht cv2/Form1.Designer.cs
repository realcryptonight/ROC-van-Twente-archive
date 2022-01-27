namespace Opdracht_cv2
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
            this.inputtext1 = new System.Windows.Forms.TextBox();
            this.inputtext2 = new System.Windows.Forms.TextBox();
            this.sendmessages = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // inputtext1
            // 
            this.inputtext1.Location = new System.Drawing.Point(12, 12);
            this.inputtext1.Name = "inputtext1";
            this.inputtext1.Size = new System.Drawing.Size(776, 20);
            this.inputtext1.TabIndex = 0;
            // 
            // inputtext2
            // 
            this.inputtext2.Location = new System.Drawing.Point(12, 38);
            this.inputtext2.Name = "inputtext2";
            this.inputtext2.Size = new System.Drawing.Size(776, 20);
            this.inputtext2.TabIndex = 1;
            // 
            // sendmessages
            // 
            this.sendmessages.Location = new System.Drawing.Point(12, 64);
            this.sendmessages.Name = "sendmessages";
            this.sendmessages.Size = new System.Drawing.Size(96, 23);
            this.sendmessages.TabIndex = 2;
            this.sendmessages.Text = "Send messages";
            this.sendmessages.UseVisualStyleBackColor = true;
            this.sendmessages.Click += new System.EventHandler(this.sendmessages_Click);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(12, 93);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(776, 345);
            this.output.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.output);
            this.Controls.Add(this.sendmessages);
            this.Controls.Add(this.inputtext2);
            this.Controls.Add(this.inputtext1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputtext1;
        private System.Windows.Forms.TextBox inputtext2;
        private System.Windows.Forms.Button sendmessages;
        private System.Windows.Forms.TextBox output;
    }
}

