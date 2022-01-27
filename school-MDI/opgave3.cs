using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDI
{
    public partial class opgave3 : Form
    {
        public opgave3()
        {
            InitializeComponent();
        }

        private static Pen pen = new Pen(Color.Black, 2);
        private static Graphics g;
        private static opgave3 form;
        private static Point one;
        private static Point two;
        private bool isstarted = false;

        /// <summary>
        /// Hide the text on the form and draw a grid with a pen.
        /// </summary>
        private void start_Click(object sender, EventArgs e)
        {
            isstarted = true;
            MessageBox.Show("Teken na m.b.v static methods in een class." + Environment.NewLine + Environment.NewLine + "Je tekent ractangles tussen mousedown en mouseup. De kleur van de ractangle is afhankelijk van of het mousedown punt links of rechts en onder of boven het mouseup punt ligt.");
            start.Visible = false;
            if (g == null)
            {
                g = form.CreateGraphics();
            }
            for (int i = 0; i < form.Width; i = i + 20)
            {
                g.DrawLine(pen, i, 0, i, form.Width);
                g.DrawLine(pen, 0, i, form.Width, i);
            }
        }

        private void opgave3_Load(object sender, EventArgs e)
        {
            form = this;
        }

        /// <summary>
        /// Save the mouseDown location to a variable for later.
        /// </summary>
        private void opgave3_MouseDown(object sender, MouseEventArgs e)
        {
            if (isstarted)
            {
                one = e.Location;
            }
        }

        /// <summary>
        /// Get the mouseUp location and give it to the draw function with the md.
        /// </summary>
        private void opgave3_MouseUp(object sender, MouseEventArgs e)
        {
            if (isstarted)
            {
                two = e.Location;
                draw();
            }
        }

        /// <summary>
        /// Draw a box around the 2 point.
        /// </summary>
        /// <param name="one">The first point on the form.</param>
        /// <param name="two">The second point on the form.</param>
        private static void draw() {
            pen.Color = getRandomColor();
            pen.Width = 5;
            g.DrawLine(pen, one.X, one.Y, one.X, two.Y);
            g.DrawLine(pen, two.X, two.Y, two.X, one.Y);
            g.DrawLine(pen, one.X, one.Y, two.X, one.Y);
            g.DrawLine(pen, two.X, two.Y, one.X, two.Y);
        }

        /// <summary>
        /// Return a color based on the position of two points.
        /// </summary>
        /// <returns>A random color.</returns>
        private static Color getRandomColor() {
            if (one.Y < two.Y) { return Color.Blue; };
            if (one.Y > two.Y) { return Color.Red; };
            return Color.Green;
        }
    }
}
