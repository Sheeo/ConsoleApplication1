using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tss.GameComponents.Basic
{
    public class TileResource
    {
        public Resources Resource {get; set;}
        public int Amount {get;set;}

        public TileResource(Resources resource, int amount)
        {
            Amount = amount;
            Resource = resource;
        }

        public TileResource()
        {
            Amount = 0;
            Resource = Resources.Corn;
        }
    }
}
