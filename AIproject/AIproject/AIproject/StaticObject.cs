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
        public static int tileIndex = 98;
        static public Texture2D texture;

        static public int TileWidth = 47;
        static public int TileHeight = 47;
        static public int SpriteWidth = 48;
        static public int SpriteHeight = 48;

        StaticObject(float _x, float _y){
            pos = new Vector2(_x, _y);
        }

        public override void Render(){
        }

        public override void Update(float time_elapsed)
        {
            throw new NotImplementedException();
        }

        public override Rectangle GetSourceRectangle()
        {
            int tileY = tileIndex / (texture.Width / TileWidth);
            int tileX = tileIndex % (texture.Width / TileWidth);

            return new Rectangle(tileX * SpriteWidth, tileY * SpriteHeight, TileWidth, TileHeight);
        }
    }
}
