using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class BsObj_SplshScreen
    {
        protected Point Pos { get; set; }//X,Y
        protected Point Dir { get; set; }//X,Y
        protected Size Size { get; set; }

        static Image Image { get; } = Image.FromFile("Images\\asteroid.png");
        //static Image asteroid = Image.FromFile("Images\\asteroid.png");

        public BsObj_SplshScreen()
        {
            Pos = new Point(0, 0);
            Dir = new Point(0, 0);
            Size = new Size(0, 0);
        }
        public BsObj_SplshScreen(Point pos, Point dir, Size size)
        {
            this.Pos = pos;
            this.Dir = dir;
            this.Size = size;
        }

        public virtual void Draw()
        {            
            SplashScreen.Buffer.Graphics.DrawImage(Image, Pos);
        }

        public virtual void Update()
        {
            Pos = new Point(Pos.X - Dir.X, Pos.Y + Dir.Y);
            if (Pos.X < 0 || Pos.X > SplashScreen.Width)
                //Pos = new Point(SplashScreen.Width / 2, SplashScreen.Height / 2 + Dir.Y);
                Pos = new Point(SplashScreen.rnd.Next(0, SplashScreen.Width), SplashScreen.rnd.Next(0, SplashScreen.Height));
            if (Pos.Y < 0 || Pos.Y > SplashScreen.Height)
                //Pos = new Point(SplashScreen.Width / 2 - Dir.X, SplashScreen.Height / 2);
                Pos = new Point(SplashScreen.rnd.Next(0, SplashScreen.Width), SplashScreen.rnd.Next(0, SplashScreen.Height));
        }
    }
}
