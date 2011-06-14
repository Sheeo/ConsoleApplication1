using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tss.HexagonMapping.Model;

namespace Tss.GameComponents.Basic
{
    public class GameMap : TileMap
    {
        public Map<TileResource> resourceMap;

        public GameMap(int x, int y) : base (x, y)
        {
            resourceMap = new Map<TileResource>(x, y);
        }

        public Resources getResource(Tile t)
        {
            return resourceMap[t.X][t.Y].Resource;
        }
    }
}
