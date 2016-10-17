using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CCTetris
{
    public partial class MainFormController : Form
    {
        Model model;
        View view;
        Thread threadForGame;

        int speedGame = 20;             // задание начальной скорости
        bool flagStartStop = true;

        public MainFormController()             // КОНСТРУКТОР
        {
            InitializeComponent();

            model = new Model(speedGame);
            view = new View(model);
            this.Controls.Add(view);            // добав пользов эл-нт управл (форма)
        }

        private void pictureGreenBtnStartPause_Click(object sender, EventArgs e)          // greenBtn - Start_Pause
        {
            if (flagStartStop)
            {
                pictureGreenBtnStartPause.Focus();           // для фокуса кнопки (для срабатывания изменения направления движ фигур / НАЗВ КНОПКИ)
                threadForGame = new Thread(model.PlayGame);
                threadForGame.Start();
                flagStartStop = !flagStartStop;
            }
            else
            {
                threadForGame.Abort();
                flagStartStop = !flagStartStop;
            }
        }
        /*private void button1_ClickStartStop(object sender, EventArgs e)          // обработка события
        {
            if (flagStartStop)
            {                
                threadForGame = new Thread(model.PlayGame);
                threadForGame.Start();
                flagStartStop = !flagStartStop;
            }
            else
            {
                threadForGame.Abort();
                flagStartStop = !flagStartStop;
            }
        }*/

        private void MainFormController_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadForGame != null)
                threadForGame.Abort();
        }

        private void pictureGreenBtn_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)       // greenBtn - keyMove
        {
            if (!flagStartStop)
                switch (e.KeyData.ToString())
                {
                    case "D":                    
                        if (model.Figure.CheckElMoveBorderRight())
                            foreach (Element ee in model.Figure.ElMove)
                            {
                                ee.XX += 30;
                            } break;
                    case "A":                    
                        if (model.Figure.CheckElMoveBorderLeft())
                            foreach (Element ee in model.Figure.ElMove)
                            {
                                ee.XX -= 30;
                            } break;
                    case "S":
                        if (model.Figure.CheckElMoveBeforeDown())
                            foreach (Element ee in model.Figure.ElMove)
                            {
                                ee.YY += 10;
                            } break;
                    case "W":
                        model.Figure.TurnFigure();
                        break;
                }
        }
        /*private void ButtonManagement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!flagStartStop)
                switch (e.KeyChar)
                {
                    case 'D':
                    case 'd':
                        if (model.Figure.CheckElMoveBorderRight())
                            foreach (Element ee in model.Figure.ElMove)
                            {
                                ee.XX += 30;
                            } break;
                    case 'A':
                    case 'a':
                        if (model.Figure.CheckElMoveBorderLeft())
                            foreach (Element ee in model.Figure.ElMove)
                            {
                                ee.XX -= 30;
                            } break;
                    case 'S':
                    case 's':
                        if (model.Figure.CheckElMoveBeforeDown())
                            foreach (Element ee in model.Figure.ElMove)
                            {
                                ee.YY += 10;
                            } break;
                    case 'W':
                    case 'w':
                        model.Figure.TurnFigure();
                        break;
                }
        }
        */
        private void pictureGreenMove_Click(object sender, EventArgs e)
        {
            if (threadForGame != null)
                threadForGame.Abort();
            flagStartStop = true;
            model.Figure.flagGame = true;
            model.Figure.NewGame();  
        }
        /*private void button1_NewGame_Click(object sender, EventArgs e)
        {
            if (threadForGame != null)
                threadForGame.Abort();
            flagStartStop = true;                        
            model.Figure.flagGame = true;
            model.Figure.NewGame();            
        }*/

        void GameOver()                        //  Н Е З А К О Н Ч Е Н О   (все ниже)
        {            
            threadForGame.Abort();
            MessageBox.Show("GAME OVER");
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(Convert.ToString(model.Figure.mb[15]));
        }
        
        private void MainFormController_Load(object sender, EventArgs e)
        {

        }
    }
}
