using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace palindromic_number
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Find the largest palindrome made from the product of two 3-digit numbers.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Start the checkforheighestpalindromic() function in the Calculate class.
        /// </summary>
        private void start_Click(object sender, EventArgs e)
        {
            start.Enabled = false;
            Calculate.checkforheighestpalindromic(100000, 999999);
        }

        /// <summary>
        /// Log messages to the console textbox.
        /// </summary>
        /// <param name="message">The message that needs to be logged into the console textbox.</param>
        public void consolelog(string message) {
            consoleoutput.Text = message + System.Environment.NewLine + consoleoutput.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Calculate.form = this;
        }
    }
}
