using System;
using System.Collections.Generic;
using System.Text;

namespace EngineLibrary
{
    public class Point
    {
        public static Point Empty = new Point(ConsoleColor.Black, ' ');

        public ConsoleColor Color { get; }
        public char Symb { get; }

        public Point(ConsoleColor color, char symb)
        {
            Color = color;
            Symb = symb;
        }

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   Color == point.Color &&
                   Symb == point.Symb;
        }

        public override int GetHashCode()
        {
            var hashCode = 286535306;
            hashCode = hashCode * -1521134295 + Color.GetHashCode();
            hashCode = hashCode * -1521134295 + Symb.GetHashCode();
            return hashCode;
        }
    }
}