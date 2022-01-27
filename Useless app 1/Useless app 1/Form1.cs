using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Useless_app_1
{
    /// <summary>
    /// position label l between mousedown and mouseup location
    /// in a random color
    /// animate a button moving towards l while growing/
    /// shrinking to l's size
    /// </summary>
    public partial class Form1 : Form
    {
        public Point md;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            md = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            LabelHandler.position(l, md, e.Location, b);
            t.Start();
        }

        /// <summary>
        /// move b towards l while growing/
        /// shrinking to l's size
        /// </summary>
        private void t_Tick_1(object sender, EventArgs e)
        {
            if (b.Width < l.Width) b.Width++;
            if (b.Width > l.Width) b.Width--;

            if (b.Height < l.Height) b.Height++;
            if (b.Height > l.Height) b.Height--;

            if (b.Location.X < l.Location.X) b.Location = new Point(b.Location.X + 1, b.Location.Y);
            if (b.Location.X > l.Location.X) b.Location = new Point(b.Location.X - 1, b.Location.Y);

            if (b.Location.Y < l.Location.Y) b.Location = new Point(b.Location.X, b.Location.Y + 1);
            if (b.Location.Y > l.Location.Y) b.Location = new Point(b.Location.X, b.Location.Y - 1);

            if (b.Location == l.Location && b.Width == l.Width && b.Height == l.Height) b.BackColor = LabelHandler.color;
        }
    }
}
