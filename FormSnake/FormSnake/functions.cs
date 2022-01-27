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
    class functions
    {
        /// <summary>
        /// Button array for access to the buttons on the form.
        /// </summary>
        public static Button[,] buttons;

        /// <summary>
        /// The size of the playing field.
        /// </summary>
        static int n = 0;

        /// <summary>
        /// Generate an button field.
        /// </summary>
        /// <param name="f">Instance of the form you want the buttons on.</param>
        /// <param name="size">The size of the playing field.</param>
        /// <algorithm>
        /// Start left and go right untill there are as many buttons as defind in size.
        /// When size has been reached it goes one down and start again at the left.
        /// </algorithm>
        public static void generatebuttons(int size, Form f)
        {
            n = size;
            int w = f.ClientSize.Width;
            int h = f.ClientSize.Height;
            buttons = new Button[n, n];
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    buttons[r, c] = new Button();
                    buttons[r, c].Location = new Point(c * w / n, r * h / n);
                    buttons[r, c].Size = new Size(w / n, h / n);
                    buttons[r, c].Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    buttons[r, c].BackColor = f.BackColor;
                    buttons[r, c].FlatStyle = FlatStyle.Flat;
                    buttons[r, c].FlatAppearance.BorderSize = 0;
                    buttons[r, c].FlatAppearance.MouseOverBackColor = f.BackColor;
                    buttons[r, c].FlatAppearance.MouseDownBackColor = f.BackColor;
                    f.Controls.Add(buttons[r, c]);
                }
            }
        }

        /// <summary>
        /// Allows the playing field to update to the next move.
        /// It will move all snakes to the next position and check if it hit an level up.
        /// </summary>
        /// <param name="f">The form that is used for the snake grid.</param>
        /// <param name="snakes">The SortedList of snakes that are created.</param>
        public static void update(Form f, SortedList<int, Snake> snakes) {
            for (int snakei = 0; snakei < snakes.Count; snakei++)
            {
                Snake snake = snakes[snakei + 1];
                // Check if snake is on the field.
                if (buttons[snake.snakehead.X, snake.snakehead.Y].BackColor != snake.snakecolor && buttons[snake.snakehead.X, snake.snakehead.Y].BackColor == f.BackColor)
                {
                    // Add snake to field
                    for (int i = 0; i < snake.snakesize; i++)
                    {
                        buttons[snake.snakehead.X, snake.snakehead.Y - i].BackColor = snake.snakecolor;
                        buttons[snake.snakehead.X, snake.snakehead.Y - i].FlatAppearance.MouseOverBackColor = snake.snakecolor;
                        buttons[snake.snakehead.X, snake.snakehead.Y - i].FlatAppearance.MouseDownBackColor = snake.snakecolor;
                        snake.bodypositions[i] = new Point(snake.snakehead.X, snake.snakehead.Y - i);
                    }
                }
                else
                {
                    // Main update locgic to let the snake move around.
                    snake.oldsnakehead = snake.snakehead;
                    if (snake.direction == 0)
                    {
                        snake.snakehead = new Point(snake.snakehead.X - 1, snake.snakehead.Y);
                    }
                    if (snake.direction == 1)
                    {
                        snake.snakehead = new Point(snake.snakehead.X + 1, snake.snakehead.Y);
                    }
                    if (snake.direction == 2)
                    {
                        snake.snakehead = new Point(snake.snakehead.X, snake.snakehead.Y - 1);
                    }
                    if (snake.direction == 3)
                    {
                        snake.snakehead = new Point(snake.snakehead.X, snake.snakehead.Y + 1);
                    }
                    for (int i = 0; i < snake.bodypositions.Count; i++)
                    {
                        snake.bodypositions[0] = snake.oldsnakehead;
                        if (i == 0)
                        {
                            buttons[snake.snakehead.X, snake.snakehead.Y].BackColor = snake.snakecolor;
                            buttons[snake.snakehead.X, snake.snakehead.Y].FlatAppearance.MouseOverBackColor = snake.snakecolor;
                            buttons[snake.snakehead.X, snake.snakehead.Y].FlatAppearance.MouseDownBackColor = snake.snakecolor;
                        }
                        else {
                            buttons[snake.bodypositions[i - 1].X, snake.bodypositions[i - 1].Y].BackColor = snake.snakecolor;
                            buttons[snake.bodypositions[i - 1].X, snake.bodypositions[i - 1].Y].FlatAppearance.MouseOverBackColor = snake.snakecolor;
                            buttons[snake.bodypositions[i - 1].X, snake.bodypositions[i - 1].Y].FlatAppearance.MouseDownBackColor = snake.snakecolor;
                            if (i == snake.snakesize - 1) {
                                buttons[snake.bodypositions[i].X, snake.bodypositions[i].Y].BackColor = f.BackColor;
                                buttons[snake.bodypositions[i].X, snake.bodypositions[i].Y].FlatAppearance.MouseOverBackColor = f.BackColor;
                                buttons[snake.bodypositions[i].X, snake.bodypositions[i].Y].FlatAppearance.MouseDownBackColor = f.BackColor;
                            }
                            snake.bodypositions[i] = new Point(snake.bodypositions[i - 1].X, snake.bodypositions[i - 1].Y);
                        }
                    }
                }
            }
        }
    }
}
