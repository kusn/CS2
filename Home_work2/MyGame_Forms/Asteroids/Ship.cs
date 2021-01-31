using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class Ship : BaseObject
    {
        static Image Image { get; } = Image.FromFile("Images\\ship.png");

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }

        public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y);
            if (Pos.X > Game.Width)
                Pos = new Point(0, Game.Random.Next(0, Game.Height));
        }

        /*public int GetX
        {
            get
            {
                return Pos.X;
            }
        }*/
    }
}
