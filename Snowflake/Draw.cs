using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snowflake
{
    public class Draw
    {
        /// <summary>
        /// Instance of the main form application.
        /// </summary>
        public static Form1 form;
        /// <summary>
        /// The pen that is for drawing the lines.
        /// </summary>
        private static Pen pen = new Pen(Color.Black, 5);
        /// <summary>
        /// // The pen that is for drawing the points. (Mostly for debug.)
        /// </summary>
        private static Pen redpen = new Pen(Color.Red, 5);
        /// <summary>
        /// The grapics.
        /// </summary>
        private static Graphics g;

        /// <summary>
        /// Draw a red point on a point location for easy finding.
        /// </summary>
        /// <param name="point">THe location of the point</param>
        public static void drawPointOnPoint(Point point) {
            if (g == null) {
                g = form.CreateGraphics();
            }

            g.DrawEllipse(redpen, new Rectangle(point.X, point.Y, 5, 5));
        }

        /// <summary>
        /// Draw a line between the first and the second point.
        /// </summary>
        /// <param name="point1">The first point.</param>
        /// <param name="point2">The second point.</param>
        private static void drawLineBetweenPoints(Point point1, Point point2)
        {
            g.DrawLine(pen, point1, point2);
        }

        /// <summary>
        /// Draw a line between the start node and the next node.
        /// Then draw a line between the next node and the next next node.
        /// Etc.
        /// </summary>
        /// <param name="allnodes">The nodes list.</param>
        public static void DrawFlake(nodes allnodes) {

            if (g == null)
            {
                g = form.CreateGraphics();
            }
            else
            {
                g.Clear(form.BackColor);
            }

            node current = allnodes.start;
            while (current.next != null)
            {
                node currentnext = current.next;
                drawLineBetweenPoints(current.value, currentnext.value);
                current = currentnext;
            }
            // The last node will not have a next node but it still needs to connect to the first node.
            drawLineBetweenPoints(allnodes.end.value, allnodes.start.value);
        }
    }
}
