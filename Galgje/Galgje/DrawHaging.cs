using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galgje
{
    class DrawHaging
    {
        private static Pen pen = new Pen(Color.Black, 5);
        public static Form1 form;
        public static Graphics g;

        /// <summary>
        /// Draw he hanging person based on how many wrong tries the gueser has made.
        /// </summary>
        public static void drawHangingPerson() {
            if (g == null) { 
                g = form.CreateGraphics();
            }
            int step = Logic.tries;
                if (step == 1)
                {
                    g.DrawLine(pen, 150, 150, 150, 350);
                    return;
                }
                if (step == 2) {
                    g.DrawLine(pen, 50, 350, 153, 350);
                    return;
                }
                if (step == 3) {
                    g.DrawLine(pen, 50, 150, 153, 150);
                    return;
                }
                if (step == 4) {
                    g.DrawLine(pen, 100, 150, 151, 180);
                    return;
                }
                if (step == 5) {
                    g.DrawLine(pen, 75, 150, 75, 180);
                    return;
                }
                if (step == 6) {
                    g.DrawEllipse(pen, 55, 180, 40, 40);
                }
                if (step == 7) {
                    g.DrawLine(pen, 75, 220, 75, 280);
                }
                if (step == 8) {
                    g.DrawLine(pen, 75, 230, 50, 245);
                }
                if (step == 9) {
                    g.DrawLine(pen, 75, 230, 100, 245);
                }
                if (step == 10) {
                    g.DrawLine(pen, 75, 280, 50, 295);
                }
                if (step == 11) {
                    g.DrawLine(pen, 75, 280, 100, 295);
            }
        }
    }
}
