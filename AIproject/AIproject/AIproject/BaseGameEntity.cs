using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject
{
    class BaseGameEntity
    {
        public int ID { get; set; }
        public Vector2 pos { get; set; }
        public float scale { get; set; }
        public float Bradius { get; set; }
    }
}
