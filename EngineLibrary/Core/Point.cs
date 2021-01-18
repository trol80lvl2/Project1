using System;
using System.Collections.Generic;
using System.Text;

namespace EngineLibrary.Core
{
    class Point
    {
        public static Point Empty = new Point(ConsoleColor.Black, ' ');

        public ConsoleColor Color { get; }
        public char Symb { get; }

        public Point(ConsoleColor color, char symb)
        {
            Color = color;
            Symb = symb;
        }
    }
}