using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Tss.HexagonMapping.Model;
using Tss.GameComponents.Structures;
using Tss.GameComponents.Maps;
using Tss.GameComponents.Units;

namespace ConsoleApplication1
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
            Console.WriteLine(city2);
            city2.CollectResources();
            city2.CollectResources();
            Console.WriteLine(city2);

            var unit = new TestUnit(0, 0, tm);
            foreach (Tile t in unit.availableTiles())
                Console.WriteLine(t);
    
            Console.WriteLine(unit);

            Console.WriteLine(unit.MoveTo(new Tile(1, 2, tm)));
            Console.WriteLine(unit);

            Console.Read();
        }
    }
}
