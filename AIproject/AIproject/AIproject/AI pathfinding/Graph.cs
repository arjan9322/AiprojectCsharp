using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AIproject
{
    
    public class Graph
    {
        public List<Node> nodes;
       
        int levelwidth = 30;
        int levelheight = 20;

        public Graph()
        {
            nodes = new List<Node>();
            for (int i = 0; i < levelheight; i++)
            {
                for (int j = 0; j < levelwidth; j++)
                {
                    nodes.Add(new Node());
                }
            }
        }

        public void fill (TileMap myMap, Vector2 pointto)
        {
            Vector2 firstSquare = new Vector2(Camera.Location.X / Tile.TileWidth, Camera.Location.Y / Tile.TileHeight);
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            for (int y = 0; y < levelheight; y++)
            {
                for (int x = 0; x < levelwidth; x++)
                {
                    foreach (int tileID in myMap.Rows[y + firstY].Columns[x + firstX].BaseTiles)
                    {
                        Point Position = new Point(x, y);
                        if (tileID == 1)
                        {
                            float pointx = pointto.X - x*Tile.TileWidth;
                            if (pointx < 0)
                                pointx = pointx * -1;
                            float pointy = pointto.Y - x*Tile.TileWidth;
                            if (pointy < 0)
                                pointy = pointy * -1;
                            Vector2 distance = new Vector2(pointx, pointy);
                            nodes[x + y * levelwidth].closed = false;
                            nodes[x + y * levelwidth].Position = Position;
                            nodes[x + y * levelwidth].topoint = distance;
                        }
                        else
                        {
                            nodes[x + y * levelwidth].closed = true;
                            nodes[x + y * levelwidth].Position = Position;
                        }
                    }
                }
            }
            foreach (var node in nodes)
            {
                if (node.Position.X - 1 >= 0 && node.Position.X - 1 < levelwidth && node.Position.Y >= 0 && node.Position.Y < levelheight)
                    node.Neighbours.Add(nodes[(int)(node.Position.X - 1f + node.Position.Y)]);
                if (node.Position.X + 1 >= 0 && node.Position.X + 1 < levelwidth && node.Position.Y >= 0 && node.Position.Y < levelheight)
                    node.Neighbours.Add(nodes[(int)(node.Position.X + 1f + node.Position.Y)]);
                if (node.Position.X  >= 0 && node.Position.X < levelwidth && node.Position.Y -1 >= 0 && node.Position.Y -1 < levelheight)
                    node.Neighbours.Add(nodes[(int)(node.Position.X  + node.Position.Y - 1f)]);
                if (node.Position.X >= 0 && node.Position.X < levelwidth && node.Position.Y + 1 >= 0 && node.Position.Y + 1 < levelheight)
                    node.Neighbours.Add(nodes[(int)(node.Position.X + node.Position.Y + 1f)]);
            }
        }       

        public bool closed (int x, int y)
        {
            if (nodes[x + y * levelwidth].closed == false)
            {
                return false;
            }
            else
                return true;
        }

        
    }
}
