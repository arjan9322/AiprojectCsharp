using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject
{
    abstract class MovingEntity : BaseGameEntity
    {
        enum Decelaration { slow = 3, normal = 2, fast = 1 };
        public abstract override void Update(float time_elapsed);
        public abstract override void Render();
        public abstract override Rectangle GetSourceRectangle();
        public Vector2 Velocity { get; set; }
        public Vector2 Heading { get; set; }
        public float Mass { get; set; }
        public float MaxSpeed { get; set; }
        public float MaxForce { get; set; }
        public float MaxTurnRate { get; set; }
    }
        
}
