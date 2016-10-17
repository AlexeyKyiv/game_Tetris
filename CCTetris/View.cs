using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCTetris
{
    partial class View : UserControl
    {
        Model model;

        public View(Model model)
        {
            InitializeComponent();

            this.model = model;
        }

        void DrawingFigureMove(PaintEventArgs e)
        {
            for (int i = 0; i < model.Figure.ElMove.Count; i++ )
                e.Graphics.DrawImage(model.Figure.ElMove[i].ElementImgMain, new Point(model.Figure.ElMove[i].X, model.Figure.ElMove[i].Y));
                    //foreach (Element ee in model.Figure.ElMove)
                        //e.Graphics.DrawImage(ee.ElementImg1, new Point(ee.X, ee.Y));
        }
        void DrawingFigureStopping(PaintEventArgs e)
        {
            for (int i = 0; i < model.Figure.ElStop.Count; i++)
                e.Graphics.DrawImage(model.Figure.ElStop[i].ElementImgMain, new Point(model.Figure.ElStop[i].X, model.Figure.ElStop[i].Y));
                    //foreach (Element ee in model.Figure.ElStop)
                        //e.Graphics.DrawImage(ee.ElementImg1, new Point(ee.X, ee.Y));
        }
        private void DrawingFigureStoppingRed(PaintEventArgs e)
        {
            for (int i = 0; i < model.Figure.ElStopRed.Count; i++)
                e.Graphics.DrawImage(model.Figure.ElStopRed[i].ElementImgRed, new Point(model.Figure.ElStopRed[i].X, model.Figure.ElStopRed[i].Y));
            //foreach (Element ee in model.Figure.ElStop)
            //e.Graphics.DrawImage(ee.ElementImg1, new Point(ee.X, ee.Y));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawingFigureMove(e);
            DrawingFigureStopping(e);
            DrawingFigureStoppingRed(e);

            Invalidate();
        }

        private void View_Load(object sender, EventArgs e)
        {

        }
    }
}
