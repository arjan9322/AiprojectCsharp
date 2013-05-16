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
        static public Vector2 steeringForce;

        public static int tileIndex = 7;

        static public int TileWidth = 47;
        static public int TileHeight = 47;
        static public int SpriteWidth = 48;
        static public int SpriteHeight = 48;
        public SteeringBehaviours steeringBehaviour;

        public override Rectangle GetSourceRectangle()
        {
            int tileY = tileIndex / (576 / TileWidth);
            int tileX = tileIndex % (576 / TileWidth);

            return new Rectangle(tileX * SpriteWidth, tileY * SpriteHeight, TileWidth, TileHeight);
        }

        public Vehicle(Vector2 startingPos)
        {
            pos = startingPos;
            Velocity = new Vector2();
            steeringBehaviour = new SteeringBehaviours(this);
            //world = GameWorld.GetInstance();
        }

        public override void Render(){
        }

        public override void Update(float time_elapsed)
        {
            // create steering force dependent on steeringbehaviours
            steeringForce = steeringBehaviour.Calculate();
            rotation = steeringForce;
            Vector2 acceleration = steeringForce / Mass;

            Velocity += acceleration * time_elapsed;

            Velocity = VectorHelper.MaxLimit(Velocity, MaxSpeed);
            if (Velocity.Length() > 0.001) 
                rotation = Velocity * time_elapsed;
            pos += Velocity * time_elapsed;

            //do update heading here
        }
    }
}
