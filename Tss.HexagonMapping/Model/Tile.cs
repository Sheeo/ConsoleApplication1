using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tss.HexagonMapping.Model
{
    public struct Tile
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private TileMap Map;

        public Tile(int x, int y, TileMap map) : this()
        {
            this.X = x;
            this.Y = y;
            this.Map = map;
        }

        public List<Corner> GetCorners()
        {
            return Map.GetCorners(this);
        }

        public List<Tile> GetNeighbours()
        {
            return Map.GetNeighbours(this);
        }

        public List<Tile> GetNeighbours(int reach)
        {

            var set = new HashSet<Tile>();
            set.Add(this);
            return Map.getAdjacentTiles(set, reach);
        }



        public override string ToString()
        {
            return String.Format("<Tile> x: {0} y: {1}", X, Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Tile)
            {
                try
                {
                    var casted = (Tile)obj;
                    return (casted.X == this.X &&
                            casted.Y == this.Y &&
                            casted.Map == this.Map);
                }
                catch (InvalidCastException)
                {
                    return false;
                }

            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
