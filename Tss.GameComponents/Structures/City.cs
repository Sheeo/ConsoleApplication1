using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tss.HexagonMapping.Model;
using Tss.GameComponents.Basic;

namespace Tss.GameComponents.Structures
{
    class SelfPrintingDictionary<Tkey, Tvalue> : Dictionary<Tkey, Tvalue>
    {
        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            foreach (var k in this.Keys)
            {
                b.Append(k.ToString() + ": " + this[k] .ToString() + ", ");
            }
            return b.ToString();
        }
    }
    public class City
    {
        public Corner Position {get; private set;}
        private GameMap Map;
        public int Reach { get; private set; }

        private IDictionary<Resources, int> resources;

        public City(int x, int y, GameMap map)
        {
            Reach = 1;
            resources = new SelfPrintingDictionary<Resources, int>();
            Position = new Corner(x, y, Map);
            Map = map;
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
            Position.GetAdjacentTiles(Reach).ForEach(t => AddResources(Map.getResource(t), 1));
        }

        public override string ToString()
        {
            return String.Format("<City> x: {0} y: {1}, ressources: {2}", Position.X,Position.Y,resources.ToString());
        }
    }
}
