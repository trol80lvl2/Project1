using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    class Line : Shape
    {
        protected override double S { get; set; }
        protected override double P { get; set; }

        public Coordinates StartCoordinates { get; private set; }
        public Coordinates FinishCoordinates { get; private set; }
        public double Length { get; private set; }

        public Line(Coordinates startCoordinates, Coordinates finishCoordinates)
        {
            StartCoordinates = startCoordinates;
            FinishCoordinates = finishCoordinates;
            Length = Math.Round(Math.Sqrt((Math.Pow(FinishCoordinates.X-StartCoordinates.X,2))+(Math.Pow(FinishCoordinates.Y - StartCoordinates.Y, 2))),4);
        }

        public override void Draw()
        {
            double dx = FinishCoordinates.X - StartCoordinates.X;
            double dy = FinishCoordinates.Y - StartCoordinates.Y;

            double maxDelta = Math.Abs(Math.Max(dx, dy));
            dx = maxDelta == 0? 1: dx / maxDelta;
            dy = maxDelta == 0 ? 1 : dy / maxDelta;

            double xScale = (Math.Max(StartCoordinates.X, FinishCoordinates.X) > (Console.WindowWidth - 1))
                    ? Math.Max(StartCoordinates.X, FinishCoordinates.X) / (Console.WindowWidth - 1)
                    : 1;
            double yScale = (Math.Max(StartCoordinates.Y, FinishCoordinates.Y) > (Console.WindowHeight - 1))
                                ? Math.Max(StartCoordinates.Y, FinishCoordinates.Y) / (Console.WindowHeight - 1)
                                : 1;
            double scale = Math.Max(xScale, yScale);

            int graphX = (int)Math.Round(StartCoordinates.X / scale);
            int graphY = (int)Math.Round(StartCoordinates.Y / scale);

            double x = StartCoordinates.X;
            double y = StartCoordinates.Y;

            do
            {
                Console.SetCursorPosition(Math.Abs(graphX), Math.Abs(graphY));
                Console.Write('1');
                x += dx;
                y += dy;
                graphX = (int)Math.Round(x / scale);
                graphY = (int)Math.Round(y / scale);
            }
            while (Math.Abs(graphX - FinishCoordinates.X) != 0 || Math.Abs(graphY - FinishCoordinates.Y) != 0);
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
