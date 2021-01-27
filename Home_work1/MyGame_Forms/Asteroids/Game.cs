using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        static public ulong Timer { get; private set; } = 0;

        static BufferedGraphicsContext context;
        static public BufferedGraphics Buffer { get; private set; }

        // Свойства
        // Ширина и высота игрового поля

        static public Random Random { get; } = new Random();
        static public int Width { get; private set; }
        static public int Height { get; private set; }
        static public Image background = Image.FromFile("Images\\fon.jpg");

        static public BaseObject[] objs;

        static Timer timer;
        
        static Random rnd = new Random();

        static Game()
        {

        }

        static public void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            timer = new Timer();
            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();// Создаём объект - поверхность рисования и связываем его с формой
                                      // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом.
            // для того, чтобы рисовать в буфере
            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
            timer.Interval = 100;
            timer.Tick += Timer_Tick; ;
            timer.Start();
            Load();
            form.FormClosing += Form_FormClosing;
            form.KeyPress += Form_KeyPress;
        }

        private static void Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\u001b')
            {
                MessageBox.Show("");
                timer.Stop();
            }
        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Game.Draw();
            Game.Update();
        }

        static void Load()
        {
            objs = new BaseObject[40];
            for (int i = 0; i < 6; i++)
                objs[i] = new BaseObject(new Point(Width, rnd.Next(Height * i / 6, Height * (i + 1) / 6)), new Point(10, 0), new Size(20, 20));
            for (int i = 6; i < 20; i++)
                objs[i] = new Star(new Point(rnd.Next(0, Width), rnd.Next(0, Height)), new Point(1, 0), new Size(20, 20));
            for (int i = 20; i < 40; i++)
                objs[i] = new Dust(new Point(rnd.Next(0, Width), rnd.Next(0, Height)), new Point(rnd.Next(100, 100), 0), new Size(20, 20));

        }

        static public void Draw()
        {
            //Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(background, 0, 0);
            //Buffer.Graphics.DrawRectangle(Pens.White, 10, 10, 100, 200);
            foreach (var obj in objs)
            {
                obj.Draw();
            }
            Buffer.Render();
        }
        static public void Update()
        {
            foreach (var obj in objs)
                obj.Update();
        }

    }
}
