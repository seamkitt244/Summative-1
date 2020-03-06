using System;
using System.Drawing;
using System.Windows.Forms;
namespace Summative_1
{
    /// <summary>
    /// Frogger tyep game, Seamus Kittmer, March 5,2020
    /// </summary>
    public partial class Form1 : Form
    {
        public static int lives = 3;//public static varablies for player score,
        public static int score = 1000;// and player lives
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            MainScreen ms = new MainScreen();
            this.Controls.Add(ms);//opening the main screen usercontrol
            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
            ms.Focus();
            Cursor.Hide();
        }
    }
}
