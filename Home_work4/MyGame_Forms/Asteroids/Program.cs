// Кудряшов Сергей

//1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полёт в звёздном пространстве.
//2. * Заменить кружочки картинками, используя метод DrawImage.
//3. *Разработать собственный класс заставка SplashScreen, аналогичный классу Game в котором создайте собственную иерархию объектов и задайте их движение.
// Предусмотреть кнопки - Начало игры, Рекорды, Выход.Добавить на заставку имя автора.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
