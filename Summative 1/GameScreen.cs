using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace Summative_1
{
    public partial class GameScreen : UserControl
    {
        #region variables
        //random generator
        Random randGen = new Random();

        int dis1, dis2;
        int z = 0;
        int pattern = 2;
        int specialCounter = 0;

        // player control keys
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown, pKey, pause;
        Boolean carCheck, car2Check = false;
        Boolean skin = true;
        //lists for each element of the game
        List<Frog> carList = new List<Frog>();
        List<Frog> car2List = new List<Frog>();

        //frog declarations
        int frogSize = 30;
        Image FROG;
        Frog frog;

        //car dec
        int carOffset = -10;
        int carY1 = 100;
        int carY2 = 200;
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
            frog = new Frog(FROG, 30, this.Height * 90 / 100, frogSize);

            Frog car = new Frog(carRightx, carY1, carSize);

            carList.Add(car);


            Frog car2 = new Frog(carRightx2, carY2, carSize);

            car2List.Add(car2);

        }
        #region keydown/keyup

        private void GameScreen_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.P:
                    pKey = true;
                    if (pause = true)
                    {
                        label1.Visible = false;
                        timer1.Enabled = true; 
                    }
                    pause = false;
                    break;
            }
        }

        private void checkBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
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
                case Keys.P:
                    pKey = false;
                    z++;
                    break;
            }
        }
        #endregion
        #region gameloop tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            //update location of all cars (move accross screen)
            foreach (Frog car in carList)
            {
                car.Move("accross");
            }
            foreach (Frog car in car2List)
            {
                car.Move("accross");
            }
            //remove car if it has gone of screen
            if (carList[0].x < -carSize)
            {
                carList.RemoveAt(0);
            }
            if (car2List[0].x < -carSize)
            {
                car2List.RemoveAt(0);
            }

            //add new cars if it is time
            if (carCounter == 10)
            {
                carCounter = 0;

                carRightx += carOffset;

                Frog car = new Frog(carRightx, carY1, carSize);
                carList.Add(car);

                if (specialCounter == pattern)
                {
                    car.Pattern();
                    specialCounter = 0;
                    pattern = randGen.Next(1, 8);
                }
            }
            if (carCounter2 == 10)
            {
                carCounter2 = 0;

                specialCounter++;

                carRightx2 += carOffset;

                Frog car2 = new Frog(carRightx, carY2, carSize);
                car2List.Add(car2);

                if (specialCounter == pattern)
                {
                    carOffset = -carOffset;
                    specialCounter = 0;
                    pattern = randGen.Next(1, 8);
                }
            }
            #region frog move
            // move frog
            if (leftArrowDown)
            {
                frog.Move("left");
            }
            if (rightArrowDown)
            {
                frog.Move("right");
            }
            if (upArrowDown)
            {
                frog.Move("up");
            }
            if (downArrowDown)
            {
                frog.Move("down");
            }
            if (frog.x > this.Width)
            { frog.x = frog.x - 10; }

            if (frog.x < 0)
            { frog.x = frog.x + 10; }

            if (frog.y > this.Height - frogSize)
            { frog.y = frog.y - 10; }
            #endregion
            #region pause
            if (pKey)
            {
                timer1.Enabled = false;
                pause = true;
                label1.Visible = true;
            }
            #endregion
            #region collision 
            //check for collision between frog and cars
            foreach (Frog c in carList.Union(car2List))
            {
                if (c.Collision(frog))
                {
                    timer1.Enabled = false;
                }
            }
            #endregion

            carCounter++;
            carCounter2++;
            Refresh();
        }
        #endregion
        #region paint 

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw frog on screen
            e.Graphics.DrawImage(frog.frogz, frog.x, frog.y, frog.size, frog.size);

            //cars on screen
            foreach (Frog c in carList)
            {
                e.Graphics.DrawImage(c.carz, c.x, c.y, c.size + 10, c.size);
            }
            foreach (Frog c in car2List)
            {
                e.Graphics.DrawImage(c.carz, c.x, c.y, c.size + 10, c.size);
            }
        }
        #endregion
    }
}

