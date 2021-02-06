using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class FirstAidKit : BaseObject
    {
        static Image Image { get; } = Image.FromFile("Images\\firstaidkit.png");        

        public FirstAidKit(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {            
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, 20, 20);
        }

        public override void Update()
        {
            Pos = new Point(Pos.X - Dir.X, Pos.Y + Dir.Y);
            if (Pos.X < 0 || Pos.X > Game.Width)                
                Pos = new Point(Game.Width, Game.Random.Next(0, Game.Height + Dir.Y));
            if (Pos.Y < 0 || Pos.Y > Game.Height)                
                Pos = new Point(Pos.X - Dir.X, Game.Height);
        }
    }
}
