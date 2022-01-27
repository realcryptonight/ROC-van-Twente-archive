namespace Useless_app_1
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
            this.components = new System.ComponentModel.Container();
            this.l = new System.Windows.Forms.Label();
            this.b = new System.Windows.Forms.Button();
            this.t = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // l
            // 
            this.l.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.l.Location = new System.Drawing.Point(305, 257);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(100, 23);
            this.l.TabIndex = 0;
            // 
            // b
            // 
            this.b.Enabled = false;
            this.b.Location = new System.Drawing.Point(330, 364);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(75, 23);
            this.b.TabIndex = 1;
            this.b.UseVisualStyleBackColor = false;
            // 
            // t
            // 
            this.t.Interval = 10;
            this.t.Tick += new System.EventHandler(this.t_Tick_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.b);
            this.Controls.Add(this.l);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label l;
        private System.Windows.Forms.Button b;
        private System.Windows.Forms.Timer t;
    }
}

