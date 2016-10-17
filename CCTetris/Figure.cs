using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace CCTetris
{
    class Figure
    {
        int typeFig;
        bool b;
        public bool flagGame;
        byte bh;
        Image imgNow;
        public int z = 0;
        public byte[] mb;

        static Random r;

        List<Element> elMove;
        List<Element> elStop;
        List<Element_Red> elStopRed;

        internal List<Element> ElMove
        {
            get { return elMove; }
        }
        internal List<Element> ElStop
        {
            get { return elStop; }
        }
        internal List<Element_Red> ElStopRed
        {
            get { return elStopRed; }
        }
        
        public Figure()
        {
            elMove = new List<Element>();
            elStop = new List<Element>();
            elStopRed = new List<Element_Red>();
            r = new Random();
            mb = new byte[17];
            flagGame = true;
        }

        public void StartFigure()           //  вызов фигуры в начальное положение выбраное Random-ом
        {
            b = true;
            bh = 1;
            typeFig = r.Next(10000);
            if (typeFig < 1500)
                LetterT();
            else if (1500 < typeFig && typeFig < 3000)
                Straight();
            else if (3000 < typeFig && typeFig < 4500)
                ZigzagL();
            else if (4500 < typeFig && typeFig < 6000)
                ZigzagR();
            else if (6000 < typeFig && typeFig < 7500)
                StepHorseL();
            else if (7500 < typeFig && typeFig < 9000)
                StepHorseR();
            else
                Cube();
        }

        public void Run()
        {
            CheckStoppedGame();
            CheckStoppedFigure();
            //foreach (Element ee in elMove) ee.YY++;
            for (int i = 0; i < elMove.Count; i++ )
                elMove[i].YY++;                
        }

        public void NewGame()
        {
            elMove.Clear();
            elStop.Clear();

            flagGame = true;
            StartFigure();
        }
        
        void CheckStoppedFigure()
        {
            for (int i = 0; i < elMove.Count; i++)          // проверка на "дно" игрового поля
                if (elMove[i].Y == 480)
                    StopFigureAndCreatingNewFigure();
            for (int i = 0; i < elMove.Count; i++)          // проверка на столкновение с неподвижными элементами
                for (int j = 0; j < elStop.Count; j++)
                    if ((ElMove[i].X == ElStop[j].X) & ((ElMove[i].Y + 30) == ElStop[j].Y))
                        StopFigureAndCreatingNewFigure();
        }

        void StopFigureAndCreatingNewFigure()
        {
            for (int i = 0; i < elMove.Count; i++)
            {
                // корректировка элементов движемых перед передачей координат в недвижемые элементы
                /*if (elMove[i].Y >= 0 && elMove[i].Y < 15)   elMove[i].YY = 0;
                if (elMove[i].Y > 25 && elMove[i].Y < 45)   elMove[i].YY = 30;
                if (elMove[i].Y > 55 && elMove[i].Y < 75)   elMove[i].YY = 60;
                if (elMove[i].Y > 85 && elMove[i].Y < 105)  elMove[i].YY = 90;
                if (elMove[i].Y > 115 && elMove[i].Y < 135) elMove[i].YY = 120;
                if (elMove[i].Y > 145 && elMove[i].Y < 165) elMove[i].YY = 150;
                if (elMove[i].Y > 175 && elMove[i].Y < 195) elMove[i].YY = 180;
                if (elMove[i].Y > 205 && elMove[i].Y < 225) elMove[i].YY = 210;
                if (elMove[i].Y > 235 && elMove[i].Y < 255) elMove[i].YY = 240;
                if (elMove[i].Y > 265 && elMove[i].Y < 285) elMove[i].YY = 270;
                if (elMove[i].Y > 295 && elMove[i].Y < 315) elMove[i].YY = 300;
                if (elMove[i].Y > 325 && elMove[i].Y < 345) elMove[i].YY = 330;
                if (elMove[i].Y > 355 && elMove[i].Y < 375) elMove[i].YY = 360;
                if (elMove[i].Y > 385 && elMove[i].Y < 405) elMove[i].YY = 390;
                if (elMove[i].Y > 415 && elMove[i].Y < 435) elMove[i].YY = 420;
                if (elMove[i].Y > 475 && elMove[i].Y < 495) elMove[i].YY = 480;*/
                
                elStop.Add(new Element(elMove[i].X, elMove[i].Y));
            }      

            elMove.Clear();
            CheckFullLineElementsForDel();
            //CorrectionElStop();
            StartFigure();
        }

        void CheckFullLineElementsForDel()
        {
            for (int i = 0; i < elStop.Count; i++)
            {
                for (int j = 0, n = 0; n < mb.Length; j += 30, n++)     // max j = 480 
                    if (ElStop[i].Y == j) mb[n]++;
                /*
                if (ElStop[i].Y == 0) mb[0]++; if (ElStop[i].Y == 30) mb[1]++; if (ElStop[i].Y == 60) mb[2]++; if (ElStop[i].Y == 90) mb[3]++; if (ElStop[i].Y == 120) mb[4]++;
                if (ElStop[i].Y == 150) mb[5]++; if (ElStop[i].Y == 180) mb[6]++; if (ElStop[i].Y == 210) mb[7]++; if (ElStop[i].Y == 240) mb[8]++;
                if (ElStop[i].Y == 270) mb[9]++; if (ElStop[i].Y == 300) mb[10]++; if (ElStop[i].Y == 330) mb[11]++; if (ElStop[i].Y == 360) mb[12]++;
                if (ElStop[i].Y == 390) mb[13]++; if (ElStop[i].Y == 420) mb[14]++; if (ElStop[i].Y == 450) mb[15]++; if (ElStop[i].Y == 480) mb[16]++;
                */
            }
            
            for (byte i = 0; i < mb.Length; i++)
            {
                if (mb[i] == 10)
                {
                    DelLineFigure(i);
                    z += 10;
                }
                mb[i] = 0;
            }
            
        }

        private void DelLineFigure(byte bi)
        {
            Thread.Sleep(1000);  // приостан поток
            int yDel = bi * 30;

            DelLineElStop(yDel);
            
            Thread.Sleep(1000);  // приостан поток
            for (int i = 0; i < elStop.Count; i++)
                if (elStop[i].Y < yDel)
                    elStop[i].YY += 30;
        }

        void DelLineElStop(int yDel)            // метод, конечно, НЕРАЦИОНАЛЬНЫЙ, но - работает )
        {
            RedImageForDel(yDel);
            ForDelYellow(yDel);
            Thread.Sleep(1000);
            elStopRed.Clear();
        }

        void RedImageForDel(int yDel)
        {
            for (int i = 0; i < elStop.Count; i++)
                if (elStop[i].Y == yDel)                
                    elStopRed.Add(new Element_Red(elStop[i].X, elStop[i].Y));
            for (int i = 0; i < elStop.Count; i++)
                if (elStop[i].Y == yDel)
                    elStopRed.Add(new Element_Red(elStop[i].X, elStop[i].Y));
            for (int i = 0; i < elStop.Count; i++)
                if (elStop[i].Y == yDel)
                    elStopRed.Add(new Element_Red(elStop[i].X, elStop[i].Y));
            for (int i = 0; i < elStop.Count; i++)
                if (elStop[i].Y == yDel)
                    elStopRed.Add(new Element_Red(elStop[i].X, elStop[i].Y));
            for (int i = 0; i < elStop.Count; i++)
                if (elStop[i].Y == yDel)
                    elStopRed.Add(new Element_Red(elStop[i].X, elStop[i].Y));
        }

        void ForDelYellow(int yDel)
        {
            for (int i = 0; i < elStop.Count; i++)
                if (elStop[i].Y == yDel)
                    elStop.Remove(elStop[i]);                
            for (int i = 0; i < elStop.Count; i++)
                if (elStop[i].Y == yDel)
                    elStop.Remove(elStop[i]);
            for (int i = 0; i < elStop.Count; i++)
                if (elStop[i].Y == yDel)
                    elStop.Remove(elStop[i]);
            for (int i = 0; i < elStop.Count; i++)
                if (elStop[i].Y == yDel)
                    elStop.Remove(elStop[i]);
            for (int i = 0; i < elStop.Count; i++)
                if (elStop[i].Y == yDel)
                    elStop.Remove(elStop[i]);
        }
        
        void CheckStoppedGame()                         //  Н Е З А К О Н Ч Е Н О
        {
            foreach (Element ele in ElStop)
                if (ele.Y < 5)
                    flagGame = !flagGame;
        }

        internal void TurnFigure()
        {
            if (typeFig < 1500)
                LetterTTurn();
            else if (1500 < typeFig && typeFig < 3000)
                StraightTurn();
            else if (3000 < typeFig && typeFig < 4500)
                ZigzagLTurn();
            else if (4500 < typeFig && typeFig < 6000)
                ZigzagRTurn();
            else if (6000 < typeFig && typeFig < 7500)
                StepHorseLTurn();
            else if (7500 < typeFig && typeFig < 9000)
                StepHorseRTurn();

            while (CheckLeftBorder())
            {
                for (int i = 0; i < elMove.Count; i++)
                    elMove[i].XX += 30;
            }
            while (CheckRightBorder())
            {
                for (int i = 0; i < elMove.Count; i++)
                    elMove[i].XX -= 30;
            }
        }

        bool CheckLeftBorder()
        {
            foreach (Element e in elMove)
                if (e.X < 0)
                    return true;
            return false;
        }
        bool CheckRightBorder()
        {
            foreach (Element e in elMove)
                if (e.X > 270)
                    return true;
            return false;
        }

        void LetterTTurn()
        {
            if (bh == 1)
            {
                elMove[0].XX += 30;
                elMove[0].YY -= 30;
                bh = 2;
            }
            else if (bh == 2)
            {
                elMove[3].XX -= 30;
                elMove[3].YY -= 30;
                bh = 3;
            }
            else if (bh == 3)
            {
                elMove[2].XX -= 30;
                elMove[2].YY += 30;
                bh = 4;
            }
            else if (bh == 4)
            {
                elMove[0].XX -= 30;
                elMove[0].YY += 30;
                elMove[2].XX += 30;
                elMove[2].YY -= 30;
                elMove[3].XX += 30;
                elMove[3].YY += 30;
                bh = 1;
            }
        }
        void StepHorseRTurn()
        {
            if (bh == 1)
            {
                elMove[0].XX -= 60;
                elMove[0].YY += 60;
                elMove[1].YY += 60;
                bh = 2;
            }
            else if (bh == 2)
            {
                elMove[0].XX += 60;
                elMove[0].YY += 60;
                elMove[3].XX += 60;
                bh = 3;
            }
            else if (bh == 3)
            {
                elMove[0].XX += 60;
                elMove[0].YY -= 60;
                elMove[1].YY -= 60;
                bh = 4;
            }
            else if (bh == 4)
            {
                elMove[0].XX -= 60;
                elMove[0].YY -= 60;
                elMove[3].XX -= 60;
                bh = 1;
            }
        }
        void StepHorseLTurn()
        {
            if (bh == 1)
            {
                elMove[0].XX -= 60;
                elMove[0].YY += 60;
                elMove[3].XX -= 60;
                bh = 2;
            }
            else if (bh == 2)
            {
                elMove[0].XX += 60;
                elMove[0].YY += 60;
                elMove[1].YY += 60;
                bh = 3;
            }
            else if (bh == 3)
            {
                elMove[0].XX += 60;
                elMove[0].YY -= 60;
                elMove[3].XX += 60;
                bh = 4;
            }
            else if (bh == 4)
            {
                elMove[0].XX -= 60;
                elMove[0].YY -= 60;
                elMove[1].YY -= 60;
                bh = 1;
            }
        }
        void ZigzagRTurn()
        {
            if (b)
            {
                elMove[0].XX -= 60;
                elMove[1].YY += 60;
                b = !b;
            }
            else
            {
                elMove[0].XX += 60;
                elMove[1].YY -= 60;
                b = !b;
            }
        }
        void ZigzagLTurn()
        {
            if (b)
            {
                elMove[0].XX += 60;
                elMove[1].YY += 60;
                b = !b;
            }
            else
            {
                elMove[0].XX -= 60;
                elMove[1].YY -= 60;
                b = !b;
            }
        }
        void StraightTurn()
        {            
            if(b)
            {
                elMove[0].XX -= 30; elMove[0].YY += 30;
                elMove[2].XX += 30; elMove[2].YY -= 30;
                elMove[3].XX += 60; elMove[3].YY -= 60;
                b = !b;
            }
            else
            {
                elMove[0].XX += 30; elMove[0].YY -= 30;
                elMove[2].XX -= 30; elMove[2].YY += 30;
                elMove[3].XX -= 60; elMove[3].YY += 60;
                b = !b;
            }
        }           // выход за экран при повороте !!!!!!!!!!!!!

        internal bool CheckElMoveBorderRight()
        {
            foreach (Element ee in elMove)            
                if (ee.X == 270)
                    return false;

            foreach (Element m in elMove)
                foreach (Element s in elStop)
                    if (((s.X - m.X) == 30) & (Math.Abs(s.Y - m.Y) < 26))
                        return false;

            return true;
        }
        internal bool CheckElMoveBorderLeft()
        {
            foreach (Element ee in elMove)          
                if (ee.X == 0)
                    return false;

            foreach (Element m in elMove)
                foreach (Element s in elStop)
                    if (((s.X - m.X) == -30) & (Math.Abs(s.Y - m.Y) < 26))
                        return false;
            
            return true;
        }

        internal bool CheckElMoveBeforeDown()       // ИНОГДА ПРОЛЕТАЕТ МИМО НИЖНЕЙ ГРАНИ   !!!
        {
            foreach (Element ee in elMove)      // проверка на "нижнюю грань"
                if (ee.Y >= 460)
                    return false;
            foreach (Element ee in elMove)      // проверка на "упор в неподвижные элемент"
                foreach (Element eee in elStop)
                    if ( (ee.Y >= (eee.Y - 50)) & (ee.X == eee.X) )
                        return false;

            return true;
        }

        void LetterT()
        {
            elMove.Add(new Element(120, 0));
            elMove.Add(new Element(150, 0));
            elMove.Add(new Element(180, 0));
            elMove.Add(new Element(150, 30));
        }
        void Straight()         // прямая
        {
            elMove.Add(new Element(120, 0));
            elMove.Add(new Element(120, 30));
            elMove.Add(new Element(120, 60));
            elMove.Add(new Element(120, 90));
        }
        void ZigzagL()
        {
            elMove.Add(new Element(120, 0));
            elMove.Add(new Element(150, 0));
            elMove.Add(new Element(150, 30));
            elMove.Add(new Element(180, 30));
        }
        void ZigzagR()
        {
            elMove.Add(new Element(180, 0));
            elMove.Add(new Element(150, 0));
            elMove.Add(new Element(150, 30));
            elMove.Add(new Element(120, 30));
        }
        void StepHorseL()
        {
            elMove.Add(new Element(120, 0));
            elMove.Add(new Element(120, 30));
            elMove.Add(new Element(120, 60));
            elMove.Add(new Element(150, 60));
        }
        void StepHorseR()
        {
            elMove.Add(new Element(120, 0));
            elMove.Add(new Element(120, 30));
            elMove.Add(new Element(120, 60));
            elMove.Add(new Element(90, 60));
        }       
        void Cube()
        {
            elMove.Add(new Element(120, 0));
            elMove.Add(new Element(150, 0));
            elMove.Add(new Element(120, 30));
            elMove.Add(new Element(150, 30));
        }

    }
}
