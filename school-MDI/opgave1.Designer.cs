
namespace MDI
{
    partial class opgave1
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
            this.explain = new System.Windows.Forms.Button();
            this.output_textbox = new System.Windows.Forms.TextBox();
            this.fill_random = new System.Windows.Forms.Button();
            this.move_right = new System.Windows.Forms.Button();
            this.del_selected = new System.Windows.Forms.Button();
            this.sum_selected = new System.Windows.Forms.Button();
            this.move_everything_left = new System.Windows.Forms.Button();
            this.move_left = new System.Windows.Forms.Button();
            this.move_everything_right = new System.Windows.Forms.Button();
            this.leftlistbox = new System.Windows.Forms.ListBox();
            this.rightlistbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // explain
            // 
            this.explain.BackColor = System.Drawing.Color.BurlyWood;
            this.explain.Location = new System.Drawing.Point(260, 12);
            this.explain.Name = "explain";
            this.explain.Size = new System.Drawing.Size(99, 23);
            this.explain.TabIndex = 6;
            this.explain.Text = "Uitleg";
            this.explain.UseVisualStyleBackColor = false;
            this.explain.Click += new System.EventHandler(this.explain_Click);
            // 
            // output_textbox
            // 
            this.output_textbox.Location = new System.Drawing.Point(117, 12);
            this.output_textbox.Name = "output_textbox";
            this.output_textbox.Size = new System.Drawing.Size(137, 23);
            this.output_textbox.TabIndex = 5;
            // 
            // fill_random
            // 
            this.fill_random.Location = new System.Drawing.Point(12, 12);
            this.fill_random.Name = "fill_random";
            this.fill_random.Size = new System.Drawing.Size(99, 23);
            this.fill_random.TabIndex = 4;
            this.fill_random.Text = "Fill random";
            this.fill_random.UseVisualStyleBackColor = true;
            this.fill_random.Click += new System.EventHandler(this.fill_random_Click);
            // 
            // move_right
            // 
            this.move_right.Location = new System.Drawing.Point(135, 114);
            this.move_right.Name = "move_right";
            this.move_right.Size = new System.Drawing.Size(99, 23);
            this.move_right.TabIndex = 9;
            this.move_right.Text = ">";
            this.move_right.UseVisualStyleBackColor = true;
            this.move_right.Click += new System.EventHandler(this.ChangeNumberPlace_Click);
            // 
            // del_selected
            // 
            this.del_selected.Location = new System.Drawing.Point(135, 85);
            this.del_selected.Name = "del_selected";
            this.del_selected.Size = new System.Drawing.Size(99, 23);
            this.del_selected.TabIndex = 10;
            this.del_selected.Text = "Del selected";
            this.del_selected.UseVisualStyleBackColor = true;
            this.del_selected.Click += new System.EventHandler(this.del_selected_Click);
            // 
            // sum_selected
            // 
            this.sum_selected.Location = new System.Drawing.Point(135, 41);
            this.sum_selected.Name = "sum_selected";
            this.sum_selected.Size = new System.Drawing.Size(99, 23);
            this.sum_selected.TabIndex = 11;
            this.sum_selected.Text = "Sum selected";
            this.sum_selected.UseVisualStyleBackColor = true;
            this.sum_selected.Click += new System.EventHandler(this.sum_selected_Click);
            // 
            // move_everything_left
            // 
            this.move_everything_left.Location = new System.Drawing.Point(135, 201);
            this.move_everything_left.Name = "move_everything_left";
            this.move_everything_left.Size = new System.Drawing.Size(99, 23);
            this.move_everything_left.TabIndex = 12;
            this.move_everything_left.Text = "<<";
            this.move_everything_left.UseVisualStyleBackColor = true;
            this.move_everything_left.Click += new System.EventHandler(this.MoveEveryNumber_Click);
            // 
            // move_left
            // 
            this.move_left.Location = new System.Drawing.Point(135, 172);
            this.move_left.Name = "move_left";
            this.move_left.Size = new System.Drawing.Size(99, 23);
            this.move_left.TabIndex = 13;
            this.move_left.Text = "<";
            this.move_left.UseVisualStyleBackColor = true;
            this.move_left.Click += new System.EventHandler(this.ChangeNumberPlace_Click);
            // 
            // move_everything_right
            // 
            this.move_everything_right.Location = new System.Drawing.Point(135, 143);
            this.move_everything_right.Name = "move_everything_right";
            this.move_everything_right.Size = new System.Drawing.Size(99, 23);
            this.move_everything_right.TabIndex = 14;
            this.move_everything_right.Text = ">>";
            this.move_everything_right.UseVisualStyleBackColor = true;
            this.move_everything_right.Click += new System.EventHandler(this.MoveEveryNumber_Click);
            // 
            // leftlistbox
            // 
            this.leftlistbox.FormattingEnabled = true;
            this.leftlistbox.ItemHeight = 15;
            this.leftlistbox.Location = new System.Drawing.Point(12, 41);
            this.leftlistbox.Name = "leftlistbox";
            this.leftlistbox.Size = new System.Drawing.Size(99, 184);
            this.leftlistbox.TabIndex = 15;
            // 
            // rightlistbox
            // 
            this.rightlistbox.FormattingEnabled = true;
            this.rightlistbox.ItemHeight = 15;
            this.rightlistbox.Location = new System.Drawing.Point(260, 41);
            this.rightlistbox.Name = "rightlistbox";
            this.rightlistbox.Size = new System.Drawing.Size(99, 184);
            this.rightlistbox.TabIndex = 16;
            // 
            // opgave1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rightlistbox);
            this.Controls.Add(this.leftlistbox);
            this.Controls.Add(this.move_everything_right);
            this.Controls.Add(this.move_left);
            this.Controls.Add(this.move_everything_left);
            this.Controls.Add(this.sum_selected);
            this.Controls.Add(this.del_selected);
            this.Controls.Add(this.move_right);
            this.Controls.Add(this.explain);
            this.Controls.Add(this.output_textbox);
            this.Controls.Add(this.fill_random);
            this.Name = "opgave1";
            this.Text = "opgave1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button explain;
        private System.Windows.Forms.TextBox output_textbox;
        private System.Windows.Forms.Button fill_random;
        private System.Windows.Forms.Button move_right;
        private System.Windows.Forms.Button del_selected;
        private System.Windows.Forms.Button sum_selected;
        private System.Windows.Forms.Button move_everything_left;
        private System.Windows.Forms.Button move_left;
        private System.Windows.Forms.Button move_everything_right;
        private System.Windows.Forms.ListBox leftlistbox;
        private System.Windows.Forms.ListBox rightlistbox;
    }
}