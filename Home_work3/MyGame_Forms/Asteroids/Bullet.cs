using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class Bullet : BaseObject
    {
        static Image Image { get; } = Image.FromFile("Images\\bullet.png");

        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, 50, 36);
        }

        public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y);
            /*if (Pos.X > Game.Width)
                Pos = new Point(0, Game.Random.Next(0, Game.Height));*/
        }
    }
}
