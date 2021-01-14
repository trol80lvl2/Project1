using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    class Square : Shape
    {
        protected override double S { get; set; }
        protected override double P { get; set; }

        public override int Depth { get; set; }

        private Line _firstSide, _secondSide, _thirdSide, _fourthSide;

        public Square(Coordinates firstPointCoordinates, Coordinates secondPointCoordinates, Coordinates thirdPointCoordinates, Coordinates fourthPointCoordinates)
        {
            _firstSide = new Line(firstPointCoordinates, secondPointCoordinates);
            _secondSide = new Line(secondPointCoordinates, thirdPointCoordinates);
            _thirdSide = new Line(thirdPointCoordinates, fourthPointCoordinates);
            _fourthSide = new Line(firstPointCoordinates, fourthPointCoordinates);
        }

        public override void Draw()
        {
            _firstSide.Draw();
            _secondSide.Draw();
            _thirdSide.Draw();
            _fourthSide.Draw();
        }

        public override double GetArea()
        {
            S = Math.Round(_firstSide.Length * _firstSide.Length);
            return S;
        }

        public override double GetPerimeter()
        {
            P = Math.Round(_firstSide.Length * 4, 4);
            return P;
        }
    }
}
