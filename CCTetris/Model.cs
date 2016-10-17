using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CCTetris
{
    class Model
    {
        int speedGame;

        Figure figure;

        public Figure Figure
        {
            get { return figure; }
        }

        public Model(int speedGame)
        {
            this.speedGame = speedGame;

            figure = new Figure();

            figure.StartFigure();
        }

        public void PlayGame()
        {            
            while (figure.flagGame)
            {
                Thread.Sleep(speedGame);

                figure.Run();
            }
        }

    }
}
