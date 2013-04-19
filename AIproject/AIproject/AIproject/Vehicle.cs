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
        public SteeringBehaviours steeringBehaviour;
        //GameWorld world;

        public Vehicle(Vector2 startingPos)
        {
            pos = startingPos;
            Velocity = new Vector2();
            steeringBehaviour = new SteeringBehaviours(this);
            //world = GameWorld.GetInstance();
        }

        public override void Render()
        {
//             VertexPositionColor[] vertex = new VertexPositionColor[4];
//             vertex[0] = new VertexPositionColor(new Vector3(pos.X-5,pos.Y-5, 0), Color.Red);
//             vertex[1] = new VertexPositionColor(new Vector3(pos.X+5,pos.Y+5, 0), Color.Red);
//             vertex[2] = new VertexPositionColor(new Vector3(pos.X - 5, pos.Y + 5, 0), Color.Red);
//             vertex[3] = new VertexPositionColor(new Vector3(pos.X + 5, pos.Y - 5, 0), Color.Red);

            

            /*spriteCar.Begin();
            spriteCar.Draw(Vehicle.CarTexture, pos, Tile.GetSourceRectangle(7), Color.White, RotationAngle2, cannonOrigin, 1.0f, SpriteEffects.None, 0f);
            spriteCar.End();*/
        }
        public override void Update(float time_elapsed)
        {
            // create steering force dependent on steeringbehaviours
            Vector2 steeringForce = steeringBehaviour.Calculate();

            Vector2 acceleration = steeringForce / Mass;

            Velocity += acceleration * time_elapsed;

            Velocity = VectorHelper.ToLimit(Velocity, MaxSpeed);

            pos += Velocity * time_elapsed;

            //do update heading here

        }
    }
}
