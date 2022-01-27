using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Opdracht_cv2
{
    public class Functions
    {
        /// <summary>
        /// Remove all invalid characters.
        /// </summary>
        /// <param name="message"></param>
        public static string filtertext(String message) {
            // Check if string is not empty
            if (message == "" || message == null) {
                return "";
            }

            Char[] chararray = message.ToCharArray();

            // Check if char array is not empty.
            if (chararray.Length == 0) {
                return "";
            }

            bool addedspace = false;
            string result = "";
            for(int i = 0; i < chararray.Length; i++) {
                Console.WriteLine(i);
                Console.WriteLine("Added space: " + addedspace);
                // Check if the char is an letter.
                if (Regex.IsMatch(chararray[i].ToString(), @"^[a-zA-Z]+$"))
                {
                    addedspace = false;
                    result += chararray[i];
                }
                else
                {
                    if (!addedspace)
                    {
                        Console.WriteLine("If triggered");
                        result += " ";
                        addedspace = true;
                    }
                    else
                    {
                        Console.WriteLine("if not triggered");
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// This is for easy changing an string to an string array with
        /// the words seperated.
        /// </summary>
        /// <param name="message">The message that needs to be converted.</param>
        /// <returns></returns>
        public static string[] getWords(string message) {
            string[] words = message.Split(' ');
            return words;
        }

        /// <summary>
        /// This is used the combine the string arrays onto one final string.
        /// </summary>
        /// <param name="message1"></param>
        /// <param name="message2"></param>
        /// <returns></returns>
        public static string getEndResult(string[] message1, string[] message2) {
            int doloop = 0;
            string endstring = "";
            int message1length = message1.Length;
            int message2length = message2.Length;
            Console.WriteLine(message1length);
            Console.WriteLine(message2length);

            // Check wich message is the biggest.
            if (message1length >= message2length)
            {
                doloop = message1length;
            }
            else {
                doloop = message2length;
            }

            int turn = 0;
            for (int i = 0; i < doloop; i++)
            {
                // Check if one of the messages arrays is over its max.
                if (i > message1length - 1 || i > message2length - 1)
                {
                    // Check wich message array is over its max.
                    if (1 > message1length)
                    {
                        // Adding all left over from messages array 2.
                        for (int i2 = i; i2 < message2length; i2++)
                        {
                            endstring += message2[i2];
                        }
                    }
                    else
                    {
                        // Adding all left over from messages array 1.
                        for (int i2 = i; i2 < message1length - i; i2++)
                        {
                            endstring += message1[i2];
                        }
                    }
                }
                else
                {
                    // Check wich has the least words and adding the least words first and then the most.
                    if (message1[i].Length > message2[i].Length)
                    {
                        endstring += message2[i] + " ";
                        endstring += message1[i] + " ";
                    }
                    else
                    {
                        endstring += message1[i] + " ";
                        endstring += message2[i] + " ";
                    }
                }
            }
            return endstring;
        }
    }
}
