using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Summative_1
{
    public partial class WinScreen : UserControl
    {
        //int lives;
        //public int X
        //{
        //    get { return lives; }
        //    set { lives = value; }
        //}
        public WinScreen()
        {
            InitializeComponent();
        }

        private void WinScreen_Load(object sender, EventArgs e)
        {

            if (Convert.ToInt32(Form1.lives) == 0)
            {
                diaLabel.Text = "You Lost";
                scoreLabel.Text = "Your score was " + Form1.score + " ;(";
           
            }
            if (Form1.lives == 3)
            {
                diaLabel.Text = "You Won"; 
                scoreLabel.Text = "Your score was " + Form1.score +" !";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            MainScreen gs = new MainScreen();
            f.Controls.Add(gs);
            Form1.score = 1000;
        }
    }
}

