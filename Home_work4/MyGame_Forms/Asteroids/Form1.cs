// Кудряшов Сергей

// 1.Добавить космический корабль, как описано в уроке.
// 2. Добработать игру «Астероиды».
// а) Добавить ведение журнала в консоль с помощью делегатов;
// б) *Добавить это и в файл.
// 3. Разработать аптечки, которые добавляют энергию.
// 4. Добавить подсчет очков за сбитые астероиды.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Asteroids
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            form.FormClosed += Form_FormClosed;
            Game.Init(form);
            form.Show();
            this.Hide();
            Game.Draw();            
    }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            SplashScreen.Init(this);            
        }
    }
}
