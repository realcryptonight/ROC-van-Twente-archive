
namespace MDI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.navigationMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opgave1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opgave2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opgave3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigationMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationMenu
            // 
            this.navigationMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.navigationMenu.Location = new System.Drawing.Point(0, 0);
            this.navigationMenu.Name = "navigationMenu";
            this.navigationMenu.Size = new System.Drawing.Size(800, 24);
            this.navigationMenu.TabIndex = 0;
            this.navigationMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opgave1ToolStripMenuItem,
            this.opgave2ToolStripMenuItem,
            this.opgave3ToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // opgave1ToolStripMenuItem
            // 
            this.opgave1ToolStripMenuItem.Name = "opgave1ToolStripMenuItem";
            this.opgave1ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.opgave1ToolStripMenuItem.Text = "Opgave 1";
            this.opgave1ToolStripMenuItem.Click += new System.EventHandler(this.opgave1ToolStripMenuItem_Click);
            // 
            // opgave2ToolStripMenuItem
            // 
            this.opgave2ToolStripMenuItem.Name = "opgave2ToolStripMenuItem";
            this.opgave2ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.opgave2ToolStripMenuItem.Text = "Opgave 2";
            this.opgave2ToolStripMenuItem.Click += new System.EventHandler(this.opgave2ToolStripMenuItem_Click);
            // 
            // opgave3ToolStripMenuItem
            // 
            this.opgave3ToolStripMenuItem.Name = "opgave3ToolStripMenuItem";
            this.opgave3ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.opgave3ToolStripMenuItem.Text = "Opgave 3";
            this.opgave3ToolStripMenuItem.Click += new System.EventHandler(this.opgave3ToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.navigationMenu);
            this.MainMenuStrip = this.navigationMenu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.navigationMenu.ResumeLayout(false);
            this.navigationMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip navigationMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opgave1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opgave2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opgave3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

