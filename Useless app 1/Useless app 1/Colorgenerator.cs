using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Useless_app_1
{
    class Colorgenerator
    {
        private static Random rnd = new Random();
        public static Color getColor() {
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            return randomColor;
        }

    }
}
