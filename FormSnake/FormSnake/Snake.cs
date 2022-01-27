using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSnake
{
    public class Snake
    {
        /// <summary>
        /// Main entry to the classes.
        /// Used to setup the variables in the classes that should not have an default.
        /// </summary>
        /// <param name="color">The color of the snake.</param>
        /// <param name="head">The location of the head of the snake. KEEP 2 BLOCKS FREE FROM HEAD.</param>
        /// <param name="keys">The keyboard controls. 0 = up, 1 = down, 2 = left, 3 = right.</param>
        /// <exception cref="FormatException">Get thrown when the Char array for the keyboard is not the right size.</exception>
        public Snake(Color color, Point head, Char[] keys) {
            snakecolor = color;
            snakehead = head;
            if (keys.Length == 4)
            {
                snakecontrols = keys;
            }
            else {
                throw new FormatException("Keyboard controls not in the right format.");
            }
        }
        /// <summary>
        /// The location of the head of the snake.
        /// </summary>
        public Point snakehead;

        /// <summary>
        /// The previus location of the snake head.
        /// </summary>
        public Point oldsnakehead;

        /// <summary>
        /// The current size of the snake.
        /// </summary>
        public int snakesize = 3;

        /// <summary>
        /// The keyboad controls for the snake.
        /// Char array layout:
        ///     1: up
        ///     2: down
        ///     3: left
        ///     4: right
        /// </summary>
        public Char[] snakecontrols;

        /// <summary>
        /// An Sorted array to store all the bodies of the snake and save the point as an value.
        /// This will be used to store any snake bodies for when the snake needs to be updated.
        /// </summary>
        public SortedList<int, Point> bodypositions = new SortedList<int, Point> { };

        /// <summary>
        /// Tells if the snake alread died or if it it still alive.
        /// </summary>
        public bool snakeisdead = false;

        /// <summary>
        /// The color of the snake.
        /// </summary>
        public Color snakecolor;

        /// <summary>
        /// The direction for the snake to go to on its next move.
        /// 0 = up
        /// 1 = down
        /// 2 = left
        /// 3 = right
        /// </summary>
        public int direction = 3;
    }
}
