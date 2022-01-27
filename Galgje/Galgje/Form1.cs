using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galgje
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Main form.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            update(Logic.word, null);
        }

        /// <summary>
        /// Button to trigger the gues check triggers.
        /// </summary>
        private void guess_Click(object sender, EventArgs e)
        {
            Logic.checkinput(guess_userinput.Text);
            guess_userinput.Text = null;
        }

        /// <summary>
        /// Update the unreadible word to represent the changes if there are any.
        /// And check if the game has been won or not.
        /// </summary>
        /// <param name="wordtounread">The word that needs to be changed to an unreadible stage.</param>
        /// <param name="letters">The letters that already have been guest.</param>
        public void update(string wordtounread, string letters) {
            string guessed_letters_return = Logic.gethiddenword(wordtounread, letters);
            guessed_letters.Text = Logic.gethiddenword(wordtounread, letters);
            if (guessed_letters_return.Replace(" ", null) == wordtounread) {
                writetoconsole("You won!");
                Logic.checkgameover(true);
            }
        }

        /// <summary>
        /// Log messages to the console textbox.
        /// </summary>
        /// <param name="sendmessage">The message that you want in the console.</param>
        public void writetoconsole(string sendmessage) {
            guessed_letters_console.Text = sendmessage + System.Environment.NewLine + guessed_letters_console.Text;
        }

        /// <summary>
        /// Load event of the form.
        /// Allows the Logic and DrawHanging class to get access to form1.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            Logic.form = this;
            DrawHaging.form = this;
        }

        /// <summary>
        /// Keyboard ENTER to trigger the gues check triggers.
        /// </summary>
        private void guess_userinput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                Logic.checkinput(guess_userinput.Text.Replace(Environment.NewLine, null));
                guess_userinput.Text = null;
            }
        }

        /// <summary>
        /// Reset button to reset the game and start an new one.
        /// <knownissue>
        /// if fast spamming anwsers then sometimes the hanging drawing disapears when at max wrong retries.
        /// </knownissue>
        /// </summary>
        private void reset_Click(object sender, EventArgs e)
        {
            Logic.reset();
            guessed_letters_console.Text = null;
            update(Logic.word, null);
        }
    }
}
