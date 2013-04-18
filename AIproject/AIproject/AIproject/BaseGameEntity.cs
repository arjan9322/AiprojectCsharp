using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject
{
    abstract class BaseGameEntity
    {
        public int ID { get; set; }
        public Vector2 Pos { get; set; }
        public float Scale { get; set; }
        public float Bradius { get; set; }

        public abstract void Update(double time_elapsed);
        public abstract void Render();
    }
}
