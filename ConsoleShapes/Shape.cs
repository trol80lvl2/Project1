using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    public abstract class Shape
    {
        protected abstract double S { get; }
        protected abstract double P { get; }
        public abstract int Depth { get; }

        public abstract double GetArea();
        public abstract double GetPerimeter();

        public abstract void Draw();
    }
}
