using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    class Circle : Shape
    {
        public override int Depth { get; set; }
        protected override double S { get; set; }
        protected override double P { get; set; }
        public int Radius { get; private set; }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override double GetArea()
        {
            S = Math.Round(Math.PI * Radius * Radius, 4);
            return S;
        }

        public override double GetPerimeter()
        {
            P = Math.Round(2 * Math.PI * Radius,4);
            return P;
        }
    }
}
