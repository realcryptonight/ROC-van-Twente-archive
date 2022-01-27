using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boter_Kaas_en_Eieren
{
    class functions
    {
        /// <summary>
        /// Button array for access to the buttons on the form.
        /// </summary>
        public static Button[,] buttons;

        /// <summary>
        /// Determins if it needs to play sound 1 or sound 2.
        /// </summary>
        static bool soundoption = true;

        /// <summary>
        /// The size of the playing field.
        /// </summary>
        static int n = 0;

        /// <summary>
        /// Generate an button gride.
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
                    buttons[r,c].Location = new Point(c*w/n, r*h/n);
                    buttons[r,c].Size = new Size(w/n, h/n);
                    buttons[r,c].Name = "Tile";
                    buttons[r, c].Click += Tile_Click;
                    buttons[r, c].Font = new Font("Microsoft Sans Serif", 50.50F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    f.Controls.Add(buttons[r,c]);
                }
            }
        }

        /// <summary>
        /// Handler for the player choise and check if an player has won with the choise.
        /// NOTE: Handler does trigger the "haswon" function for checking if the player has won.
        ///       Meaning it does not do the checking in this handler but calls an funion for it.
        /// </summary>
        /// <seealso cref="haswon"/>
        /// <seealso cref="general"/>
        /// <seealso cref="resetgame"/>
        /// <param name="sender">The sender of the event. (Only button possible)</param>
        private static void Tile_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "X" || b.Text == "O") {
                if (soundoption)
                {
                    SoundPlayer audioplayer = new SoundPlayer();
                    audioplayer.Stream = Properties.Resources.used1;
                    audioplayer.Play();
                    soundoption = false;
                }
                else
                {
                    SoundPlayer audioplayer = new SoundPlayer();
                    audioplayer.Stream = Properties.Resources.used2;
                    audioplayer.Play();
                    soundoption = true;
                }
                MessageBox.Show("This tile is already taken!");
                return;
            }
            if (general.player)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            general.clickcount++;
            if (haswon())
            {
                SoundPlayer audioplayer = new SoundPlayer();
                audioplayer.Stream = Properties.Resources.won;
                audioplayer.Play();
                if (general.player) 
                {
                    MessageBox.Show("x wins");
                } 
                else 
                {
                    MessageBox.Show("o wins");
                }
                resetgame(n);
                return;
            }
            if (general.clickcount == n*n) {
                MessageBox.Show("No winner.");
                resetgame(n);
            }
            
            general.player = !general.player;
        }

        /// <summary>
        /// Check if an player has won.
        /// </summary>
        /// <returns>false if no one has won || true if an player wins</returns>
        /// <seealso cref="CheckForWin"/>
        public static bool haswon() {
            bool win = false;
            if (CheckForWin.checkLeftToRight(buttons, n)) win = true;
            if (CheckForWin.checkTopToBottom(buttons, n)) win = true;
            if (CheckForWin.leftAcross(buttons, n)) win = true;
            if (CheckForWin.rightAcross(buttons, n)) win = true;
            return win;
        }

        /// <summary>
        /// Reset the game to the original state.
        /// </summary>
        /// <algorithm>
        /// Start from left and go to the right.
        /// When it can not go anymore to the right go one down and start on the left again.
        /// </algorithm>
        /// <seealso cref="general"/>
        public static void resetgame(int size) {
            general.player = true;
            general.clickcount = 0;
            for (int i = 0; i < size; i++)
            {
                for (int z = 0; z < size; z++)
                {
                    buttons[i, z].Text = "";
                }
            }
        }
    }
}
