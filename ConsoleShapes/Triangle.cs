using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    class Triangle : Shape
    {
        protected override double S { get; set; }
        protected override double P { get; set; }
        public override int Depth { get; set; }

        private Line _firstSide, _secondSide, _thirdSide;

        public Triangle(Coordinates firstPointCoordinates, Coordinates secondPointCoordinates, Coordinates thirdPointCoordinates)
        {
            _firstSide = new Line(firstPointCoordinates, secondPointCoordinates);
            _secondSide = new Line(firstPointCoordinates, thirdPointCoordinates);
            _thirdSide = new Line(secondPointCoordinates, thirdPointCoordinates);
        }

        public override void Draw()
        {
            _firstSide.Draw();
            _secondSide.Draw();
            _thirdSide.Draw();
        }

        public override double GetArea()
        {
            double p = (_firstSide.Length + _secondSide.Length + _thirdSide.Length) / 2;
            S = Math.Round(Math.Sqrt(p * (p - _firstSide.Length) * (p - _secondSide.Length) * (p - _thirdSide.Length)), 4);
            return S;
        }

        public override double GetPerimeter()
        {
            P = _firstSide.Length + _secondSide.Length + _thirdSide.Length;
            return P;
        }
    }
}
