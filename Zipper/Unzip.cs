using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zipper
{
    internal class Unzip
    {
        /// <summary>
        /// "Reconstruct" the bitmap.
        /// </summary>
        /// <algo>
        /// Do the same thing as getBytesForFile() but do it only for the bitmap part.
        /// </algo>
        /// <param name="data">The data of the zipped file.</param>
        /// <returns>The "Reconstructed" bitmap.</returns>
        public static string[] getPatternTable(byte[] data)
        {
            string[] result = new string[255];
            string tempresult = "";

            // Since the first two bits are for the added bits we need to start after it.
            long resultposition = 2;

            while (data[resultposition] != 127)
            {
                if (data[resultposition] != 124)
                {
                    tempresult += ((char)(data[resultposition]));
                }
                else
                {
                    resultposition++;
                    result[data[resultposition]] = tempresult;
                    tempresult = "";
                    resultposition++;
                }
                if (data[resultposition] != 127)
                {
                    resultposition++;
                }
            }
            return result;
        }

        /// <summary>
        /// Calculate the size of the data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] getBytes(byte[] data)
        {
            long startofbitmapposition = 0;

            while (data[startofbitmapposition] != 127)
            {
                startofbitmapposition++;
            }
            startofbitmapposition++;

            byte[] bitmap = new byte[data.Length - 1 - startofbitmapposition];

            long bitmapposition = 0;
            while (startofbitmapposition < data.Length - 1)
            {
                bitmap[bitmapposition] = data[startofbitmapposition];
                startofbitmapposition++;
                bitmapposition++;
            }
            return bitmap;
        }

        /// <summary>
        /// Make from multiple bytes a bit pattern.
        /// </summary>
        /// <algo>
        /// For each bytes pass then to the byte to bit function.
        /// And add the result of that to a result string.
        /// And finally return the result.
        /// </algo>
        /// <param name="bytesforfile"></param>
        /// <returns></returns>
        public static string makeBinary(byte[] bytesforfile)
        {
            string result = "";

            for (int i = 0; i < bytesforfile.Length; i++)
            {
                result += Unzip.getBitsFromBytes(bytesforfile[i]);
            }
            return result;
        }

        /// <summary>
        /// Change bytes into bits.
        /// </summary>
        /// <algo>
        /// Check if the bit is a one or a zero.
        /// Then add then as one or zero.
        /// And do this 7 more times.
        /// </algo>
        /// <param name="byteofbytes">The byte that you needs the bits off.</param>
        /// <returns>The bits.</returns>
        public static string getBitsFromBytes(byte byteofbytes)
        {
            string bits = "";
            byte bitmultiplier = 128;

            for (int i = 7; i >= 0; i--)
            {
                if (byteofbytes - bitmultiplier < 0)
                {
                    bits += "0";
                }
                else
                {
                    bits += "1";
                    byteofbytes -= bitmultiplier;
                }
                bitmultiplier /= 2;
            }
            return bits;
        }

        /// <summary>
        /// Rebuild the original file.
        /// </summary>
        /// <algo>
        /// First get the first "path"
        /// Since we know where the "path" ends we can just look it up in the bitmap.
        /// Then add the value of the "path" from the bitmap to the result.
        /// And change them all to bytes.
        /// </algo>
        /// <param name="validencodeddata">The data that needs to be compared with the bitmap.</param>
        /// <param name="firstbitpattern">The bitmap.</param>
        /// <param name="addedbits">The amount of added bits.</param>
        /// <returns>The bytes of the original file.</returns>
        public static byte[] rebuildBytes(string validencodeddata, string[] firstbitpattern, int addedbits)
        {
            int pos1 = 0;
            int pos2 = 1;
            long end = validencodeddata.Length - addedbits;
            byte bitmapposition = 0;
            string resultstring = "";
            char tempchar;
            string tempresult = "";

            while (pos1 < end)
            {
                tempresult = validencodeddata.Substring(pos1, pos2);

                while (tempresult != firstbitpattern[bitmapposition])
                {
                    bitmapposition++;
                    if (bitmapposition == 255)
                    {
                        bitmapposition = 0;
                        pos2++;
                        tempresult = validencodeddata.Substring(pos1, pos2);
                    }
                }
                if (tempresult == firstbitpattern[bitmapposition])
                {
                    resultstring += ((char)(bitmapposition));
                    pos1 = pos1 + pos2;
                    pos2 = 1;
                    tempresult = "";
                    bitmapposition = 0;
                }
            }

            byte[] result = new byte[resultstring.Length];
            for (int x = 0; x < resultstring.Length; x++)
            {
                tempchar = char.Parse(resultstring.Substring(x, 1));
                result[x] = ((byte)(tempchar));
            }
            return result;
        }
    }
}
