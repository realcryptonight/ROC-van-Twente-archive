using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boter_Kaas_en_Eieren
{
    class CheckForWin
    {
        /// <summary>
        /// Check if an player wins from left to right.
        /// (Scales with field size.)
        /// </summary>
        /// <param name="buttons">Button array of the fild</param>
        /// <param name="n">Fild size (Only square allowed)</param>
        /// <returns>true if wins or false if lose.</returns>
        /// <algorithm>
        /// Start left and goes right untill there are as many buttons as defind in n
        /// if the next button is the same as the first one.
        /// When n has been reached it goes one down and start again at the left.
        /// </algorithm>
        public static bool checkLeftToRight(Button[,] buttons, int n) {
            bool win = true;
            for (int r = 0; r < n; r++)
            {
                win = true;
                if (buttons[0, r].Text == "")
                {
                    win=false;
                }
                else
                {
                    for (int c = 1; c < n; c++)
                    {
                        if (buttons[0, r].Text != buttons[c, r].Text)
                        {
                            win = false;
                            break;
                        }
                    }
                }
                if (win) return true;
            }
            return false;
        }

        /// <summary>
        /// Check if an player wins from top to bottom.
        /// (Scales with field size.)
        /// </summary>
        /// <param name="buttons">Button array of the fild</param>
        /// <param name="n">Fild size (Only square allowed)</param>
        /// <returns>true if wins or false if lose.</returns>
        /// <algorithm>
        /// Start from the top and goes down untill there are as many buttons as defind in n
        /// if the next button is the same as the first one.
        /// When n has been reached it goes one right and start again at the top.
        /// </algorithm>
        public static bool checkTopToBottom(Button[,] buttons, int n) {
            bool win = true;
            for (int r = 0; r < n; r++)
            {
                win = true;
                if (buttons[r, 0].Text == "")
                {
                    win = false;
                }
                else
                {
                    for (int c = 1; c < n; c++)
                    {
                        if (buttons[r, 0].Text != buttons[r, c].Text)
                        {
                            win = false;
                            break;
                        }
                    }
                }
                if (win) return true;
            }
            return false;
        }

        /// <summary>
        /// Check if an player wins from left going down across.
        /// (Scales with field size.)
        /// </summary>
        /// <param name="buttons">Button array of the fild</param>
        /// <param name="n">Fild size (Only square allowed)</param>
        /// <returns>true if wins or false if lose.</returns>
        /// <algorithm>
        /// Start left at the top and goes one right and one down untill it has reachted n
        /// if the next button is the same as the first one.
        /// </algorithm>
        public static bool leftAcross(Button[,] buttons, int n) {
            bool win = true;
            if (buttons[0, 0].Text != "")
            {
                for (int i = 1; i < n; i++)
                {
                    if (buttons[0, 0].Text != buttons[i, i].Text) win = false;
                }
            }
            else {
                win = false;
            }
            return win;
        }

        /// <summary>
        /// Check if an player wins from right going down across.
        /// (Scales with field size.)
        /// </summary>
        /// <param name="buttons">Button array of the fild</param>
        /// <param name="n">Fild size (Only square allowed)</param>
        /// <returns>true if wins or false if lose.</returns>
        /// <algorithm>
        /// Start right at the top and goes one left and one down untill it has reachted n
        /// if the next button is the same as the first one.
        /// </algorithm>
        public static bool rightAcross(Button[,] buttons, int n)
        {
            bool win = true;
            if (buttons[0, n - 1].Text != "")
            {
                for (int i = 1; i < n; i++)
                {
                        if (buttons[0, n-1].Text != buttons[i, n-1-i].Text) win = false;
                }
            }
            else
            {
                win = false;
            }
            return win;
        }
    }
}
