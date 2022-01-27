using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowflake
{
    public class node
    {
        // The value of the newnode itself.
        public Point value;

        // The previous note object and the next newnode object.
        public node previous, next;

        /// <summary>
        /// Allow the user to easily add a point value to the nodes.
        /// </summary>
        /// <param name="nodevalue">The point that needs to be in the node.</param>
        public node(Point nodevalue) {
            value = nodevalue;
        }
    }

    public class nodes {
        // Keep track of the start and the end of the node list.
        public node start, end;
        // Keep track if the total size of the list.
        public int size = 0;
    }
}
