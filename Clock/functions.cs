using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    internal class functions
    {
        private static Pen pen = new Pen(Color.Black, 5);
        private static Pen redpen = new Pen(Color.Red, 5);
        public static Pen backgroundpen = new Pen(Color.LightGray, 5);
        public static Graphics g;
        private static Point center = new Point(150,150);

        /// <summary>
        /// Draw the skeleton for a analog clock.
        /// </summary>
        /// <param name="form">The instance of the form.</param>
        public static void drawClockSkeleton(Form1 form) {
            if (g == null)
            {
                g = form.CreateGraphics();
            }

            g.DrawEllipse(pen, new RectangleF(1, 1, 300, 300));

            for (int i = 1; i < 13; i++)
            {
                PointF rem = PointOnCircle(150, ((i * 30) - 90), center);
                g.DrawString(i.ToString(), new Font("Ariel", 12), Brushes.Black, rem);
                g.DrawEllipse(redpen, new RectangleF(rem.X, rem.Y, 2, 2));
            }
        }

        /// <summary>
        /// Calculate the end point of a hand.
        /// </summary>
        /// <param name="radius">The lengh from the center to the edge.</param>
        /// <param name="angleInDegrees">The angle in degrees. (0 = 90 degree)</param>
        /// <param name="origin">The center point.</param>
        /// <returns>The endpoint of the hand.</returns>
        /// 
        private static PointF PointOnCircle(float radius, float angleInDegrees, PointF origin)
        {
            double doublex = Math.Cos(angleInDegrees * Math.PI / 180);
            double doubley = Math.Sin(angleInDegrees * Math.PI / 180);

            float x = (float)(radius * doublex);
            float y = (float)(radius * doubley);

            x = x + origin.X;
            y = y + origin.Y;

            return new PointF(x, y);
        }

        /// <summary>
        /// Draw the hands of the clock to the current time.
        /// </summary>
        /// <param name="form">The instance of the form.</param>
        public static void DrawHands(Form1 form) {

            DateTime dt = DateTime.Now;
            int hour = dt.Hour;
            int minute = dt.Minute;
            int second = dt.Second;

            PointF oldhourpoint = PointOnCircle(90, ((hour * 30 - 90) + minute * (float)0.5), center);
            PointF oldminutepoint = PointOnCircle(110, ((minute - 1) * 6 - 90), center);
            PointF oldsecondpoint = PointOnCircle(110, ((second - 1) * 6 - 90), center);

            PointF hourpoint = PointOnCircle(90, ((hour * 30 - 90) + minute * (float)0.5), center);
            PointF minutepoint = PointOnCircle(110, (minute * 6 - 90), center);
            PointF secondpoint = PointOnCircle(110, (second * 6 - 90), center);

            g.DrawLine(backgroundpen, center, oldminutepoint);
            g.DrawLine(backgroundpen, center, oldsecondpoint);
            g.DrawLine(backgroundpen, center, oldhourpoint);
            g.DrawLine(pen, center, minutepoint);
            g.DrawLine(redpen, center, secondpoint);
            g.DrawLine(pen, center, hourpoint);
        }
    }
}
