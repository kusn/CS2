// Кудряшов Сергей

// 2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
// 3.Сделать так, чтобы при столкновениях пули с астероидом они регенерировались в разных концах экрана.
// 4. Сделать проверку на задание размера экрана в классе Game. Если высота или ширина (Width, Height)
// больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().
// 5. * Создать собственное исключение GameObjectException, которое появляется при попытке создать объект
// с неправильными характеристиками (например, отрицательные размеры, слишком большая скорость или позиция).

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
            SplashScreen.Draw();
            SplashScreen.Update();
        }
    }
}
