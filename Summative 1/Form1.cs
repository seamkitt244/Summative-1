using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Summative_1
{
    public partial class Form1 : Form
    {
        
        public static int lives = 3;
        public static int score = 1000;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            MainScreen ms = new MainScreen();
            this.Controls.Add(ms);
            ms.Focus();
            Cursor.Hide();
        }
    }
}
