using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject
{
    enum Dec{ slow = 3, normal = 2, fast = 1 };
    class SteeringBehaviours
    {
        
        bool SeekBehaviour;
        bool FleeBehaviour;
        bool ArriveBehaviour;
        public Vector2 Target;

        Vehicle parent;
        public SteeringBehaviours(Vehicle parent)
        {
            SeekBehaviour = false;
            FleeBehaviour = false;
            ArriveBehaviour = false;
            this.parent = parent;
        }

        private Vector2 Seek()
        {
            Vector2 DesiredSpeed = new Vector2();
            DesiredSpeed = Target - parent.pos;
            DesiredSpeed = VectorHelper.ToLimit(DesiredSpeed, parent.MaxSpeed);
            
            Vector2 seekForce = new Vector2();
            seekForce = DesiredSpeed - parent.Velocity;
            seekForce = VectorHelper.ToLimit(seekForce, parent.MaxForce);

            return seekForce;
        }

        private Vector2 Flee()
        {
            return new Vector2();

        }

        private Vector2 Arrive()
        {
            Vector2 ToTarget = Target - parent.pos;
            
            float dist = ToTarget.Length();

            if (dist > 0.01)
            {
                const float declarationtweak = 8f;
                float speed = dist /( declarationtweak);
                
                if (speed > parent.MaxSpeed)
                    speed = parent.MaxSpeed;

                Vector2 Dersiredvelocity = ToTarget * speed / dist;

                return (Dersiredvelocity - parent.Velocity);

            }
            return new Vector2(0f, 0f);
        }

        public Vector2 Calculate()
        {
            Vector2 steeringForce = new Vector2();

            if (SeekBehaviour == true)
                steeringForce += Seek();

            if (FleeBehaviour == true)
                steeringForce += Flee();

            if (ArriveBehaviour == true)
                steeringForce += Arrive();

            steeringForce = VectorHelper.MaxLimit(steeringForce, parent.MaxForce);
            return steeringForce;
        }

        public Vector2 ForwardComponent()
        {
            return new Vector2();
        }

        public Vector2 SideComponent()
        {
            return new Vector2();
        }

        public void SetPath()
        {

        }

        public void SetTarget(Vector2 target)
        {
            Target = target;
        }

        public void SetTargetAgent1(Vehicle agent1)
        {

        }

        public void SetTargetAgent2(Vehicle agent2)
        {

        }

        public void SeekOn(){
            SeekBehaviour = true;
        }

        public void FleeOn(){
            FleeBehaviour = true;
        }

        public void ArriveOn(){
            ArriveBehaviour = true;
        }

        public void SeekOff(){
            SeekBehaviour = false;
        }

        public void FleeOff(){
            FleeBehaviour = false;
        }

        public void ArriveOff(){
            ArriveBehaviour = false;
        }
    }
}
