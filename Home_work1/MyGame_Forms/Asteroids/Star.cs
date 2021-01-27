using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class Star : BaseObject
    {        
        static Image Image { get; } = Image.FromFile("Images\\star.png");


        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }

        public override void Update()
        {
            Pos = new Point(Pos.X - Dir.X, Pos.Y + Dir.Y);
            if (Pos.X < 0 || Pos.X > Game.Width)
                //Dir = new Point(-Dir.X, Dir.Y);
                Pos = new Point(Game.Width, Pos.Y + Dir.Y);
            if (Pos.Y < 0 || Pos.Y > Game.Height)
                //Dir = new Point(Dir.X, -Dir.Y);
                Pos = new Point(Pos.X - Dir.X, Game.Height);
        }
    }
}
