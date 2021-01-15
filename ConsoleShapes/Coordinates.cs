using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    public struct Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
