using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject
{
    public class PathFinder
    {
        private Game1 game;
        private List<Node> openList = new List<Node>();
        private List<Node> closedList = new List<Node>();
        int levelwidth = 18;
        int levelheight = 11;

        public PathFinder(Game1 _game)
        {
            game = _game;
        }

        
        private void ResetSearchNodes()
        {
            openList.Clear();
            closedList.Clear();

            for (int x = 0; x < levelwidth; x++)
            {
                for (int y = 0; y < levelheight; y++)
                {
                    Node node = game.graph.nodes[x + y * levelwidth];

                    if (node == null)
                    {
                        continue;
                    }

                    node.InOpenList = false;
                    node.InClosedList = false;

                    node.DistanceTraveled = float.MaxValue;
                    node.DistanceToGoal = float.MaxValue;
                }
            }
        }

        private float Heuristic(Point point1, Point point2)
        {
            return Math.Abs(point1.X - point2.X) +
                   Math.Abs(point1.Y - point2.Y);
        }

        private Node FindBestNode()
        {
            Node currentTile = openList[0];

            float smallestDistanceToGoal = float.MaxValue;
            for (int i = 0; i < openList.Count; i++)
            {
                if (openList[i].DistanceToGoal < smallestDistanceToGoal)
                {
                    currentTile = openList[i];
                    smallestDistanceToGoal = currentTile.DistanceToGoal;
                }
            }
            return currentTile;
        }

        private List<Vector2> FindFinalPath(Node startNode, Node endNode)
        {
            closedList.Add(endNode);

            Node parentTile = endNode.Parent;


            while (parentTile != startNode)
            {
                closedList.Add(parentTile);
                parentTile = parentTile.Parent;
            }

            List<Vector2> finalPath = new List<Vector2>();


            for (int i = closedList.Count - 1; i >= 0; i--)
            {
                finalPath.Add(new Vector2(closedList[i].Position.X * 48,
                                          closedList[i].Position.Y * 48));
            }

            return finalPath;
        }

        public List<Vector2> FindPath(Point startPoint, Point endPoint)
        {
            // Only try to find a path if the start and end points are different.
            if (startPoint == endPoint)
            {
                return new List<Vector2>();
            }


            ResetSearchNodes();

            // Store references to the start and end nodes for convenience.

            Node startNode = game.graph.nodes[startPoint.X + startPoint.Y * levelwidth];
            Node endNode = game.graph.nodes[endPoint.X + endPoint.Y * levelwidth];


            startNode.InOpenList = true;

            startNode.DistanceToGoal = Heuristic(startPoint, endPoint);
            startNode.DistanceTraveled = 0;

            openList.Add(startNode);

            while (openList.Count > 0)
            {

                Node currentNode = FindBestNode();

                if (currentNode == null)
                {
                    break;
                }

                if (currentNode == endNode)
                {
                    return FindFinalPath(startNode, endNode);
                }


                for (int i = 0; i < currentNode.Neighbours.Count; i++)
                {
                    Node neighbor = currentNode.Neighbours[i];


                    if (neighbor == null || neighbor.closed == false)
                    {
                        continue;
                    }

                    float distanceTraveled = currentNode.DistanceTraveled + 1;



                    float heuristic = Heuristic(neighbor.Position, endPoint);

                    if (neighbor.InOpenList == false && neighbor.InClosedList == false)
                    {
                        neighbor.DistanceTraveled = distanceTraveled;
                        neighbor.DistanceToGoal = distanceTraveled + heuristic;
                        neighbor.Parent = currentNode;
                        neighbor.InOpenList = true;
                        openList.Add(neighbor);
                    }

                    else if (neighbor.InOpenList || neighbor.InClosedList)
                    {
                        if (neighbor.DistanceTraveled > distanceTraveled)
                        {
                            neighbor.DistanceTraveled = distanceTraveled;
                            neighbor.DistanceToGoal = distanceTraveled + heuristic;

                            neighbor.Parent = currentNode;
                        }
                    }
                }
                openList.Remove(currentNode);
                currentNode.InClosedList = true;
            }
            return new List<Vector2>();
        }        

    }
}
