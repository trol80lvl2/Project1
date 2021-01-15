using ConsoleShapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    class Square : Shape,IHaveArea,IHavePerimeter,IFillable
    {
        public double S
        {
            get
            {
                return Math.Round(_firstSide.Length * _firstSide.Length);
            }
        }

        public double P
        {
            get
            {
                return Math.Round(_firstSide.Length * 4, 4);
            }
        }

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
