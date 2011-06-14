using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Tss.GameComponents.Basic
{
    public class Map<T>
        where T : new()
    {
        public Dictionary<Int32, Dictionary<Int32, T>> DMap { get; set; }
        public int Height {get; private set;}
        public int Width { get; private set; }

        public Map(Int32 x, Int32 y)
        {
            DMap = new Dictionary<int, Dictionary<int, T>>();
            for (int i = 0; i < x; i++)
            {
                var d = new Dictionary<int, T>();
                DMap.Add(i, d);
                for (int j = 0; j < y; j++)
                    d.Add(j, new T());
            }
            
            Height = y;
            Width = x;
        }

        public Dictionary<Int32, T> this[int x]
        {
            get { return DMap[x];  }
            set { DMap[x] = value; }
        }

        public override string ToString()
        {
            return String.Format("<Map> width: {0}, height: {1})", Width, Height);
        }
    }
}
