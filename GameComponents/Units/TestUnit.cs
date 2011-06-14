using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tss.GameComponents.Basic;

namespace Tss.GameComponents.Units 
{
    public class TestUnit : GameUnit
    {
        public TestUnit(int x, int y, GameMap map) : base(x, y, map, 2) { }
    }
}
