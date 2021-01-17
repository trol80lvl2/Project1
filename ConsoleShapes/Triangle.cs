using ConsoleShapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleShapes
{
    public class Triangle : Shape,IHaveArea,IHavePerimeter,IFillable,IMultiLineShape
    {
        public double S
        {
            get
            {
                double p = Lines.Sum(x=>x.Length) / 2;
                return Math.Round(Math.Sqrt(p * (p - Lines[0].Length) * (p - Lines[1].Length) * (p - Lines[2].Length)), 4); 
            }
        }

        public double P
        {
            get
            {
                return Lines.Sum(x=>x.Length) / 2;
            }
        }

        public Line[] Lines { get; }


        public Triangle(Coordinates firstPointCoordinates, Coordinates secondPointCoordinates, Coordinates thirdPointCoordinates,int depth)
        {
            Depth = depth;
            Lines = new Line[] { new Line(firstPointCoordinates, secondPointCoordinates, Depth), new Line(firstPointCoordinates, thirdPointCoordinates, Depth)
            , new Line(secondPointCoordinates, thirdPointCoordinates, Depth) };
        }

        public override void Draw()
        {
            foreach(var line in Lines)
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

            try
            {
                var min = Lines.Select(x => x.StartCoordinates).Union(Lines.Select(x => x.FinishCoordinates)).OrderByDescending(p => p.Y).Select(x => new Coordinates(x.X, x.Y)).FirstOrDefault();
                if (min.Y == 0)
                {
                    throw new Exception();
                }
                Console.SetCursorPosition(min.X, min.Y);
                foreach (var line in Lines)
                {
                    line.MoveUp();
                }
                Console.SetCursorPosition(min.X, min.Y);

            }
            catch
            {
                foreach (var line in Lines)
                {
                    line.Draw();
                }
            }
        }

        public override void MoveDown()
        {
            try
            {
                var min = Lines.Select(x => x.StartCoordinates).Union(Lines.Select(x => x.FinishCoordinates)).OrderBy(p => p.Y).Select(x => new Coordinates(x.X, x.Y)).FirstOrDefault();
                if (min.Y == Console.WindowHeight)
                {
                    throw new Exception();
                }
                if (min.Y <= 1)
                    Console.SetCursorPosition(min.X, 1);
                else if (min.Y >= Console.WindowHeight)
                    Console.SetCursorPosition(min.X, Console.WindowHeight);
                else
                    Console.SetCursorPosition(min.X, min.Y);
                foreach (var line in Lines)
                {
                    line.MoveDown();
                }
                if (min.Y <= 1)
                    Console.SetCursorPosition(min.X, 1);
                else
                    Console.SetCursorPosition(min.X, min.Y);

            }
            catch
            {
                foreach (var line in Lines)
                {
                    line.Draw();
                }
            }
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
