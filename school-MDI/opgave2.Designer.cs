
namespace MDI
{
    partial class opgave2
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
            this.label1 = new System.Windows.Forms.Label();
            this.input = new System.Windows.Forms.TextBox();
            this.letter_for_letter = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "input:";
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(56, 6);
            this.input.Name = "input";
            this.input.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.input.Size = new System.Drawing.Size(306, 23);
            this.input.TabIndex = 1;
            this.input.Text = "Een willekeurige zin en onzin en ...";
            this.input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // letter_for_letter
            // 
            this.letter_for_letter.Location = new System.Drawing.Point(12, 46);
            this.letter_for_letter.Name = "letter_for_letter";
            this.letter_for_letter.Size = new System.Drawing.Size(350, 23);
            this.letter_for_letter.TabIndex = 2;
            this.letter_for_letter.Text = "Letter for letter";
            this.letter_for_letter.UseVisualStyleBackColor = true;
            this.letter_for_letter.Click += new System.EventHandler(this.letter_for_letter_Click);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(12, 120);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.output.Size = new System.Drawing.Size(350, 117);
            this.output.TabIndex = 3;
            this.output.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "output:";
            // 
            // opgave2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.output);
            this.Controls.Add(this.letter_for_letter);
            this.Controls.Add(this.input);
            this.Controls.Add(this.label1);
            this.Name = "opgave2";
            this.Text = "opgave2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Button letter_for_letter;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Label label2;
    }
}