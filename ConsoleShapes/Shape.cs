using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    public abstract class Shape
    {
        protected abstract double S { get; set; }
        protected abstract double P { get; set; }
        public abstract int Depth { get; set; }

        public abstract double GetArea();
        public abstract double GetPerimeter();

        public abstract void Draw();
    }
}
