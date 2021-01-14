using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    class Triangle : Shape
    {
        protected override double S { get; set; }
        protected override double P { get; set; }
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
            throw new NotImplementedException();
        }

        public override double GetPerimeter()
        {
            throw new NotImplementedException();
        }
    }
}
