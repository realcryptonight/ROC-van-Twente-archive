using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zipper
{
    internal class BinaryConverter
    {
        /// <summary>
        /// Converts the bits into bytes.
        /// </summary>
        /// <algo>
        /// First devide the string into strings of 8 chars (bits).
        /// Then change them to an int and add the correct multiplier.
        /// Then add them to an int count.
        /// And cast the value of the int count as a byte.
        /// </algo>
        /// <param name="bitsstring">The strinf of bites that needs to be bytes.</param>
        /// <returns>The bytes from the bits.</returns>
        public static byte BinaryToByte(string bitsstring)
        {
            int bytevalue = 0;
            byte multiplier = 128;

            for (int i = 0; i <= 7; i++)
            {
                // * position in byte with multiplier
                bytevalue += int.Parse(bitsstring.Substring(i, 1)) * multiplier;

                // double multiplier according to 
                // binary system (1, 2, 4, 8, 16, 32, 64, 128)
                multiplier /= 2;
            }
            return (byte)bytevalue;
        }
    }
}
