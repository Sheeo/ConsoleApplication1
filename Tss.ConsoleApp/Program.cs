using System;
using Tss.HexagonMapping.Model;
using Tss.GameComponents.Structures;
using Tss.GameComponents.Maps;

namespace Tss.ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMap tm = new TestMap();
            City city1 = new City(2, 2, tm);
            Console.WriteLine(city1);
            city1.CollectResources();
            city1.CollectResources();
            Console.WriteLine(city1);

            City city2 = new City(3, 2, tm);
            //Console.WriteLine(city2);
            //city2.CollectResources();
            //City2.CollectResources();
            //Console.WriteLine(city2);

            Corner c = new Corner(2, 2, tm);
            foreach (Tile t in c.GetAdjacentTiles(2))
                Console.WriteLine(t);

            //var unit = new TestUnit(0, 0, tm);
            //foreach (Tile t in unit.AvailableTiles())
             //   Console.WriteLine(t);

            //Console.WriteLine(unit);

            //Console.WriteLine(unit.MoveTo(new Tile(1, 2, tm)));
            //Console.WriteLine(unit);

            Console.Read();
        }
    }
}
