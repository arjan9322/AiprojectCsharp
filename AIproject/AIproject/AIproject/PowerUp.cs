using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject
{
    class PowerUp : BaseGameEntity
    {
        private const int tileIndex = 5;
        const int TileWidth = 47;
        const int TileHeight = 47;
        const int SpriteWidth = 48;
        const int SpriteHeight = 48;
        public enum PowerUpType
        {
            Fuel,
            Repair,
            Points
        };

        public PowerUpType powerUpType;

        public PowerUp(PowerUpType _powerUpType)
        {
            powerUpType = _powerUpType;
            Random random = new Random();
            pos = new Vector2(random.Next(27)*47,random.Next(13)*47);
        }

        public override void Render(){
        }

        public override Rectangle GetSourceRectangle(){
            int tileY = tileIndex / (576 / TileWidth);
            int tileX = tileIndex % (576 / TileWidth);
            return new Rectangle(tileX * SpriteWidth, tileY * SpriteHeight, TileWidth, TileHeight);
        }
        
        public override void Update(float time_elapsed){
        }
    }
}
