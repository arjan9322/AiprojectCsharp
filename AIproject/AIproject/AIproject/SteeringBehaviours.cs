using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject
{
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
            Vector2 seekForce = new Vector2();
            seekForce = Target - parent.pos;
            
            return seekForce;
        }

        private Vector2 Flee()
        {
            return new Vector2();
        }

        private Vector2 Arrive()
        {
            return new Vector2();
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

            steeringForce = VectorHelper.ToLimit(steeringForce, parent.MaxForce);
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
