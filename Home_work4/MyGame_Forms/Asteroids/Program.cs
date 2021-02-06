// Кудряшов Сергей

// 1. Добавить в программу коллекцию астероидов. Как только она заканчивается
// (все астероиды сбиты), формируется новая коллекция, в которой на 1 астероид больше.

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
