using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
namespace Summative_1
{
    public partial class WinScreen : UserControl
    {
        SoundPlayer win= new SoundPlayer(Properties.Resources.win);//sounds for win and lose
        SoundPlayer lose= new SoundPlayer(Properties.Resources.lose);
        public WinScreen()
        {
            InitializeComponent();
        }
        private void WinScreen_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Form1.lives) == 0)//displaying if the player wins or loses
            {
                diaLabel.Text = "You Lost";
                lose.Play();
            }
            else if (Form1.lives >0)
            {
                diaLabel.Text = "You Won";
                win.Play();
            }
            scoreLabel.Text = "Your score was " + Form1.score + " !";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void playButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            MainScreen ms = new MainScreen();
            ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);
            f.Controls.Add(ms);
            Form1.score = 1000;
            Form1.lives = 3;
            ms.Focus();
        }
    }
}

