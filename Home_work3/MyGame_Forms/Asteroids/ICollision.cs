﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    interface ICollision
    {
        Rectangle Rect { get; }
        bool Collision(ICollision obj);
    }
}
