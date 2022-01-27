using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zipper
{
    internal class DataReader
    {
        /// <summary>
        /// Read all the bytes from a file and put then in a byte array.
        /// </summary>
        /// <algo>
        /// Check if the file exists.
        /// If it exists:
        ///     Continue:
        /// Else
        ///     return null;
        /// 
        /// Then try to read the bytes from the file.
        /// If successfull:
        ///     return the bytes in byte[]
        /// Else
        ///     return null;
        /// </algo>
        /// <param name="path">The full path to the file.</param>
        /// <returns>The bytes of the file. (Returns null in case of failure.)</returns>
        public static byte[] getBytesFromFile(string path) {
            if (File.Exists(path))
            {
                try
                {
                    return File.ReadAllBytes(path);
                } catch {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
