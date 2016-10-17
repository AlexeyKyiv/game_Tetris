using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CCTetris
{
    class Element_Red
    {
        int x, y;
        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }

        Image elementImg2 = Properties.Resources.Cube2;
        public Image ElementImgRed
        {
            get { return elementImg2; }
        }
        public Element_Red(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
