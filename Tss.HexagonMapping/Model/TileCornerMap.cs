using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tss.HexagonMapping.Model
{
    public class TileCornerMap
    {

        private TileMap Map;

        public TileCornerMap(TileMap map)
        {
            this.Map = map;
        }

        public List<Corner> GetNeighbours(Corner c)
        {
            return GetNeighbours(c.X, c.Y);
        }

        public List<Corner> GetNeighbours(int x, int y)
        {
            List<Corner> corners = new List<Corner>();

            corners.Add(new Corner(x, y - 1, Map));
            corners.Add(new Corner(x, y + 1, Map));

            if (x % 2 == 0)
                corners.Add(new Corner(x - 1, y, Map));
            else
                corners.Add(new Corner(x + 1, y, Map));

            return (from Corner c in corners
                   where checkValidCorner(c)
                   select c).ToList();
        }
        public List<Tile> GetAdjacentTiles(Corner c)
        {
            return GetAdjacentTiles(c.X, c.Y);
        }

        public List<Tile> GetAdjacentTiles(int x, int y)
        {
            List<Tile> tiles = new List<Tile>();

            if (y % 2 == 1)
            {
                int yDiv = (y - 1) / 2;
                tiles.Add(new Tile(x - 1, yDiv - 1, Map));
                tiles.Add(new Tile(x, yDiv - 1, Map));
                tiles.Add(new Tile(x - 1, yDiv, Map));
            }
            else
            {
                int yDiv = (y / 2);
                tiles.Add(new Tile(x - 1, yDiv - 1, Map));
                tiles.Add(new Tile(x, yDiv - 1, Map));
                tiles.Add(new Tile(x, yDiv, Map));
            }

            return (from Tile t in tiles
                    where Map.CheckValidTile(t)
                    select t).ToList();
        }

                  

        private Boolean checkValidCorner(Corner c)
        {
            return c.X > 0 &&
                   c.Y > 0 &&
                   (((c.X == 0 || c.X == Map.Width * 2 + 1) && c.X <= Map.Height * 2 + 1) ||
                    (c.X != 0 && c.X != Map.Width * 2 + 1 && c.X <= Map.Height * 2 + 2));
                    
                  
        }

        public override string ToString()
        {
            return String.Format("<TileCornerMap> height: {0}, width: {1}", Map.Height * 2 + 1, Map.Width * 2 + 1);
        }

    }
}
