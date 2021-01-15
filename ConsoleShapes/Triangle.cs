using ConsoleShapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    class Triangle : Shape,IHaveArea,IHavePerimeter,IFillable
    {
        public double S
        {
            get
            {
                double p = (_firstSide.Length + _secondSide.Length + _thirdSide.Length) / 2;
                return Math.Round(Math.Sqrt(p * (p - _firstSide.Length) * (p - _secondSide.Length) * (p - _thirdSide.Length)), 4); 
            }
        }

        public double P
        {
            get
            {
                return _firstSide.Length + _secondSide.Length + _thirdSide.Length;
            }
        }


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

        public void Fill()
        {
            throw new NotImplementedException();
        }

        public override void MoveUp()
        {
            throw new NotImplementedException();
        }

        public override void MoveDown()
        {
            throw new NotImplementedException();
        }

        public override void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public override void MoveRight()
        {
            throw new NotImplementedException();
        }
    }
}
