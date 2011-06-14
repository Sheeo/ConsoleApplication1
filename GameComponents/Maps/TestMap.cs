using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tss.GameComponents.Basic;
using Tss.GameComponents.Maps;

namespace Tss.GameComponents.Maps
{
    public class TestMap : GameMap
    {
        public TestMap() : base (3, 3)
        {
            this.resourceMap[0][0].Resource = Resources.Iron;
            this.resourceMap[0][1].Resource = Resources.Iron;
            this.resourceMap[0][2].Resource = Resources.Iron;

            this.resourceMap[1][0].Resource = Resources.Wood;
            this.resourceMap[1][1].Resource = Resources.Wood;
            this.resourceMap[1][2].Resource = Resources.Wood;

            this.resourceMap[2][0].Resource = Resources.Corn;
            this.resourceMap[2][1].Resource = Resources.Corn;
            this.resourceMap[2][2].Resource = Resources.Corn;

        }
    }
}
