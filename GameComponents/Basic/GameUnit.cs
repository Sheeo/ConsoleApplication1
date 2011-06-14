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

        public HashSet<Tile> availableTiles()
        {
           
            var set = new HashSet<Tile>(); 
            set.Add(Position);

            var result = new HashSet<Tile>(); 

            return AvailableTilesRecursive(set, MoveDistance, result);
        }

        private HashSet<Tile> AvailableTilesRecursive(HashSet<Tile> set, int distance, HashSet<Tile> result)
        {
            //base case
            if (distance == 0)
                return result;

            //recursive case
            var newSet = new HashSet<Tile>();

            foreach (Tile t in set)
                foreach (Tile ti in t.GetNeighbours())
                {
                    newSet.Add(ti);
                    result.Add(ti);
                }

            return AvailableTilesRecursive(newSet, distance - 1, result);
        }

        public Boolean MoveTo(Tile destination)
        {
            if (availableTiles().Contains(destination))
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
