using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubbly_Linked_List
{
    internal class node
    {
        // The value of the newnode itself.
        int value;

        // The previous note object and the next newnode object.
        node previous, next;

        // THe start and the end of the doubly linked list.
        static node start, end;
        static int size = 0;


        /// <summary>
        /// Create an newnode object and add it to the sorted lists if there is one.
        /// </summary>
        /// <algo>
        /// First check if there is no node. (node.start is null)
        ///     if no node is present:
        ///         Then make the start and end variable the newly created node.
        ///     else
        ///         Continue checking.
        ///
        /// Then check if the value of the new node is less then or equal to the value of the start node.
        ///     if the new node value is less then or equal to the node value of start:
        ///         Point the start.previous variable to the newly create node variable.
        ///         Point the newly created node.next variable to start.previous variable.
        ///         Update the start variable with the newly create node.
        ///     else
        ///         Continue checking
        /// 
        /// Then check if the value of the new node is greater then or equal to the value of the end node.
        ///     if the new node value is greater then or equal to the node value of end:
        ///         Point the end.next variable to the newly create node variable.
        ///         Point the newly created node.previous variable to end.next variable.
        ///         Update the end variable with the newly create node.
        ///     else
        ///         Continue checking
        /// 
        /// If it is still checking then that means it is in between two nodes.
        /// Create a variable that has the start value of the nodes.
        /// Keep looping trought the nodes with the next node untill the new node is smaller then the next one.
        /// Now we know the possition of the greater node. But we need the possition of the node before the one that is bigger.
        /// So move one back.
        ///     Point the newly created node.next variable to the current.next variable.
        ///     Point the newly created node.previous variable to the current variable.
        ///     Update the current.next variable to the newly created node variable.
        /// </algo>
        /// <param name="newnodevalue">The value of the newnode.</param>
        internal static void addnode(int value)
        { 
            node newnode = new node();
            newnode.value = value;

            if (node.start == null)
            {
                node.start = newnode;
                node.end = newnode;
            }
            else
            {
                // If the new newnode value is less then the existing newnode value then it needs to become the start.
                if (newnode.value <= node.start.value)
                {
                    node.start.previous = newnode;
                    newnode.next = node.start;
                    node.start = newnode;
                }
                else
                {
                    if (newnode.value >= node.end.value)
                    {
                        newnode.previous = node.end;
                        node.end.next = newnode;
                        node.end = newnode;
                    }
                    else
                    {
                        node current = node.start;
                        while (current.value < newnode.value)
                        {
                            current = current.next;
                        }
                        current = current.previous;

                        newnode.next = current.next;
                        newnode.previous = current;
                        current.next = newnode;
                    }
                }
            }
            node.size++;
        }
    }
}
