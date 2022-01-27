using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Allows the main form to exspect child forms.
            this.IsMdiContainer = true;
        }

        // The form classes instances.
        about aboutvar = new about();
        opgave1 opgave1var = new opgave1();
        opgave2 opgave2var = new opgave2();
        opgave3 opgave3var = new opgave3();

        /// <summary>
        /// Handle the opening of the form for about.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aboutvar.IsDisposed) {
                aboutvar = new about();
            }
            aboutvar.MdiParent = this;
            aboutvar.WindowState = FormWindowState.Maximized;
            aboutvar.Show();
        }

        /// <summary>
        /// Close the form app when the exit menu item is clicked.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// Handle the opening of the form for opgave1.
        /// </summary>
        private void opgave1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (opgave1var.IsDisposed) {
                opgave1var = new opgave1();
            }
            opgave1var.MdiParent = this;
            opgave1var.WindowState = FormWindowState.Maximized;
            opgave1var.Show();
        }

        /// <summary>
        /// Handle the opening of the form for opgave2.
        /// </summary>
        private void opgave2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (opgave2var.IsDisposed)
            {
                opgave2var = new opgave2();
            }
            opgave2var.MdiParent = this;
            opgave2var.WindowState = FormWindowState.Maximized;
            opgave2var.Show();
        }

        /// <summary>
        /// Handle the opening of the form for opgave3.
        /// </summary>
        private void opgave3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (opgave3var.IsDisposed)
            {
                opgave3var = new opgave3();
            }
            opgave3var.MdiParent = this;
            opgave3var.WindowState = FormWindowState.Maximized;
            opgave3var.Show();
        }
    }
}
