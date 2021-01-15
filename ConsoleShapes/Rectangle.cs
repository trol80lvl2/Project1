using ConsoleShapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    public class Rectangle : Shape,IHaveArea,IHavePerimeter,IFillable,IMultiLineShape
    {
        public double S
        {
            get
            {
                return Math.Round(Lines[0].Length * Lines[1].Length);
            }
        }

        public double P
        {
            get
            {
                return Math.Round(Lines[0].Length * 2 + Lines[1].Length * 2, 4);
            }
        }

        public Line[] Lines { get; }


        public Rectangle(Coordinates firstPointCoordinates, Coordinates secondPointCoordinates, Coordinates thirdPointCoordinates, Coordinates fourthPointCoordinates,int depth)
        {
            Depth = depth;
            Lines = new Line[] { new Line(firstPointCoordinates, secondPointCoordinates, Depth), new Line(secondPointCoordinates, thirdPointCoordinates, Depth)
            , new Line(thirdPointCoordinates, fourthPointCoordinates, Depth), new Line(firstPointCoordinates, fourthPointCoordinates, Depth)};
        }

        public override void Draw()
        {
            foreach (var line in Lines)
            {
                line.Draw();
            }
        }

        public void Fill()
        {
            throw new NotImplementedException();
        }

        public override void MoveUp()
        {
            foreach (var line in Lines)
            {
                line.MoveUp();
            }
        }

        public override void MoveDown()
        {
            foreach (var line in Lines)
            {
                line.MoveDown();
            }
            Draw();
        }

        public override void MoveLeft()
        {
            foreach (var line in Lines)
            {
                line.MoveLeft();
            }
            Draw();
        }

        public override void MoveRight()
        {
            foreach (var line in Lines)
            {
                line.MoveRight();
            }
            Draw();
        }
    }
}
