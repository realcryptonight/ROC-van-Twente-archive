 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snowflake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Draw the first stage of snowflake.
        /// </summary>
        /// <algo>
        /// First create 2 random point that create a streight line.
        /// Then give the 2 points to the createTriangle to get the 3rd point.
        /// 
        /// Now add each point in an node and link them from first point to last point.
        /// And lastly draw the nodes list from node to node.
        /// </algo>
        private void start1_Click(object sender, EventArgs e)
        {
            Point point1 = new Point(350, 350);
            Point point2 = new Point(550, 350);
            Point point3 = Functions.createTriangle(point1, point2);

            nodes allnodes = new nodes();

            node node1 = new node(point1);
            node node2 = new node(point2);
            node1.next = node2;
            node2.previous = node1;
            node node3 = new node(point3);
            node2.next = node3;
            node3.previous = node2;

            allnodes.start = node1;
            allnodes.end = node1.next.next;
            allnodes.size += 3;
            
            Draw.DrawFlake(allnodes);
        }

        /// <summary>
        /// Make sure that the Draw class has an instance of the form.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            Draw.form = this;
        }

        /// <summary>
        /// Draw the second stage of snowflake.
        /// </summary>
        /// <algo>
        /// First create 2 random point that create a streight line.
        /// Then give the 2 points to the createTriangle to get the 3rd point.
        /// 
        /// Then calculate the length of the line based on the Xs of the first and the second point. (lenth)
        /// Then we know where the middle point is of that line. (1/2 of the length). (pointmiddle_bottom)
        /// 
        /// And then we can calculate the height. (The Y value of the middle point - The Y value of the 3rd point.)
        /// And we need to know 2/3 of the height for the sloping side. (calculate)
        /// 
        /// Then we create a point on 1/3 of the first part of the line.
        /// Then we create a point on 2/3 of the first part of the line.
        /// And then we can create the third point. (pointmiddle_bottom.X, pointmiddle_bottom.Y + calculate / 2)
        /// 
        /// And repeat this now for the rest of the lines.
        /// 
        /// Now add each point in an node and link them from first point to last point.
        /// Then add every three point of the triangle thats between the line between the two line points.
        /// 
        /// And lastly draw the nodes list from node to node.
        /// </algo>
        private void start2_Click(object sender, EventArgs e)
        {
            Point point1 = new Point(350, 350);
            Point point2 = new Point(550, 350);
            Point point3 = Functions.createTriangle(point1, point2);
            int lenth = point2.X - point1.X;
            Point pointmiddle_bottom = new Point(point1.X + lenth / 2, point1.Y);
            int height = pointmiddle_bottom.Y - point3.Y;
            int calculate = height / 3 * 2;
            Point point11 = new Point(point1.X + (lenth / 3), point1.Y);
            Point point12 = new Point(pointmiddle_bottom.X, pointmiddle_bottom.Y + calculate / 2);
            Point point13 = new Point(point1.X + ((lenth / 3) * 2), point1.Y);
            Point point21 = Functions.createTriangle(point13, point2);
            Point point22 = new Point(point2.X, point2.Y - calculate);
            Point point23 = new Point(point13.X, point13.Y - calculate);
            Point point31 = new Point(point11.X, point11.Y - calculate);
            Point point32 = new Point(point1.X, point1.Y - calculate);
            Point point33 = Functions.createTriangle(point1, point11);

            nodes allnodes = new nodes();
            node node1 = new node(point1);
            node node2 = new node(point2);
            node1.next = node2;
            node2.previous = node1;
            node node3 = new node(point3);
            node2.next = node3;
            node3.previous = node2;

            allnodes.start = node1;
            allnodes.end = node1.next.next;
            allnodes.size += 3;

            int i = 0;
            node current = allnodes.start;
            while (i != 3)
            {
                node currentnext = current.next;
                if (i == 0)
                {
                    node newnode1 = new node(point11);
                    node newnode2 = new node(point12);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point13);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;

                }
                if (i == 1)
                {
                    node newnode1 = new node(point21);
                    node newnode2 = new node(point22);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point23);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;
                }
                if (i == 2)
                {
                    node newnode1 = new node(point31);
                    node newnode2 = new node(point32);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point33);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    newnode3.next = currentnext;
                    allnodes.end = newnode3;
                    allnodes.size += 3;
                }
                current = currentnext;
                i++;
            }

            Draw.DrawFlake(allnodes);
        }

        /// <summary>
        /// Draw the third stage of snowflake.
        /// </summary>
        /// <algo>
        /// First create 2 random point that create a streight line.
        /// Then give the 2 points to the createTriangle to get the 3rd point.
        /// 
        /// Then calculate the length of the line based on the Xs of the first and the second point. (lenth)
        /// Then we know where the middle point is of that line. (1/2 of the length). (pointmiddle_bottom)
        /// 
        /// And then we can calculate the height. (The Y value of the middle point - The Y value of the 3rd point.)
        /// And we need to know 2/3 of the height for the sloping side. (calculate)
        /// 
        /// Then we create a point on 1/3 of the first part of the line.
        /// Then we create a point on 2/3 of the first part of the line.
        /// And then we can create the third point. (pointmiddle_bottom.X, pointmiddle_bottom.Y + calculate / 2)
        /// 
        /// And repeat this now for the rest of the lines.
        /// And then do this for all lines again.
        /// 
        /// Now add each point in an node and link them from first point to last point.
        /// Then add every three point of the triangle thats between the line between the two line points.
        /// 
        /// And lastly draw the nodes list from node to node.
        /// </algo>
        private void start3_Click(object sender, EventArgs e)
        {
            Point point1 = new Point(350, 350);
            Point point2 = new Point(550, 350);
            Point point3 = Functions.createTriangle(point1, point2);
            int lenth = point2.X - point1.X;
            Point pointmiddle_bottom = new Point(point1.X + lenth / 2, point1.Y);
            Point pointmiddle_bottom2 = new Point(point1.X + lenth / 6, point1.Y);
            int height = pointmiddle_bottom.Y - point3.Y;
            int calculate = height / 3 * 2;
            int snow3length = lenth / 3 / 3;
            Point point11 = new Point(point1.X + (lenth / 3), point1.Y);
            Point point111 = new Point(point1.X + snow3length, point1.Y);
            Point point112 = new Point(point111.X + snow3length / 2, point11.Y + snow3length);
            Point point113 = new Point(point111.X + snow3length, point111.Y);
            Point point12 = new Point(pointmiddle_bottom.X, pointmiddle_bottom.Y + calculate / 2);
            Point point121 = new Point(point11.X + snow3length / 3 * 2, point11.Y + snow3length);
            Point point122 = new Point(point11.X, pointmiddle_bottom2.Y + calculate / 3);
            Point point123 = new Point(point12.X - snow3length / 3 * 2, point12.Y - snow3length);
            Point point124 = new Point(point12.X + snow3length / 3 * 2, point12.Y - snow3length);
            Point point13 = new Point(point1.X + ((lenth / 3) * 2), point1.Y);
            Point point125 = new Point(point13.X, pointmiddle_bottom2.Y + calculate / 3);
            Point point126 = new Point(point13.X - snow3length / 3 * 2, point13.Y + snow3length);
            Point point131 = new Point(point13.X + snow3length, point1.Y);
            Point point132 = new Point(point131.X + snow3length / 2, point13.Y + snow3length);
            Point point133 = new Point(point131.X + snow3length, point111.Y);
            Point point21 = Functions.createTriangle(point13, point2);
            Point point211 = new Point(point2.X - snow3length /3 * 2, point1.Y - snow3length);
            Point point212 = new Point(point2.X, pointmiddle_bottom2.Y - calculate / 3);
            Point point213 = new Point(point21.X + snow3length /3, point21.Y + snow3length / 3 * 2);
            Point point22 = new Point(point2.X, point2.Y - calculate);
            Point point221 = new Point(point21.X + snow3length / 3 * 2, point21.Y - snow3length);
            Point point222 = new Point(point22.X, pointmiddle_bottom2.Y - calculate / 3 * 2);
            Point point223 = new Point(point22.X - snow3length / 3, point22.Y + snow3length / 3 * 2);
            Point point224 = new Point(point22.X - snow3length, point22.Y);
            Point point23 = new Point(point13.X, point13.Y - calculate);
            Point point225 = new Point(point224.X - snow3length / 2, point22.Y - snow3length);
            Point point226 = new Point(point22.X - snow3length * 2, point22.Y);
            Point point231 = new Point(point23.X - snow3length / 3 * 2, point23.Y - snow3length);
            Point point232 = new Point(point23.X, point23.Y - calculate / 3);
            Point point233 = new Point(point3.X + snow3length / 3, point3.Y + snow3length / 3 * 2);
            Point point31 = new Point(point11.X, point11.Y - calculate);
            Point point311 = new Point(point3.X - snow3length / 3, point3.Y + snow3length / 3 * 2);
            Point point312 = new Point(point31.X, point31.Y - calculate / 3);
            Point point313 = new Point(point31.X + snow3length / 3 * 2, point31.Y - snow3length);
            Point point32 = new Point(point1.X, point1.Y - calculate);
            Point point321 = new Point(point31.X - snow3length, point31.Y);
            Point point322 = new Point(point321.X - snow3length / 2, point321.Y - snow3length);
            Point point323 = new Point(point32.X + snow3length, point31.Y);
            Point point324 = new Point(point32.X + snow3length / 3, point32.Y + snow3length / 3 * 2);
            Point point33 = Functions.createTriangle(point1, point11);
            Point point325 = new Point(point32.X, pointmiddle_bottom2.Y - calculate / 3 * 2);
            Point point326 = new Point(point33.X - snow3length / 3 * 2, point33.Y - snow3length);
            Point point331 = new Point(point33.X - snow3length / 3, point33.Y + snow3length / 3 * 2);
            Point point332 = new Point(point1.X, pointmiddle_bottom2.Y - calculate / 3);
            Point point333 = new Point(point1.X + snow3length / 3 * 2, point1.Y - snow3length);

            nodes allnodes = new nodes();
            node node1 = new node(point1);
            node node2 = new node(point2);
            node1.next = node2;
            node2.previous = node1;
            node node3 = new node(point3);
            node2.next = node3;
            node3.previous = node2;

            allnodes.start = node1;
            allnodes.end = node1.next.next;
            allnodes.size += 3;

            int i = 0;
            node current = allnodes.start;
            while (i != 3)
            {
                node currentnext = current.next;
                if (i == 0)
                {
                    node newnode1 = new node(point11);
                    node newnode2 = new node(point12);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point13);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;

                }
                if (i == 1)
                {
                    node newnode1 = new node(point21);
                    node newnode2 = new node(point22);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point23);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;
                }
                if (i == 2)
                {
                    node newnode1 = new node(point31);
                    node newnode2 = new node(point32);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point33);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    newnode3.next = currentnext;
                    allnodes.end = newnode3;
                    allnodes.size += 3;
                }
                current = currentnext;
                i++;
            }

            current = allnodes.start;
            int i2 = 0;
            while (i2 < 12)
            {
                node currentnext = current.next;
                if (i2 == 0)
                {
                    node newnode1 = new node(point111);
                    node newnode2 = new node(point112);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point113);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;

                }
                if (i2 == 1)
                {
                    node newnode1 = new node(point121);
                    node newnode2 = new node(point122);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point123);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;

                }
                if (i2 == 2)
                
                {
                    node newnode1 = new node(point124);
                    node newnode2 = new node(point125);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point126);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;

                }
                if (i2 == 3)
                {
                    node newnode1 = new node(point131);
                    node newnode2 = new node(point132);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point133);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;

                }
                if (i2 == 4)
                {
                    node newnode1 = new node(point211);
                    node newnode2 = new node(point212);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point213);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;

                }
                if (i2 == 5)
                {
                    node newnode1 = new node(point221);
                    node newnode2 = new node(point222);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point223);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;

                }
                if (i2 == 6)
                {
                    node newnode1 = new node(point224);
                    node newnode2 = new node(point225);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point226);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;

                }
                if (i2 == 7)
                {
                    node newnode1 = new node(point231);
                    node newnode2 = new node(point232);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point233);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;

                }
                if (i2 == 8)
                {
                    node newnode1 = new node(point311);
                    node newnode2 = new node(point312);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point313);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;

                }
                if (i2 == 9)
                {
                    node newnode1 = new node(point321);
                    node newnode2 = new node(point322);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point323);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;

                }
                if (i2 == 10)
                {
                    node newnode1 = new node(point324);
                    node newnode2 = new node(point325);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point326);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    currentnext.previous = newnode3;
                    newnode3.next = currentnext;
                    allnodes.size += 3;

                }
                
                if (i2 == 11)
                {
                    node newnode1 = new node(point331);
                    node newnode2 = new node(point332);
                    newnode1.next = newnode2;
                    newnode2.previous = newnode1;
                    node newnode3 = new node(point333);
                    newnode2.next = newnode3;
                    newnode3.previous = newnode2;

                    current.next = newnode1;
                    newnode1.previous = current;
                    newnode3.next = currentnext;
                    allnodes.end = newnode3;
                    allnodes.size += 3;

                }
                current = currentnext;
                i2++;
            }

            Draw.DrawFlake(allnodes);
        }
    }
}
