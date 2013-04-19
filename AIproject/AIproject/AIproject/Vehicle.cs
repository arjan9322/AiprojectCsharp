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
        static public Texture2D CarTexture;

        static public int TileWidth = 48;
        static public int TileHeight = 48;

       

        public Vehicle(Vector2 startingPos)
        {
            pos = startingPos;
            Velocity = new Vector2();
        }
        public override void Render()
        {
            /*spriteCar.Begin();
            spriteCar.Draw(Vehicle.CarTexture, pos, Tile.GetSourceRectangle(7), Color.White, RotationAngle2, cannonOrigin, 1.0f, SpriteEffects.None, 0f);
            spriteCar.End();
            throw new NotImplementedException();*/
        }
        public override void Update(double time_elapsed)
        {
            throw new NotImplementedException();
        }
    }
}
