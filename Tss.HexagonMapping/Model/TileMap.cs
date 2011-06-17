using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tss.HexagonMapping.Model
{
    public class TileMap
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public TileCornerMap CornerMap { get; set; }

        public TileMap(int x, int y)
        {
            CornerMap = new TileCornerMap(this);
            Width = x;
            Height = y;
        }

        public List<Tile> GetNeighbours(Tile tile)
        {
            return GetNeighbours(tile.X, tile.Y);
        }

        public List<Tile> GetNeighbours(int x, int y)
        {
            List<Tile> tiles = new List<Tile>();

            if (x % 2 == 0)
            {
                tiles.Add(new Tile(x, y - 1, this));
                tiles.Add(new Tile(x, y + 1, this));
                tiles.Add(new Tile(x - 1, y, this));
                tiles.Add(new Tile(x - 1, y - 1, this));
                tiles.Add(new Tile(x + 1, y, this));
                tiles.Add(new Tile(x + 1, y - 1, this));
            }
            else
            {
                tiles.Add(new Tile(x, y - 1, this));
                tiles.Add(new Tile(x, y + 1, this));
                tiles.Add(new Tile(x - 1, y, this));
                tiles.Add(new Tile(x - 1, y + 1, this));
                tiles.Add(new Tile(x + 1, y, this));
                tiles.Add(new Tile(x + 1, y + 1, this));
            }

            return (from Tile t in tiles
                   where CheckValidTile(t)
                   select t).ToList();
        }

        public Boolean CheckValidTile(Tile t)
        {
            var r = t.X >= 0 &&
                   t.Y >= 0 &&
                   t.X < Width &&
                   t.Y < Height;
            //Console.WriteLine("CheckValid for {0}, it is: {1}, on map: {2}", t, r, this);
            return r;
        }

        public Tile GetTile(int x, int y) {
            Tile t = new Tile(x, y, this);
            if (CheckValidTile(t))
                return t;
            else
                throw new IndexOutOfRangeException(String.Format("{0}, {1} does not exist in map", x, y));
        }

        public List<Corner> GetCorners(Tile t)
        {
            List<Corner> corners = new List<Corner>();
            int y;
            int x = t.X;

            if (t.X % 2 == 0)
                y = t.Y;
            else
                y = t.Y + 1;

                corners.Add(new Corner(x, y * 2, this));
                corners.Add(new Corner(x, y * 2 + 1, this));
                corners.Add(new Corner(x, y * 2 + 2, this));
                corners.Add(new Corner(x + 1, y * 2, this));
                corners.Add(new Corner(x + 1, y * 2 + 1, this));
                corners.Add(new Corner(x + 1, y * 2 + 2, this));

            return corners;
        }

        public override string ToString()
        {
            return String.Format("<TileMap> width: {0}, height: {1})", Width, Height);
        }

        public List<Tile> getAdjacentTiles(HashSet<Tile> start, int reach)
        {
            var result = new HashSet<Tile>();
            
            foreach (Tile t in start)
                result.Add(t);

            var actualResult = new List<Tile>();
            foreach (Tile t in GetAdjacentTilesRecursive(start, reach, result))
            {
                actualResult.Add(t);
            }
            return actualResult;
        }

        private HashSet<Tile> GetAdjacentTilesRecursive(HashSet<Tile> set, int reach, HashSet<Tile> result)
        {
            //base case
            if (reach == 0)
                return result;

            //recursive case
            var newSet = new HashSet<Tile>();

            foreach (Tile t in set)
                foreach (Tile ti in t.GetNeighbours())
                {
                    newSet.Add(ti);
                    result.Add(ti);
                }

            return GetAdjacentTilesRecursive(newSet, reach - 1, result);
        }
        
    }
}
