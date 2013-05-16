using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject
{
    enum Dec{ slow = 3, normal = 2, fast = 1 };

    internal class SteeringBehaviours
    {
        private bool SeekBehaviour;
        private bool FleeBehaviour;
        private bool ArriveBehaviour;
        private bool ExploreBehaviour;
        private List<Vector2> exploreTargets;
        private int exploretargetnumber = 0;
        public Vector2 Target;
        private Vehicle parent;
        public SteeringBehaviours(Vehicle parent)
        {
            SeekBehaviour = false;
            FleeBehaviour = false;
            ArriveBehaviour = false;
            ExploreBehaviour = false;
            this.parent = parent;

            exploreTargets = new List<Vector2>();
            exploreTargets.Add(new Vector2(100f,100f));
            exploreTargets.Add(new Vector2(1100f,100f));
            exploreTargets.Add(new Vector2(1100f,200f));
            exploreTargets.Add(new Vector2(100f,200f));
            exploreTargets.Add(new Vector2(100f,300f));
            exploreTargets.Add(new Vector2(1100f,300f));
            exploreTargets.Add(new Vector2(1100f,400f));
            exploreTargets.Add(new Vector2(100f,400f));
            exploreTargets.Add(new Vector2(100f,500f));
            exploreTargets.Add(new Vector2(1100f,500f));
            exploreTargets.Add(new Vector2(1100f,600f));
            exploreTargets.Add(new Vector2(100f,600f));
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
            Vector2 ToTarget = Target - parent.pos;
            float factor;
            if (ToTarget.Length() > 30f)
                ToTarget = ToTarget / (ToTarget.Length() / (ToTarget.Length() - 30f));
            else
                ToTarget = new Vector2(0f,0f);

            float dist = ToTarget.Length();

            if (dist > 0.01)
            {
                const float declarationtweak = 8f;
                float speed = dist / (declarationtweak);

                if (speed > parent.MaxSpeed)
                    speed = parent.MaxSpeed;

                Vector2 Dersiredvelocity = ToTarget * speed / dist;

                return (Dersiredvelocity - parent.Velocity);

            }
            return new Vector2(0f, 0f);

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

        private Vector2 Explore()
        {

            Vector2 ToTarget = exploreTargets[exploretargetnumber] - parent.pos;
            
            float dist = ToTarget.Length();

            if (dist < 10f)
            {
                exploretargetnumber++;
                if (exploretargetnumber >= exploreTargets.Count)
                    exploretargetnumber = 0;
            }
            Vector2 speed = new Vector2(parent.MaxSpeed);
            Vector2 Dersiredvelocity = ToTarget * speed / dist;
            return (Dersiredvelocity - parent.Velocity);
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

            if (ExploreBehaviour == true)
                steeringForce += Explore();

            steeringForce = VectorHelper.MaxLimit(steeringForce, parent.MaxForce);
            return steeringForce;
        }

        public Vector2 ForwardComponent(){
            return new Vector2();
        }

        public Vector2 SideComponent(){
            return new Vector2();
        }

        public void SetPath(){

        }

        public void SetTarget(Vector2 target){
            Target = target;
        }

        public void SetTargetAgent1(Vehicle agent1){
        }

        public void SetTargetAgent2(Vehicle agent2){
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

        public void ExploreOn(){
            ExploreBehaviour = true;
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

        public void ExploreOff(){
            ExploreBehaviour = false;
        }
    }
}
