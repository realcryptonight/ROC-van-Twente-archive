namespace Galgje
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
            this.guess = new System.Windows.Forms.Button();
            this.guessed_letters = new System.Windows.Forms.TextBox();
            this.guess_userinput = new System.Windows.Forms.TextBox();
            this.guessed_letters_console = new System.Windows.Forms.TextBox();
            this.reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // guess
            // 
            this.guess.Location = new System.Drawing.Point(188, 55);
            this.guess.Name = "guess";
            this.guess.Size = new System.Drawing.Size(117, 40);
            this.guess.TabIndex = 0;
            this.guess.Text = "Send guess";
            this.guess.UseVisualStyleBackColor = true;
            this.guess.Click += new System.EventHandler(this.guess_Click);
            // 
            // guessed_letters
            // 
            this.guessed_letters.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.guessed_letters.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guessed_letters.Location = new System.Drawing.Point(12, 389);
            this.guessed_letters.Multiline = true;
            this.guessed_letters.Name = "guessed_letters";
            this.guessed_letters.ReadOnly = true;
            this.guessed_letters.Size = new System.Drawing.Size(776, 49);
            this.guessed_letters.TabIndex = 2;
            this.guessed_letters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guess_userinput
            // 
            this.guess_userinput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guess_userinput.Location = new System.Drawing.Point(12, 12);
            this.guess_userinput.Multiline = true;
            this.guess_userinput.Name = "guess_userinput";
            this.guess_userinput.Size = new System.Drawing.Size(293, 37);
            this.guess_userinput.TabIndex = 3;
            this.guess_userinput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.guess_userinput_KeyDown);
            // 
            // guessed_letters_console
            // 
            this.guessed_letters_console.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guessed_letters_console.Location = new System.Drawing.Point(392, 12);
            this.guessed_letters_console.Multiline = true;
            this.guessed_letters_console.Name = "guessed_letters_console";
            this.guessed_letters_console.ReadOnly = true;
            this.guessed_letters_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.guessed_letters_console.Size = new System.Drawing.Size(396, 126);
            this.guessed_letters_console.TabIndex = 4;
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.reset.Location = new System.Drawing.Point(603, 144);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(185, 85);
            this.reset.TabIndex = 5;
            this.reset.Text = "Play another game";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Visible = false;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.guessed_letters_console);
            this.Controls.Add(this.guess_userinput);
            this.Controls.Add(this.guessed_letters);
            this.Controls.Add(this.guess);
            this.Name = "Galgje";
            this.Text = "Galgje by Daniel Markink";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox guessed_letters_console;
        public System.Windows.Forms.Button guess;
        public System.Windows.Forms.TextBox guess_userinput;
        public System.Windows.Forms.TextBox guessed_letters;
        public System.Windows.Forms.Button reset;
    }
}

