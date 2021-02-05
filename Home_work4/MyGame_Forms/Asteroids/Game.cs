using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.IO;

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
        static private Image background = Image.FromFile("Images\\fon.jpg");
        static private Image png_pause = Image.FromFile("Images\\pause.png");
        static private Image bang = Image.FromFile("Images\\Bang.png");
        static private System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        //static public StreamWriter sw = new StreamWriter("Logs\\Game.log", true);

        static public List<Asteroid> asteroids;
        static public Dust[] dust;
        static public Star[] stars;
        static public List<Bullet> bullets;
        static public List<FirstAidKit> aidKits;
        private static Ship ship;

        static Timer timer;
        static public int Health { get; private set; } = 100;
        static bool pause = false;
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
            if (Width > Screen.PrimaryScreen.Bounds.Size.Width || Height > Screen.PrimaryScreen.Bounds.Size.Height) //Обрабатываем исключение "Превышен размер окна".
                throw new ArgumentOutOfRangeException($"Задан слишком большой размер окна. Необходимо не более {Screen.PrimaryScreen.Bounds.Size.Width}х{Screen.PrimaryScreen.Bounds.Size.Height} пкс.");
            // Связываем буфер в памяти с графическим объектом.
            // для того, чтобы рисовать в буфере
            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            player.SoundLocation = "Sounds\\bang.wav";
            timer.Interval = 100;
            timer.Tick += Timer_Tick; ;
            timer.Start();
            Load();                        
            form.FormClosing += Form_FormClosing;
            form.KeyDown += Form_KeyDown;             // Реакция на нажатие клавиш
            Ship.MessageDie += Finish;
            Ship.MessageToLog += ToLog;
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)                  // Если нажать "Esc"
            {
                if(pause == false)
                {
                    timer.Stop();
                    Buffer.Graphics.DrawImage(png_pause, Width/2 - png_pause.Width / 2, Height / 2 - png_pause.Height / 2);
                    Buffer.Render();
                    pause = true;
                }
                else
                {
                    timer.Start();
                    pause = false;
                }
            }
            else if (e.KeyCode == Keys.Space)
                bullets.Add(new Bullet(new Point(ship.Rect.X + 10, ship.Rect.Y + 4), new Point(10, 0), new Size(4, 1)));
            else if (e.KeyCode == Keys.Up) ship.Up();
            else if (e.KeyCode == Keys.Down) ship.Down();
            else if (e.KeyCode == Keys.Right) ship.Right();
            else if (e.KeyCode == Keys.Left) ship.Left();


        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e)     // Закрытие окна
        {
            timer.Stop();
            //sw.Close();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Game.Draw();
            Game.Update();
        }

        static void Load()
        {
            asteroids = new List<Asteroid>();
            dust = new Dust[20];
            stars = new Star[14];
            aidKits = new List<FirstAidKit>();

            for (int i = 0; i < 6; i++)
               asteroids.Add(new Asteroid(new Point(Width, rnd.Next(Height * i / 6, Height * (i + 1) / 6)), new Point(rnd.Next(5, 10), 0), new Size(79, 79)));
            for (int i = 0; i < stars.Length; i++)
                stars[i] = new Star(new Point(rnd.Next(0, Width), rnd.Next(0, Height)), new Point(1, 0), new Size(20, 20));
            for (int i = 0; i < dust.Length; i++)
                dust[i] = new Dust(new Point(rnd.Next(0, Width), rnd.Next(0, Height)), new Point(rnd.Next(100, 100), 0), new Size(20, 20));
            for (int i = 0; i < 5; i++)
                aidKits.Add(new FirstAidKit(new Point(Width, rnd.Next(Height * i / 5, Height * (i + 1) / 5)), new Point(rnd.Next(5, 10), 0), new Size(20, 20)));
            
            ship = new Ship(new Point(0, 300), new Point(2, 4), new Size(30, 30));
            bullets = new List<Bullet>();
            Bullet.OutofScreen += Bullet_OutofScreen;
        }

        private static void Bullet_OutofScreen(Bullet bullet)
        {
            bullets.Remove(bullet);
        }

        static public void Draw()
        {
            Buffer.Graphics.DrawImage(background, 0, 0);
            foreach (var obj in stars)
            {
                obj.Draw();
            }
            foreach (var obj in dust)
            {
                obj.Draw();
            }
            foreach (var obj in aidKits)
            {
                obj?.Draw();
            }
            foreach (var obj in asteroids)
            {
                obj?.Draw();
            }
            foreach (Bullet bullet in bullets)
            {
                bullet.Draw();
            }
            ship?.Draw();
            if (ship != null)
            {
                Buffer.Graphics.DrawString("Energy:" + ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString("Score:" + ship.Score, SystemFonts.DefaultFont, Brushes.White, 0, 15);
            }
            Buffer.Render();
        }
        static public void Update()
        {
            
            for(int i = 0; i < asteroids.Count; i++)
            {
                asteroids[i].Update();
                for (int k = 0; k < bullets.Count; k++)
                {
                    if (bullets.Count > 0 && asteroids.Count > 0 && asteroids[i].Collision(bullets[k]))
                    {
                        Bang(asteroids[i]);
                        asteroids.RemoveAt(i);
                        i--;                        
                        bullets.RemoveAt(k);
                        k--;
                        ship.ScoreUp();                        
                    }
                }
                if (i > 0 && ship != null && asteroids[i].Collision(ship))
                {
                    Bang(asteroids[i]);
                    asteroids.RemoveAt(i);
                    i--;
                    ship.EnergyLow(rnd.Next(1, 10));
                    if (ship.Energy <= 0) ship.Die();
                }                
            }
            
            for(int j = 0; j < aidKits.Count; j++)
            {
                int e;
                aidKits[j].Update();                
                if (j > 0 && ship != null && aidKits[j].Collision(ship))
                {
                    aidKits.RemoveAt(j);                    
                    aidKits.Add(new FirstAidKit(new Point(Width, rnd.Next(0, Height)), new Point(rnd.Next(5, 10), 0), new Size(20, 20)));
                    e = rnd.Next(1, 10);
                    ship.EnergyUp(e);                    
                }
            }

            foreach (var obj in stars)
                obj.Update();
            foreach (var obj in dust)
                obj.Update();
            for(int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
            }
            ship.Update();
        }

        static private void Bang(BaseObject obj)
        {            
            player.Play();
            Buffer.Graphics.DrawImage(bang, obj.Rect.X, obj.Rect.Y, 100, 100);
            Buffer.Render();
            //System.Media.SystemSounds.Hand.Play(); 
        }

        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

        public static void ToLog(string s)
        {            
            Console.WriteLine(s);            
            //sw.WriteLine(s);
            try
            {
                using (StreamWriter sw = new StreamWriter("..\\..\\Game.log", true))
                {
                    sw.Write(s);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
    }
}
