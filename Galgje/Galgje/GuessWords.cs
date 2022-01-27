using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Galgje
{
    class GuessWords
    {
        private static string[] wordsarray = {"wasmachine", "klaslokaal", "troonreden", "kernreactor", "toetsenbord"};
        private static Random random = new Random();

       /// <summary>
       /// Get an random word that is stored in the randomword array.
       /// </summary>
       /// <returns>An random word from the wordarray.</returns>
        public static string getrandomword() {
            int i = random.Next(0, wordsarray.Length - 1);
            return wordsarray[i];
        }
    }
}
