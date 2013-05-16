using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIproject
{
    public class MapRow
    {
        public List<MapCell> Columns = new List<MapCell>();
    }

    public class TileMap
    {
        public List<MapRow> Rows = new List<MapRow>();
        public int MapWidth = 50;
        public int MapHeight = 50;

        public TileMap()
        {
            for (int y = 0; y < MapHeight; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < MapWidth; x++)
                {
                    int variable = index(x, y);
                    thisRow.Columns.Add(new MapCell(variable));
                }
                Rows.Add(thisRow);
            }
            
        }       

        private int index(int x, int y)
        {
            if (x == 2 && (y < 5))
            {
                return 5;
            }
            else
                return 1;
        }
    }
}
