using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDI
{
    public partial class opgave2 : Form
    {
        public opgave2()
        {
            InitializeComponent();
        }

        Timer timer = new Timer();

        /// <summary>
        /// This will start the proccess of outputting the input text.
        /// It first makes sure that the output text is empty and sets the correct font.
        /// It then set the timer to trigger the updateLetter every 200ms.
        /// </summary>
        private void letter_for_letter_Click(object sender, EventArgs e)
        {
            input.Enabled = false;
            output.Text = null;
            output.Font = new Font("Arial", 12, FontStyle.Bold);
            if (input.Text != null && input.Text != "")
            {
                timer.Interval = (200) * (1);
                timer.Start();
                timer.Tick += updateLetter;
            }
        }

        /// <summary>
        /// This will put every letter (one by one) from the input to the output textbox.
        /// This needs to be triggered by a timer on 200ms.
        /// </summary>
        private void updateLetter(object sender, EventArgs e)
        {
            int pos = output.Text.Length;
            if (input.Text.Length == pos)
            {
                timer.Stop();
                input.Enabled = true;
            }
            else
            {
                if (pos % 5 == 0) { output.Font = new Font("Arial", output.Font.Size + 1, FontStyle.Bold); }
                output.Text += input.Text[pos];
            }
        }
    }
}
