// Кудряшов Сергей

//1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полёт в звёздном пространстве.
//2. * Заменить кружочки картинками, используя метод DrawImage.
//3. *Разработать собственный класс заставка SplashScreen, аналогичный классу Game в котором создайте собственную иерархию объектов и задайте их движение.
// Предусмотреть кнопки - Начало игры, Рекорды, Выход.Добавить на заставку имя автора.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Activate();
            this.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Width = 1024;
            form.Height = 768;
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
            SplashScreen.Draw();
            SplashScreen.Update();
        }
    }
}
