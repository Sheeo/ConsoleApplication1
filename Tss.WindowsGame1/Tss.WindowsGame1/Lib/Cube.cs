using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tss.WindowsGame1.Lib
{
    public class Cube
    {
        // o.O
        public enum Face { Front, Back, Left, Right, Top, Bottom }

        // O.o
        private List<Face> faces;

        // O.O
        public Cube()
        {
            faces = new List<Face>()
                        {
                            Face.Top,
                            Face.Bottom,
                            Face.Left,
                            Face.Right,
                            Face.Front,
                            Face.Back
                        };
        }

        // ^.^
        public Cube(int height, int width)
        {
            foreach(var face in faces)
            {
                
            }
        }
    }
}
