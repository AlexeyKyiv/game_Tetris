using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CCTetris
{
    class Element
    {
        private int x, y;
        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }
        internal int YY
        {
            get { return y; }
            set { y = value; }
        }
        internal int XX
        {
            get { return x; }
            set { x = value; }
        }

        Image elementImg1 = Properties.Resources.Cube1;
        
        public Image ElementImgMain
        {
            get { return elementImg1; }
        }

        public Element(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
