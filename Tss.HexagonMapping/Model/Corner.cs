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
        private TileMap Map;

        public Corner(int x, int y, TileMap map): this()
        {
            X = x;
            Y = y;
            Map = map;
        }

        public List<Corner> GetNeighbours()
        {
            return Map.CornerMap.GetNeighbours(this);
        }

        public List<Tile> GetAdjacentTiles()
        {
            return Map.CornerMap.GetAdjacentTiles(this);
        }

        public override string ToString()
        {
            return String.Format("<Corner> x: {0}, y: {1}", X, Y);
        }
    }
}
