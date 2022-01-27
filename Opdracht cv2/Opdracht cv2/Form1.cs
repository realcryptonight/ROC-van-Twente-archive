using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opdracht_cv2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The button to trigger the text changes.
        /// </summary>
        private void sendmessages_Click(object sender, EventArgs e)
        {
            sendMessageToOutput("Stage 1, Message 1: " + inputtext1.Text);
            sendMessageToOutput("Stage 1, Message 2: " + inputtext2.Text);
            string message1 = Functions.filtertext(inputtext1.Text);
            string message2 = Functions.filtertext(inputtext2.Text);
            sendMessageToOutput("Stage 2, Message 1: " + message1);
            sendMessageToOutput("Stage 2, Message 2: " + message2);
            string[] words1 = Functions.getWords(message1);
            string[] words2 = Functions.getWords(message2);
            string endresult = Functions.getEndResult(words1, words2);
            sendMessageToOutput("Your result is: " + endresult);
        }

        /// <summary>
        /// Allows to easy send messages to the output text box.
        /// </summary>
        public void sendMessageToOutput(string message) {
            output.Text += message + "\r\n";
        }
    }
}
