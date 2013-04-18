using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace AIproject
{
    class Vehicle : MovingEntity
    {
        public Vehicle(Vector2 startingPos)
        {
            Pos = startingPos;
            Velocity = new Vector2();
        }
        public override void Render()
        {
            throw new NotImplementedException();
        }
        public override void Update(double time_elapsed)
        {
            throw new NotImplementedException();
        }
    }
}
