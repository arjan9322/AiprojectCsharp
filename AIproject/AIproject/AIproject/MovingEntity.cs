using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject
{
    class MovingEntity : BaseGameEntity
    {

        public Vector2 velocity { get; set; }
        public Vector2 heading { get; set; }
        public float mass { get; set; }
        public float maxSpeed { get; set; }
        public float maxForce { get; set; }
        public float maxTurnRate { get; set; }
    }
}
