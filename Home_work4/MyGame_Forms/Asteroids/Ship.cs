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
        public static event Message MessageDie;
        public static event EMessageToLog MessageToLog;
        private int _energy = 100;
        private int score = 0;
        public int Energy => _energy;
        public int Score => score;
        static Image Image { get; } = Image.FromFile("Images\\ship.png");

        public void EnergyLow(int n)
        {
            _energy -= n;
            MessageToLog?.Invoke($"Энергия убавилась на {n}. Энергия = {_energy}.");
        }

        public void EnergyUp(int n)
        {
            _energy += n;
            MessageToLog?.Invoke($"Энергия прибавилась на {n}. Энергия = {_energy}.");
        }

        public void ScoreUp()
        {
            score++;
            MessageToLog?.Invoke($"Астероид сбит. Количество очков = {score}.");
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

        public void Right()
        {
            if (Pos.X < Game.Height) Pos = new Point(Pos.X + Dir.X, Pos.Y);
        }

        public void Left()
        {
            if (Pos.X > 0) Pos = new Point(Pos.X - Dir.X, Pos.Y);
        }

        public void SetPos(Point pos)
        {
            Pos = pos;
        }
        public void Die()
        {
            MessageDie?.Invoke();
            MessageToLog?.Invoke("Корабль погиб!");            
        }
        public Point GetPos => Pos;

        public int GetEnergy => _energy;
    }
}
