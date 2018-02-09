using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triangles.Model
{
    public class Vertex
    {
        public Vertex()
        {
            // Set coordinates to -1 in the begining to show they weren't initates yet.
            X = -1;
            Y = -1;
        }

        public Vertex(int x, int y)
        {
            // Set coordinates to -1 in the begining to show they weren't initates yet.
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
