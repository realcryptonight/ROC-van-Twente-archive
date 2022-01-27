using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zipper
{
    internal class Zip
    {
        /// <summary>
        /// Stores the final result for the getTreeAsString() and buildTreeAsString() function.
        /// </summary>
        private static string[] finalresult = new string[256];

        /// <summary>
        /// Change an TreeStructure to a string[] for file saving.
        /// </summary>
        /// <returns>A bitmap as string[]</returns>
        public static string[] getTreeAsString(TreeStructure tree)
        {
            Leaf start = tree.start;
            buildTreeAsString(start, "");
            return finalresult;
        }

        /// <summary>
        /// Change an TreeStructure to a string for file saving.
        /// </summary>
        /// <algo>
        /// Left = 0
        /// Right = 1
        /// 
        /// If the leaf has a left then add 0 to the string and call itself.
        /// If this is not possible anymore then get the leaf byte value and it after it.
        /// 
        /// For the right leaf, add 1 and get the leaf byte value, and it after the 1.
        /// </algo>
        /// <param name="leaf">The start leaf of a tree.</param>
        /// <param name="result">The result of the previuos call.</param>
        private static void buildTreeAsString(Leaf leaf, string result) {

            if (leaf.Left != null)
            {
                buildTreeAsString(leaf.Left, result + "0");
                buildTreeAsString(leaf.Right, result + "1");
            }
            else
            {
                finalresult[leaf.bytevalue] = result;
            }
        }

        /// <summary>
        /// Create an encoded string with the bitmap and the original data. 
        /// </summary>
        /// <algo>
        /// While looping through all the byte entries of the original data:
        ///     Add the bitmap result of the original data to the encoded string.
        /// </algo>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="originaldata">The original bytes.</param>
        /// <returns>The encoded result.</returns>
        public static string getEncodeddata(string[] bitmap, byte[] originaldata) {
            string encodedresult = "";

            for (int i = 0; i < originaldata.Length; i++)
            {
                encodedresult += bitmap[originaldata[i]];
            }
            return encodedresult;
        }

        /// <summary>
        /// Make a string 8 bits for easy byte convertion.
        /// </summary>
        /// <algo>
        /// When the string is devided by 8 and it creates an decimal:
        ///     Then add a 0 and try again.
        /// And stop if it does not produce a decimal since this means it can be devided by 8.
        /// </algo>
        /// <param name="encodedstring">The string that want to convert to bytes.</param>
        /// <returns>The string that can be converted to bytes.</returns>
        public static string getValidByteString(string encodedstring) {

            while (encodedstring.Length % 8 != 0)
            {
                encodedstring += "0";
            }
            return encodedstring;
        }

        /// <summary>
        /// Convert bits to bytes.
        /// </summary>
        /// <algo>
        /// Determine the amount of bytes.
        /// Then get each 8 bits and convert then into bytes.
        /// And add the result to the bytes array.
        /// </algo>
        /// <param name="encodedstring"></param>
        /// <returns>The bytes.</returns>
        public static byte[] getBytesFromBits(string encodedstring) {
            byte[] result = new byte[encodedstring.Length / 8];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = BinaryConverter.BinaryToByte(encodedstring.Substring(i * 8, 8));
            }
            return result;
        }

        /// <summary>
        /// Combines the bitmap and the bytes for file into one byte array.
        /// </summary>
        /// <algo>
        /// First calculate the total length that is needed for the byte array.
        /// 
        /// Then added the extra added bits value and a end of data value.
        /// Then add all the needed "paths" and values into one string.
        /// When all the path are done add a end of data value.
        /// Then add a size value and a end of data value.
        /// Now add a end of bitmap value.
        /// And finally make then bytes againso that they can be written to a file.
        /// </algo>
        /// <param name="bytesforfile">The bytes for the file.</param>
        /// <param name="bitmap">The bitmap</param>
        /// <param name="extrabits">The extra added bits to make it a byte.</param>
        /// <returns>The bytes that can be written to a file.</returns>
        public static byte[] getBytesForFile(byte[] bytesforfile, string[] bitmap, int extrabits)
        {
            long resultlength = bytesforfile.Length * 2 + extrabits + finalresult.Length;
            long resultposition = 0;
            byte[] result = new byte[resultlength];

            // Add the amount of added bits and add a end of data value.
            result[resultposition] += ((byte)(extrabits));
            resultposition++;
            result[resultposition] += 124;

            for (int i = 0; i < bitmap.Length; i++)
            {
                if (bitmap[i] != null)
                {
                    for (int j = 0; j < bitmap[i].Length; j++)
                    {
                        resultposition++;
                        if (bitmap[i].Substring(j, 1) == "0")
                        {
                            result[resultposition] += 48;
                        }
                        else if (bitmap[i].Substring(j, 1) == "1")
                        {
                            result[resultposition] += 49;
                        }
                    }
                    // We are at the end of the "path" and value.
                    resultposition++;
                    result[resultposition] += 124;

                    resultposition++;
                    result[resultposition] += ((byte)(i));

                    resultposition++;
                    result[resultposition] += 124;
                }
            }

            // Add the end of bitmap value.
            result[resultposition] = 127;

            resultposition++;

            // build up the string with all of the values, convert them to a array of bytes and return them
            for (int i = 0; i < bytesforfile.Length; i++)
            {
                result[resultposition] += bytesforfile[i];
                resultposition++;
            }
            // Add a end of data value.
            result[resultposition] += 124;

            byte[] result2 = new byte[resultposition + 1];

            for (int c = 0; c < resultposition + 1; c++)
            {
                result2[c] = result[c];
            }
            return result2;
        }
    }
}
