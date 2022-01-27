
namespace FormSnake
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
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.levelhard = new System.Windows.Forms.Button();
            this.levelmedium = new System.Windows.Forms.Button();
            this.leveleasy = new System.Windows.Forms.Button();
            this.level = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // levelhard
            // 
            this.levelhard.Location = new System.Drawing.Point(513, 87);
            this.levelhard.Name = "levelhard";
            this.levelhard.Size = new System.Drawing.Size(75, 23);
            this.levelhard.TabIndex = 1;
            this.levelhard.Text = "Hard";
            this.levelhard.UseVisualStyleBackColor = true;
            this.levelhard.Click += new System.EventHandler(this.levelhard_Click);
            // 
            // levelmedium
            // 
            this.levelmedium.Location = new System.Drawing.Point(432, 87);
            this.levelmedium.Name = "levelmedium";
            this.levelmedium.Size = new System.Drawing.Size(75, 23);
            this.levelmedium.TabIndex = 2;
            this.levelmedium.Text = "Medium";
            this.levelmedium.UseVisualStyleBackColor = true;
            this.levelmedium.Click += new System.EventHandler(this.levelmedium_Click);
            // 
            // leveleasy
            // 
            this.leveleasy.Location = new System.Drawing.Point(351, 87);
            this.leveleasy.Name = "leveleasy";
            this.leveleasy.Size = new System.Drawing.Size(75, 23);
            this.leveleasy.TabIndex = 3;
            this.leveleasy.Text = "Easy";
            this.leveleasy.UseVisualStyleBackColor = true;
            this.leveleasy.Click += new System.EventHandler(this.leveleasy_Click);
            // 
            // level
            // 
            this.level.BackColor = System.Drawing.Color.Green;
            this.level.Enabled = false;
            this.level.FlatAppearance.BorderSize = 0;
            this.level.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.level.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.level.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.level.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.level.Location = new System.Drawing.Point(351, 12);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(237, 69);
            this.level.TabIndex = 4;
            this.level.Text = "Easy";
            this.level.UseVisualStyleBackColor = false;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(351, 116);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(237, 27);
            this.start.TabIndex = 5;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 650);
            this.Controls.Add(this.start);
            this.Controls.Add(this.level);
            this.Controls.Add(this.leveleasy);
            this.Controls.Add(this.levelmedium);
            this.Controls.Add(this.levelhard);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Snake";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Button levelhard;
        private System.Windows.Forms.Button levelmedium;
        private System.Windows.Forms.Button leveleasy;
        private System.Windows.Forms.Button level;
        private System.Windows.Forms.Button start;
    }
}

