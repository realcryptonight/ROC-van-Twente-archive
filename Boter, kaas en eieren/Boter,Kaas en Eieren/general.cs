using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boter_Kaas_en_Eieren
{
    class general
    {
        /// <summary>
        /// Instance of the form.
        /// </summary>
        public static Form1 f1;

        /// <summary>
        /// Represents wich player turn it is.
        /// </summary>
        public static bool player = true;

        /// <summary>
        /// Count on how many tiles are filled in. (Based on click amount.)
        /// </summary>
        public static int clickcount = 0;
    }
}
