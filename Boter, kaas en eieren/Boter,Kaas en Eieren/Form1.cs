using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boter_Kaas_en_Eieren
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int size = 6;

        private void Form1_Load(object sender, EventArgs e)
        {
            functions.generatebuttons(size, this);
            general.f1 = this;
        }
    }
}
