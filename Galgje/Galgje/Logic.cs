using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galgje
{
    class Logic
    {
        public static string word = GuessWords.getrandomword();
        private static string goodletters = "";
        private static string badletters = "";
        public static int tries = 0;
        public static Form1 form;
        
        /// <summary>
        /// Main entry for checking if the letter or word that is valid cna can be checked by furture functions.
        /// It only checks if input is possible/valid and whether or not it should be check as letter or as word.
        /// </summary>
        /// <param name="inputstring">The string that needs to be checked.</param>
        public static void checkinput(string inputstring) {
            inputstring = inputstring.ToLower();
            if (ispossible(inputstring))
            {
                if (inputstring.Length == 1)
                {
                    checkletter(inputstring[0]);
                }
                else
                {
                    checkword(inputstring);
                }
            }
        }

        /// <summary>
        /// Check whether or not the letter is in the word that needs to be guest.
        /// </summary>
        /// <param name="letter">The letter that needs to be validated against the word.</param>
        private static void checkletter(Char letter) {
            if (word.Contains(letter))
            {
                form.writetoconsole("Letter " + letter + " is in the word.");
                goodletters += letter;
                form.update(word, goodletters);
            }
            else
            {
                badletters += letter;
                tries += 1;
                form.writetoconsole("Letter " + letter + " is not in the word.");
                form.writetoconsole("Good letters: " + goodletters);
                form.writetoconsole("Bad letters: " + badletters);
                DrawHaging.drawHangingPerson();
                checkgameover(false);
            }
        }

        /// <summary>
        /// Check whether or not the guest word is the same as the word that needs to be guest.
        /// </summary>
        /// <param name="inputstring">The guest word that needs to be validated against the word.</param>
        private static void checkword(string inputstring) {
            if (word == inputstring)
            {
                form.writetoconsole(inputstring + " is the correct word.");
                form.writetoconsole(" You won!");
                checkgameover(true);
            }
            else
            {
                tries += 1;
                form.writetoconsole(inputstring + " is not the correct word.");
                DrawHaging.drawHangingPerson();
                checkgameover(false);
            }
        }

        /// <summary>
        /// Checks if the given input string is valid and could be used for future checking.
        /// </summary>
        /// <param name="inputstring">The string that needs to be validated.</param>
        /// <returns>true if valid | false if invalid</returns>
        private static bool ispossible(string inputstring) {
            if (inputstring == "" || inputstring == null)
            {
                form.writetoconsole("No letter or word was provided.");
                return false;
            }

            if (inputstring.Contains(" "))
            {
                form.writetoconsole("No words will contain multiple words.");
                return false;
            }

            if (badletters.Contains(inputstring) || goodletters.Contains(inputstring))
            {
                form.writetoconsole("The letter " + inputstring + " has already been guessed.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Change the word that needs to be guest to an unreadible stage.
        /// And place the letters in the right place that have been guest already.
        /// </summary>
        /// <algo>
        /// Check if an letter has been guest. if not then replace all letters with underscores.
        /// If an letter has been guest check for every letter in the word if it matches the guest letter:
        ///     If it matches then add it.
        ///     If it does not match add an underscore in that place.
        /// </algo>
        /// <param name="wordtounread">The word that needs to be changed to an unreadible stage.</param>
        /// <param name="letters">The letters that already have been guest.</param>
        /// <returns>The readible word with the letters filled in that have been guest.</returns>
        public static string gethiddenword(string wordtounread, string letters)
        {
            string hiddenword = "";
            if (letters == null)
            {
                for (int i = 0; i < wordtounread.Length; i++)
                {
                    if (i == 0) { hiddenword += "_"; } else { hiddenword += " _"; }
                }
            }
            else
            {
                for (int i = 0; i < wordtounread.Length; i++)
                {
                    if (letters.Contains(wordtounread[i]))
                    {
                        if (i == 0) { hiddenword += wordtounread[i].ToString(); } else { hiddenword += " " + wordtounread[i].ToString(); }
                    }
                    else
                    {
                        if (i == 0) { hiddenword += "_"; } else { hiddenword += " _"; }
                    }
                }
            }
            return hiddenword;
        }

        /// <summary>
        /// Check for an game over.
        /// And if the game is over do some game over stuff.
        /// </summary>
        /// <param name="won">Whether or not the gueser has won.</param>
        public static void checkgameover(bool won)
        {
            if (tries == 11)
            {
                form.guess.Enabled = false;
                form.guess_userinput.Enabled = false;
                form.guessed_letters.Text = "The word: " + word;
                form.reset.Visible = true;
            }
            if (won) {
                form.guess.Enabled = false;
                form.guess_userinput.Enabled = false;
                form.reset.Visible = true;
            }
        }

        public static void reset() {
            word = GuessWords.getrandomword();
            goodletters = "";
            badletters = "";
            tries = 0;
            if (DrawHaging.g != null) {
                DrawHaging.g.Clear(form.BackColor); 
            }

            form.reset.Visible = false;
            form.guess.Enabled = true;
            form.guess_userinput.Enabled = true;
            form.reset.Visible = false;
        }
    }
}