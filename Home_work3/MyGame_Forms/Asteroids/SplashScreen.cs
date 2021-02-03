using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    class SplashScreen
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

        static public BsObj_SplshScreen[] objs;

        static Timer timer;

        static public Random rnd = new Random();
        static double multi = 180.0 / Math.PI;
        static double multi1 = 360 / 10;

        static SplashScreen()
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
            //form.FormClosing += Form_FormClosing;
            //form.KeyPress += Form_KeyPress;             // Реакция на нажатие клавиш
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            SplashScreen.Draw();
            SplashScreen.Update();
        }

        static void Load()
        {
            objs = new BsObj_SplshScreen[10];
            for (int i = 0; i < 10; i++)
            {
                Point p = GetPos();
                //objs[i] = new BsObj_SplshScreen(new Point(Width / 2, Height / 2), new Point((int)(Game.Random.Next(2, 6) * Math.Cos(i * multi1 * multi)), (int)(Game.Random.Next(2, 6) * Math.Sin(i * multi1 * multi))), new Size(20, 20));
                objs[i] = new BsObj_SplshScreen(p, GetDir(p), new Size(20, 20));
            }


            //for (int i = 5; i < 10; i++)
            //objs[i] = new BsObj_SplshScreen(new Point(Width / 2, Height / 2), new Point((int)(Game.Random.Next(2, 6) * Math.Cos(i * multi1 * multi)), (int)(Game.Random.Next(2, 6) * Math.Sin(i * multi1 * multi))), new Size(20, 20));
            /*for (int i = 6; i < 20; i++)
                objs[i] = new Star(new Point(rnd.Next(0, Width), rnd.Next(0, Height)), new Point(1, 0), new Size(20, 20));
            for (int i = 20; i < 40; i++)
                objs[i] = new Dust(new Point(rnd.Next(0, Width), rnd.Next(0, Height)), new Point(rnd.Next(100, 100), 0), new Size(20, 20));*/

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

        static public Point GetPos()
        {
            return new Point(rnd.Next(0, SplashScreen.Width), rnd.Next(0, SplashScreen.Height));
        }

        static public Point GetDir(Point p)
        {
            int k = rnd.Next(2, 6);
            return new Point((int)(k * Math.Cos(Math.Atan2(p.Y - SplashScreen.Height / 2, p.X - SplashScreen.Width / 2))), (int)(k * Math.Sin(Math.Atan2(p.Y - SplashScreen.Height / 2, p.X - SplashScreen.Width / 2))));
        }
    }
}
