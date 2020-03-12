using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace Summative_1
{/// <summary>
/// Frogger type game by Seamus Kittmer March 4/2020
/// </summary>
    public partial class GameScreen : UserControl
    {
        #region variables
        //random generator
        public Random randGen = new Random();

        //Soundplayer
        SoundPlayer splat = new SoundPlayer(Properties.Resources.splat);

        //iamges
        public Image frogz = Properties.Resources.frogBack;
        Image blood = Properties.Resources.Untitled;
        // public static int lives = 3;
        int pattern = 2;
        int specialCounter = 0;

        // player control keys
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown, pKey;

        //lists for each element of the game
        List<Frog> carList = new List<Frog>();
        List<Frog> car2List = new List<Frog>();

        //frog declarations
        int frogSize = 30;
        int deadX, deadY;
        Image FROG;
        Frog frog;
        Frog car;
        Frog car2;

        //car dec
        int carOffset = -10;
        int carY1 = 100;
        int carY2 = 190;
        int carRightx = 570;
        int carRightx2 = 620;
        int carSize = 50;
        int carCounter = 0;
        int carCounter2 = 0;

        #endregion
        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }
        public void OnStart()
        {
            Form1.lives = 3;
            frog = new Frog(FROG, 250, this.Height * 90 / 100, frogSize);

            car = new Frog(carRightx, carY1, carSize);
            carList.Add(car);

            car2 = new Frog(carRightx2, carY2, carSize);
            car2List.Add(car2);
        }
        #region keydown/keyup
        private void GameScreen_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (frog.x > car2.x)
            {
                switch (e.KeyCode)//player button presses
                {
                    case Keys.Left:
                        leftArrowDown = true;
                        rightArrowDown = false;
                        downArrowDown = false;
                        break;
                    case Keys.Right:
                        rightArrowDown = true;
                        leftArrowDown = false;
                        downArrowDown = false;
                        break;
                    case Keys.Up:
                        upArrowDown = true;
                        rightArrowDown = false;
                        leftArrowDown = false;
                        break;
                    case Keys.Down:
                        downArrowDown = true;
                        rightArrowDown = false;
                        leftArrowDown = false;
                        break;
                    case Keys.P://pause button
                        pKey = true;
                        break;
                }
            }
        }
        private void checkBox1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {//player 1 button releases
                case Keys.Left:
                    leftArrowDown = false;
                    frog.Rest();
                    break;

                case Keys.Right:
                    rightArrowDown = false;
                    frog.Rest();
                    break;

                case Keys.Up:
                    upArrowDown = false;
                    frog.Rest();
                    break;

                case Keys.Down:
                    downArrowDown = false;
                    frog.Rest();
                    break;
                case Keys.P://pause button
                    pKey = false;
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)//unpause play button
        {
            pauseLabel.Visible = false;
            playButton.Visible = false;
            playButton.Enabled = false;
            exitButton.Enabled = false;
            exitButton.Visible = false;
            timer1.Enabled = true;
            this.Focus();
        }
        private void button2_Click(object sender, EventArgs e)//game exit button in pause screen
        {
            Application.Exit();
        }
        #endregion
        #region gameloop tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Frog car in carList)//update location of all cars (move accross screen)
            {
                car.Move("accross");
            }
            foreach (Frog car in car2List)
            {
                car.Move("accross");
            }

            if (carList[0].x < -carSize)//remove car if it has gone of screen
            {
                carList.RemoveAt(0);
            }

            if (car2List[0].x < -carSize)
            {
                car2List.RemoveAt(0);
            }

            if (carCounter == 15)//add new cars if it is time
            {
                carCounter = 0;
                specialCounter++;
                carRightx += carOffset;

                Frog car = new Frog(carRightx, carY1, carSize);
                carList.Add(car);

                if (specialCounter == pattern)//setting new pattern value
                {
                    car.Pattern();
                    specialCounter = 0;
                    pattern = randGen.Next(1, 8);
                }
            }
            if (carCounter2 == 14)//same thing but fro list two
            {
                carCounter2 = 0;
                specialCounter++;
                carRightx2 += carOffset;

                Frog car2 = new Frog(carRightx, carY2, carSize);
                car2List.Add(car2);

                if (specialCounter == pattern)//setting new pattern value
                {
                    carOffset = -carOffset;
                    specialCounter = 0;
                    pattern = randGen.Next(1, 8);
                }
            }
            #region frog move
            if (leftArrowDown) // move frog
            { frog.Move("left"); }

            if (rightArrowDown)
            { frog.Move("right"); }

            if (upArrowDown)
            { frog.Move("up"); }

            if (downArrowDown)
            { frog.Move("down"); }

            if (frog.x > this.Width)
            { frog.x = frog.x - 10; }

            if (frog.x < 0)
            { frog.x = frog.x + 10; }

            if (frog.x > this.Width)
            { frog.x = frog.x - 10; }

            if (frog.y > this.Height - frogSize)
            { frog.y = frog.y - 10; }
            #endregion
            #region pause the game
            if (pKey)//pause engaged
            {
                timer1.Enabled = false;
                pauseLabel.Visible = true;
                playButton.Enabled = true;
                playButton.Visible = true;
                exitButton.Enabled = true;
                exitButton.Visible = true;
            }
            #endregion
            #region collision/ win/ lose
            foreach (Frog c in carList.Union(car2List))
            { //check for collision between frog and cars
                if (c.Collision(frog))
                {
                    timer1.Enabled = false;
                    deadX = frog.x;
                    deadY = frog.y;
                    frog = new Frog(FROG, 250, this.Height * 90 / 100, frogSize);
                    Form1.lives--;
                    timer1.Enabled = true;
                    splat.Play();
                }
            }

            if (frog.y < frogSize || Form1.lives == 0)//win clause/lose clause, game loop is stopped
            {
                timer1.Enabled = false;
                Form f = this.FindForm();
                f.Controls.Remove(this);

                WinScreen ws = new WinScreen();
                ws.Location = new Point((f.Width - ws.Width) / 2, (f.Height - ws.Height) / 2);
                f.Controls.Add(ws);
                Form1.lives = 3;
            }
            #endregion
            carCounter++;//adding to car lists so that new cars will draw
            carCounter2++;
            if (car.x < 100)//taking away score
            { Form1.score = Form1.score - 1; }
            label2.Text = "Lives " + Form1.lives + " Score " + Form1.score;//displaying lives, and score
            Refresh();
        }
        #endregion
        #region paint 
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {//draw frog on screen

            if (Form1.lives < 3)///drawing the last place of death
            { e.Graphics.DrawImage(blood, deadX, deadY, frog.size, frog.size); }

            e.Graphics.DrawImage(frog.frogz, frog.x, frog.y, frog.size, frog.size);//drawing frog

            foreach (Frog c in carList)//drawing cars on screen
            {
                e.Graphics.DrawImage(c.carz, c.x + carOffset, c.y, c.size + 10, c.size);
            }
            foreach (Frog c in car2List)
            {
                e.Graphics.DrawImage(c.carz, c.x + carOffset, c.y, c.size + 10, c.size);
            }

        }
        #endregion
    }
}

