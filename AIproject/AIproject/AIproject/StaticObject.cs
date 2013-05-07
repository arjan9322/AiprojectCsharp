using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace AIproject
{
    class StaticObject : BaseGameEntity
    {
        static public Texture2D ObjectTexture;

        static public int TileWidth = 48;
        static public int TileHeight = 48;

        static public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (ObjectTexture.Width / TileWidth);
            int tileX = tileIndex % (ObjectTexture.Width / TileWidth);

            return new Rectangle(tileX * TileWidth, tileY * TileHeight, TileWidth, TileHeight);
        }

        StaticObject(float _x, float _y){
            pos = new Vector2(_x, _y);
        }

        public override void Render()
        {
            
        }

        public override void Update(float time_elapsed)
        {
            throw new NotImplementedException();
        }
    }
}
