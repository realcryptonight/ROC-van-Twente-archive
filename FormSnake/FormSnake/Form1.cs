using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormSnake
{
    public partial class Form1 : Form
    {
        private static int levelsize = 10;
        public static SortedList<int, Snake> snakes = new SortedList<int, Snake> { };
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        /// <summary>
        /// Main timer to trigger the update funtion.
        /// </summary>
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            functions.update(this, snakes);
        }

        /// <summary>
        /// Add an new snake to the snakes array.
        /// </summary>
        /// <param name="color">The color that the snake sould be.</param>
        /// <param name="keys">The keyboard keys that are gone be used to control the snake.</param>
        /// <param name="startpoint">The start point of the snake. (Head location) Please make sure the location is free.</param>
        private static void addSnake(Color color, Char[] keys, Point startpoint) {
            int currentsnakes = snakes.Count;
            snakes.Add(currentsnakes + 1, new Snake(color, startpoint, keys));
        }

        /// <summary>
        /// Button to set the level to easy.
        /// This will generate an field of 10x10
        /// </summary>
        private void leveleasy_Click(object sender, EventArgs e)
        {
            levelsize = 10;
            level.Text = "Easy";
            level.BackColor = Color.Green;
            level.FlatAppearance.MouseOverBackColor = Color.Green;
            level.FlatAppearance.MouseDownBackColor = Color.Green;
        }

        /// <summary>
        /// Button to set the level to medium.
        /// This will generate an field of 25x25
        /// </summary>
        private void levelmedium_Click(object sender, EventArgs e)
        {
            levelsize = 25;
            level.Text = "Medium";
            level.BackColor = Color.Orange;
            level.FlatAppearance.MouseOverBackColor = Color.Orange;
            level.FlatAppearance.MouseDownBackColor = Color.Orange;
        }

        /// <summary>
        /// Button to set the level to hard.
        /// This will generate an field of 50x50
        /// </summary>
        private void levelhard_Click(object sender, EventArgs e)
        {
            levelsize = 50;
            level.Text = "Hard";
            level.BackColor = Color.Red;
            level.FlatAppearance.MouseOverBackColor = Color.Red;
            level.FlatAppearance.MouseDownBackColor = Color.Red;
        }

        /// <summary>
        /// Button to start the snake game.
        /// </summary>
        private void start_Click(object sender, EventArgs e)
        {
            leveleasy.Visible = false;
            levelmedium.Visible = false;
            levelhard.Visible = false;
            level.Visible = false;
            start.Visible = false;
            functions.generatebuttons(levelsize, this);
            addSnake(Color.Green, new char[] { 'w', 's', 'a', 'd' }, new Point(0,3));
            addSnake(Color.Purple, new char[] { 'i', 'k', 'j', 'l' }, new Point(2,3));
            functions.update(this, snakes);
            updateTimer.Start();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 1; i < snakes.Count + 1; i++)
            {
                Snake snake = snakes[i];
                if (snake.snakecontrols.Contains(e.KeyChar)) {
                    if (e.KeyChar == snake.snakecontrols[0]) {
                        snake.direction = 0;
                    }
                    if (e.KeyChar == snake.snakecontrols[1])
                    {
                        snake.direction = 1;
                    }
                    if (e.KeyChar == snake.snakecontrols[2])
                    {
                        snake.direction = 2;
                    }
                    if (e.KeyChar == snake.snakecontrols[3])
                    {
                        snake.direction = 3;
                    }
                }
            }
        }
    }
}
