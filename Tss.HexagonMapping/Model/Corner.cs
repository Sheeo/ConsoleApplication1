using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tss.HexagonMapping.Model
{
    public struct Corner
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private readonly TileMap map;

        public Corner(int x, int y, TileMap map): this()
        {
            X = x;
            Y = y;
            this.map = map;
        }

        public List<Corner> GetNeighbours()
        {
            return map.CornerMap.GetNeighbours(this);
        }

        public List<Tile> GetAdjacentTiles()
        {
            return map.CornerMap.GetAdjacentTiles(this);
        }

        public List<Tile> GetAdjacentTiles(int reach)
        {

            var set = new HashSet<Tile>();
            foreach (Tile t in GetAdjacentTiles())
            {
                set.Add(t);
            }
            return map.getAdjacentTiles(set, reach);
        }

        public override string ToString()
        {
            return String.Format("<Corner> x: {0}, y: {1}", X, Y);
        }
    }
}
