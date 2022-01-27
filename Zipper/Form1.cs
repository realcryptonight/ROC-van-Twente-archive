using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zipper
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// The path of the selected file.
        /// </summary>
        string path;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Allow the user to select a file.
        /// </summary>
        /// <algo>
        /// Let the user select a file.
        /// Get the full path as a string.
        /// Save the full path for later.
        /// Enable the zip and unzip button.
        /// </algo>
        private void choosefile_Click(object sender, EventArgs e)
        {
            if (selectedfile.ShowDialog() == DialogResult.OK)
            {
                path = selectedfile.FileName;
            }
            output.Text += "Path: " + path + Environment.NewLine;
            zipfile.Enabled = true;
            unzipfile.Enabled = true;
        }

        /// <summary>
        /// Start the zipping proccess.
        /// </summary>
        private void zipfile_Click(object sender, EventArgs e)
        {
            byte[] data = DataReader.getBytesFromFile(path);
            if (data != null)
            {
                uint[] counter = new uint[256];

                foreach (byte b in data) { 
                    counter[b]++;
                }

                TreeStructure tree = new TreeStructure();
                for (int i = 0; i < 255; i++)
                {
                    if (counter[i] != 0) {
                        Leaf leaf = new Leaf(counter[i], (byte)i);
                        tree.addleaf(leaf, tree);
                    }
                }
                tree.getTreeStructe(tree);
                string[] bitmap = Zip.getTreeAsString(tree);
                string encodeddata = Zip.getEncodeddata(bitmap, data);
                string validencodeddata = Zip.getValidByteString(encodeddata);
                byte[] bytesforfile = Zip.getBytesFromBits(validencodeddata);
                byte[] finalbytesforfile = Zip.getBytesForFile(bytesforfile, bitmap, validencodeddata.Length - encodeddata.Length);
                File.WriteAllBytes(path + ".danielzip", finalbytesforfile);
                output.Text += "File zipped successfully.";
            } 
            else
            {
                MessageBox.Show("Failed to read file '" + path + "'");
                return;
            }
        }

        /// <summary>
        /// Start the unzipping proccess.
        /// </summary>
        private void unzipfile_Click(object sender, EventArgs e)
        {
            byte[] data = DataReader.getBytesFromFile(path);
            if (data != null)
            {
                if (path.EndsWith(".danielzip"))
                {
                    string originalpath = path.Remove(path.LastIndexOf('.'));
                    int addedbits = data[0];
                    string[] firstbitpattern = Unzip.getPatternTable(data);
                    byte[] bytesforfile = Unzip.getBytes(data);
                    string validencodeddata = Unzip.makeBinary(bytesforfile);
                    byte[] originalfile = Unzip.rebuildBytes(validencodeddata, firstbitpattern, addedbits);
                    File.WriteAllBytes(originalpath + ".data.txt", originalfile);
                    output.Text += "File unzipped successfully.";
                }
                else
                {
                    output.Text += "File unzipped failed. Invalid extention.";
                }
            }
            else
            {
                MessageBox.Show("Failed to read file '" + path + "'");
                return;
            }
        }
    }
}
