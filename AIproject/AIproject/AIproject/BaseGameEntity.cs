using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject
{
    abstract class BaseGameEntity
    {
        public abstract void Update(float time_elapsed);
        public abstract void Render();
        public abstract Rectangle GetSourceRectangle();
        public int ID { get; set; }
        public Vector2 pos { get; set; }
        public Vector2 rotation { get; set; }
        public float scale { get; set; }
        public float Bradius { get; set; }
        
    }
}
