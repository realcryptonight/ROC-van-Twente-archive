using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace palindromic_number__Try_2_
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Find the largest possible palindrome made from an two 3-digit numbers.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button to check for the heighst possible 2 three digit.
        /// </summary>
        private void start_Click(object sender, EventArgs e)
        {
            int first = 0;
            int second = 0;
            int endresult = 0;
            for (int i = 100; i < 1000; i++)
            {
                for (int i2 = 100; i2 < 1000; i2++)
                {
                    int result = i * i2;
                    bool ispalindromic = true;
                    string intstring = result.ToString();
                    for (int i3 = 0; i3 < intstring.Length / 2; i3++)
                    {
                        if (intstring[i3] != intstring[intstring.Length - i3 - 1])
                        {
                            ispalindromic = false;
                        }
                    }
                    if (ispalindromic && result > endresult)
                    {
                        first = i;
                        second = i2;
                        endresult = result;
                    }
                }
            }
            MessageBox.Show("Heighest: " + first + "x" + second);
        }
    }
}
