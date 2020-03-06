using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Summative_1
{
    class Frog
    {
        #region global variables
        public int x, y, size;
        public int carOffset = -10;
        public Random randGen = new Random();//random genorator
        public Image carz = Properties.Resources.car2;//these images are used to hold different images 
        public Image frogz = Properties.Resources.frogBack;//when either a car or frog moves
        Image frogBack = Properties.Resources.frogBack;//iamges
        Image frogLSide = Properties.Resources.frogLside;//frog images for movement
        Image frogSide = Properties.Resources.frogSide;
        Image frogJump = Properties.Resources.frogJump;//
        Image car = Properties.Resources.carLeft;
        Image car2 = Properties.Resources.car2;
        #endregion
        public Frog(int _x, int _y, int _size)//constructor method
        {
            x = _x;
            y = _y;
            size = _size;

            int randValue = randGen.Next(1, 3);

            if (randValue == 1)
            { carz = car; }

            else if (randValue == 2)
            { carz = car2; }
        }
        public Frog(Image _carz, int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
            carz = _carz;
        }
        #region Move
        public void Move(string direction)
        {
            if (direction == "left")
            {
                x = x - 10;
                frogz = frogLSide;
            }

            if (direction == "right")
            {
                x = x + 10;
                frogz = frogSide;
            }
            if (direction == "up")
            {
                y = y - 10;
                frogz = frogJump;
            }

            if (direction == "down")
            {
                y = y + 10;
                frogz = frogBack;
            }

            if (direction == "accross")
            { x = x - 10; }
        }
        #endregion
        public void Rest()//draws frog sprite in idle position
        {
            frogz = frogBack;
        }
        public void Pattern()//sets random interaval for cars to be drawn
        {
            int patt = randGen.Next(1, 8);

            if (patt == 1)
            { carOffset = carOffset + 5; }

            if (patt == 2)
            { carOffset = carOffset + 7; }

            if (patt == 3)
            { carOffset = carOffset + 10; }

            if (patt == 4)
            { carOffset = carOffset + 12; }

            if (patt == 5)
            { carOffset = carOffset + 15; }

            if (patt == 6)
            { carOffset = carOffset + 20; }

            if (patt == 7)
            { carOffset = carOffset + 22; }
        }
        public Boolean Collision(Frog g)
        {
            Rectangle frogRec = new Rectangle(g.x, g.y, g.size, g.size);
            Rectangle carRec = new Rectangle(x, y, size, size);

            if (frogRec.IntersectsWith(carRec))
            { return true; }

            else
            { return false; }
        }
    }
}
