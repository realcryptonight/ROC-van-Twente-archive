using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Useless_app_1
{
    class LabelHandler
    {
        public static Color color;
        /// <summary>
        /// draw L between p0 and p1
        /// </summary>
        /// <algo>
        /// determine width and height
        /// determine location
        /// </algo>
        public static void position(Label L, Point p0, Point p1, Button B)
        {
            color = Colorgenerator.getColor();
            L.BackColor = color;
            int w = p1.X - p0.X; if (w < 0) w = -w;
            int h = p1.Y - p0.Y; if (h < 0) w = -h;
            L.Size = new Size(w, h);
            if(p0.X < p1.X && p0.Y < p1.Y) L.Location = p0;
            if(p1.X < p0.X && p1.Y < p0.Y) L.Location = p1;
            if (p1.X < p0.X && p1.Y > p0.Y) L.Location = new Point(p1.X, p0.Y);
            if (p0.X < p1.X && p0.Y > p1.Y) L.Location = new Point(p0.X, p1.Y);
        }
    }
}
