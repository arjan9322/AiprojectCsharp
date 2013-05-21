using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject.Goals
{
    class GetPoints : Goal // find and follow route to closest points
    {
        private Vehicle parent;
        private List<Vector2> path; 
        public GetPoints(Vehicle _parent)
        {
            parent = _parent;
            parent.steeringBehaviour.SeekOn();
            parent.steeringBehaviour.FleeOff();
            parent.steeringBehaviour.ExploreOff();
            parent.steeringBehaviour.ArriveOff();
            Update();
        }

        public override void Update()
        {
            if (path == null)
                path = parent.game.pathfinder.FindPath(new Point((int) parent.pos.X, (int) parent.pos.Y), ClosestObject());
            parent.steeringBehaviour.SetTarget(path[0]);
            
            if ((parent.pos - path[0]).Length() < 5f)
                path.Remove(path[0]);
        }

        public Vector2 ClosestObjectvector()
        {
            float closestlength = float.MaxValue;
            int closestnumber = int.MaxValue;
            int number = 0;

            foreach (PowerUp powerUp in GameWorld.GetInstance().PowerUps)
            {
                if (powerUp.powerUpType == PowerUp.PowerUpType.Points)
                {
                    if ((parent.pos - powerUp.pos).Length() < closestlength)
                    {
                        closestlength = (parent.pos - powerUp.pos).Length();
                        closestnumber = number;
                    }
                }
                number++;
            }
            return GameWorld.GetInstance().PowerUps[closestnumber].pos;
        }

        public Point ClosestObject()
        {
            float closestlength = float.MaxValue;
            int closestnumber = int.MaxValue;
            int number = 0;
            
            foreach (PowerUp powerUp in GameWorld.GetInstance().PowerUps)
            {
                if (powerUp.powerUpType == PowerUp.PowerUpType.Points)
                {
                    if ((parent.pos - powerUp.pos).Length() < closestlength)
                    {
                        closestlength = (parent.pos - powerUp.pos).Length();
                        closestnumber = number;
                    }
                }
                number++;
            }
            return new Point((int)GameWorld.GetInstance().PowerUps[closestnumber].pos.X, (int)GameWorld.GetInstance().PowerUps[closestnumber].pos.Y);
        }
    }
}
