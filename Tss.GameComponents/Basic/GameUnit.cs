using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tss.GameComponents.Basic;
using Tss.HexagonMapping.Model;

namespace Tss.GameComponents.Basic
{
    public class GameUnit
    {
        public Tile Position { get; set; }
        private GameMap Map;
        public int MoveDistance {get; private set;}

        public GameUnit(int x, int y, GameMap map, int moveDistance)
        {
            Map = map;
            Position = Map.GetTile(x, y);
            MoveDistance = moveDistance;
        }

        public List<Tile> AvailableTiles()
        {
            return Position.GetNeighbours(MoveDistance);
        }

        public Boolean MoveTo(Tile destination)
        {
            if (AvailableTiles().Contains(destination))
            {
                Position = destination;
                return true;
            }else
                return false;

        }

        public override string ToString()
        {
            return String.Format("<GameUnit> position: {0} , {1}", Position.X, Position.Y);
        }


    }
}
