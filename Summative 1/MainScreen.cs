using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Summative_1
{
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        { InitializeComponent();}
        private void button1_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();//Removinng the mainScreen usercontrol, and opening gameScreen
            f.Controls.Remove(this);

            GameScreen gs = new GameScreen();
            gs.Location = new Point((f.Width - gs.Width) / 2, (f.Height - gs.Height) / 2);//setting GameScreen location
            f.Controls.Add(gs);
            gs.Focus();//
        }
    }
}
