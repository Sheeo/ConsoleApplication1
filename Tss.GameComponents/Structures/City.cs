using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tss.HexagonMapping.Model;
using Tss.GameComponents.Basic;

namespace Tss.GameComponents.Structures
{
    class SelfPrintingDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public override string ToString()
        {
            var b = new StringBuilder();
            foreach (var k in this.Keys)
            {
                b.Append(k + ": " + this[k] + ", ");
            }
            return b.ToString();
        }
    }
    public class City
    {
        public Corner Position {get; private set;}
        private readonly GameMap map;
        public int Reach { get; private set; }

        private readonly IDictionary<Resources, int> resources;

        public City(int x, int y, GameMap map)
        {
            Reach = 1;
            resources = new SelfPrintingDictionary<Resources, int>();
            this.map = map;
            Position = new Corner(x, y, map);
        }

        public void AddResources(Resources resource, int amount)
        {
            if (resources.ContainsKey(resource))
                resources[resource] = resources[resource] + amount;
            else
                resources.Add(resource, amount);
        }

        public void CollectResources()
        {
            foreach (Tile t in Position.GetAdjacentTiles())
            {
                Console.WriteLine(t);
            }
            Position.GetAdjacentTiles(Reach).ForEach(t => AddResources(map.getResource(t), 1));
        }

        public override string ToString()
        {
            return String.Format("<City> x: {0} y: {1}, ressources: {2}", Position.X,Position.Y,resources.ToString());
        }
    }
}
