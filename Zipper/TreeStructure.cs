using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zipper
{
    internal class TreeStructure
    {
        /// <summary>
        /// The first leaf of the tree.
        /// </summary>
        public Leaf start;
        /// <summary>
        /// The last leaf of the tree.
        /// </summary>
        public Leaf end;
        /// <summary>
        /// The size of the tree itself.
        /// </summary>
        public int size = 0;

        /// <summary>
        /// Add the next leaf to the tree structure.
        /// </summary>
        /// <algo>
        /// If the tree does not contain a leaf then add the leaf to the start and end of the tree.
        /// If the tree does contain a leaf then add it to the end leaf and update the end of the tree.
        /// </algo>
        /// <param name="leaf">The Leaf itself.</param>
        public void addNextLeaf(Leaf leaf) {
            if (start == null)
            {
                start = leaf;
                end = leaf;
                size++;
            }
            else
            {
                leaf.Previous = end;
                end.Next = leaf;
                end = leaf;
                size++;
            }
        }

        /// <summary>
        /// Create a tree structure from linked leafs.
        /// </summary>
        /// <algo>
        /// If there are two leafs than add the two frequencies together and make an new leaf.
        /// Then add the leaf to the tree.
        /// And finally add the leafs to the left and right that where used to add the frequencies together.
        /// </algo>
        /// <param name="tree">The tree structure.</param>
        /// <returns>The tree structure.</returns>
        public TreeStructure getTreeStructe(TreeStructure tree)
        {
            while (tree.start.Next.Next != null)
            {
                Leaf newleaf = new Leaf(tree.start.frequency + tree.start.Next.frequency, 0);
                addleaf(newleaf, tree);
                newleaf.Left = tree.start.Next;
                newleaf.Right = tree.start;
                tree.start = tree.start.Next.Next;
            }
            if (tree.start.Next != null)
            {
                Leaf newleaf = new Leaf(tree.start.frequency + tree.start.Next.frequency, 0);
                addleaf(newleaf, tree);
                newleaf.Left = tree.start.Next;
                newleaf.Right = tree.start;
                tree.start = newleaf;
            }
            return tree;
        }

        /// <summary>
        /// Add a leaf to the tree in frequency order.
        /// </summary>
        /// <algo>
        /// First check if there is no tree. (tree.start is null)
        ///     if no tree is present:
        ///         Then make the start and end variable the newly created tree.
        ///     else
        ///         Continue checking.
        ///
        /// Then check if the frequency of the new tree is less then or equal to the frequency of the start tree.
        ///     if the new tree frequency is less then or equal to the tree frequency of start:
        ///         Point the start.previous variable to the newly create tree variable.
        ///         Point the newly created tree.next variable to start.previous variable.
        ///         Update the start variable with the newly create tree.
        ///     else
        ///         Continue checking
        /// 
        /// Then check if the frequency of the new tree is greater then or equal to the frequency of the end tree.
        ///     if the new tree frequency is greater then or equal to the tree frequency of end:
        ///         Point the end.next variable to the newly create tree variable.
        ///         Point the newly created tree.previous variable to end.next variable.
        ///         Update the end variable with the newly create tree.
        ///     else
        ///         Continue checking
        /// 
        /// If it is still checking then that means it is in between two trees.
        /// Create a variable that has the start frequency of the trees.
        /// Keep looping trought the trees with the next tree untill the new tree is smaller then the next one.
        /// Now we know the possition of the greater tree. But we need the possition of the tree before the one that is bigger.
        /// So move one back.
        ///     Point the newly created tree.next variable to the current.next variable.
        ///     Point the newly created tree.previous variable to the current variable.
        ///     Update the current.next variable to the newly created tree variable.
        /// </algo>
        /// <param name="leaf">The leaf that needs to be added.</param>
        /// <param name="tree">The tree that the leaf will be added to.</param>
        internal void addleaf(Leaf leaf, TreeStructure tree)
        {
            if (tree.start == null)
            {
                tree.start = leaf;
                tree.end = leaf;
            }
            else
            {
                // If the new leaf frequency is less then the existing leaf frequency then it needs to become the start.
                if (leaf.frequency <= tree.start.frequency)
                {
                    tree.start.Previous = leaf;
                    leaf.Next = tree.start;
                    tree.start = leaf;
                }
                else
                {
                    if (leaf.frequency > tree.end.frequency)
                    {
                        leaf.Previous = tree.end;
                        tree.end.Next = leaf;
                        tree.end = leaf;
                    }
                    else
                    {
                        Leaf current = tree.start;
                        while (current.frequency < leaf.frequency)
                        {
                            current = current.Next;
                        }
                        leaf.Previous = current.Previous;
                        leaf.Next = current;
                        current.Previous.Next = leaf;
                        current.Previous = leaf;
                    }
                }
            }
            tree.size++;
        }
    }

    internal class Leaf
    {
        /// <summary>
        /// The previous leaf.
        /// </summary>
        public Leaf Previous;
        /// <summary>
        /// The next leaf.
        /// </summary>
        public Leaf Next;
        /// <summary>
        /// The left leaf.
        /// </summary>
        public Leaf Left;
        /// <summary>
        /// The right leaf.
        /// </summary>
        public Leaf Right;
        /// <summary>
        /// The frequency of the leaf.
        /// </summary>
        public uint frequency;

        /// <summary>
        /// The byte value that the leaf represents.
        /// </summary>
        public byte bytevalue;

        /// <summary>
        /// Create a new Leaf.
        /// </summary>
        /// <param name="inputfrequency">The frequency of the Leaf</param>
        /// <param name="inputbytevalue">The byte the leaf represents.</param>
        public Leaf(uint inputfrequency, byte inputbytevalue) {
            frequency = inputfrequency;
            bytevalue = inputbytevalue;
        }
    }
}
