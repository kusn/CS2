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
        private int _energy = 100;
        public int Energy => _energy;
        static Image Image { get; } = Image.FromFile("Images\\ship.png");

        public void EnergyLow(int n)
        {
            _energy -= n;
        }

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

        public void Up()
        {
            if (Pos.Y > 0) Pos = new Point(Pos.X, Pos.Y - Dir.Y);
        }

        public void Down()
        {
            if (Pos.Y < Game.Height) Pos = new Point(Pos.X, Pos.Y + Dir.Y);
        }
        public void Die()
        {
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
