using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowflake
{
    internal class Functions
    {
        /// <summary>
        /// This function will calculate the third point for creating a triangle.
        /// </summary>
        /// <algo>
        /// First calculate the length of the adicent side and the opposite side.
        /// Then we can do A square + B square = C square for the sloping side.
        /// 
        /// Then we do some standard triangle calculations to calculate the point of the third point.
        /// </algo>
        /// <param name="point1">The first point.</param>
        /// <param name="point2">The second point.</param>
        /// <returns>The third point to create a triangle.</returns>
        public static Point createTriangle(Point point1, Point point2)
        {
            // Calculete the distance between the X points of point 1 and point 2.
            int adicent_side = point2.X - point1.X;
            // Calculete the distance between the Y points of point 1 and point 2.
            int opposite_side = point2.Y - point1.Y;

            // A square + B square = C square.
            double sloping_side = Math.Sqrt(adicent_side * adicent_side + opposite_side * opposite_side);

            double f = Math.Atan(opposite_side / adicent_side);

            f += Math.PI / 3;

            // Calculate the middle point thats between point 1 and point 2.
            int calculatedmiddle = (int)(sloping_side * Math.Cos(f));
            // Only works on streight lines.
            //int calculatedmiddle = adicent_side / 2;

            // Calculates the hight of the triangle.
            int calculatedheight = (int)(sloping_side * Math.Sin(f));
            // Only works on streight lines.
            //int calculatedheight = adicent_side;

            // Create the third point.
            // For the Y we need to subtract the calculated height from the point 1 Y so that the triangle will point upwards.
            // Handle downwards.
            Point point3 = new Point(point1.X + calculatedmiddle, point1.Y - calculatedheight);

            return point3;
        }
    }
}
