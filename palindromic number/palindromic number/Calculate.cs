using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace palindromic_number
{
    class Calculate
    {
        public static Form1 form;
        /// <summary>
        /// Check for the heighest palindromic.
        /// </summary>
        /// <algo>
        /// Fist check it it is an palindromic.
        /// And if it is check if it is the heighest amount.
        /// </algo>
        /// <param name="min">The minimum amount to start from.</param>
        /// <param name="max">The maximum amount to stop at.</param>
        public static void checkforheighestpalindromic(int min, int max) {
            form.consolelog("Starting to calculate.");
            int amount = max - min;
            int heighest = min;

            for (int i = min; i < max + 1; i++)
            {
                bool ispalindromic = true;
                int intsize = i.ToString().Length / 2;
                string intstring = i.ToString();
                for (int i2 = 0; i2 < intsize; i2++)
                {
                    //if (intstring[i2] != intstring[intstring.Length - i2])
                    //if (intstring[0] != intstring[5] || intstring[1] != intstring[4] || intstring[2] != intstring[3])
                    /*if (i2 == 0)
                    {
                        if (intstring[i2] != intstring[intstring.Length - 1])
                        {
                            ispalindromic = false;
                        }
                    }
                    else 
                    {
                        if (intstring[i2] != intstring[intstring.Length - i2 - 1])
                        {
                            ispalindromic = false;
                        }
                    }
                    */
                    if (intstring[i2] != intstring[intstring.Length - i2 - 1]) {
                        ispalindromic = false;
                    }
                }
                if (ispalindromic && i > heighest) {
                    heighest = i;
                }
            }
            form.consolelog("Heigest palindromic: " + heighest);
            form.start.Enabled = true;
        }
    }
}
