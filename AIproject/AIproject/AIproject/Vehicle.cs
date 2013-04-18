using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AIproject
{
    class Vehicle : MovingEntity
    {
        static public Texture2D CarSetTexture;

        static public int TileWidth = 48;
        static public int TileHeight = 48;

        public Vehicle(Vector2 startingPos)
        {
            Vector2 Pos = startingPos;
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
