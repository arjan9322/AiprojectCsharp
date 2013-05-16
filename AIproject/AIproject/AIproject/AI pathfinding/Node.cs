using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject
{
    public class Node
    {
        public Point Position { get; set; }
        public bool closed { get; set; }
        public List<Node> Neighbours;
        public Vector2 topoint { get; set; }
        public bool InOpenList;
        public bool InClosedList;
        public float DistanceToGoal;
        public float DistanceTraveled;
        public Node Parent;
        
        public Node()
        {
            Point p = new Point(0,0);
            Position = p;
            Neighbours = new List<Node>();
        }

        
        
    }
}
