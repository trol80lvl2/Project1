using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    public class Line : Shape
    {
        public Coordinates StartCoordinates { get; set; }
        public Coordinates FinishCoordinates { get; set; }
        public double Length { get; private set; }

        public Line(Coordinates startCoordinates, Coordinates finishCoordinates, int depth)
        {
            StartCoordinates = startCoordinates;
            FinishCoordinates = finishCoordinates;
            Length = Math.Round(Math.Sqrt((Math.Pow(FinishCoordinates.X-StartCoordinates.X,2))+(Math.Pow(FinishCoordinates.Y - StartCoordinates.Y, 2))),4);
            Depth = depth;
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

            Console.ForegroundColor = ConsoleColor.Red;
            do
            {
                if(!(Math.Abs(graphX)!=graphX || Math.Abs(graphY)!=graphY || graphY>Console.WindowHeight || graphX>Console.WindowWidth))
                {
                    Console.SetCursorPosition(graphX, graphY);
                    Console.Write(Depth);
                }
                x += dx;
                y += dy;
                graphX = (int)Math.Round(x / scale);
                graphY = (int)Math.Round(y / scale);
            }
            while (Math.Abs(graphX - FinishCoordinates.X) != 0 || Math.Abs(graphY - FinishCoordinates.Y) != 0);
            Console.ForegroundColor = default;
        }

        public override void MoveUp()
        {
            StartCoordinates = new Coordinates(StartCoordinates.X, StartCoordinates.Y - 1);
            FinishCoordinates = new Coordinates(FinishCoordinates.X, FinishCoordinates.Y - 1);
            Draw();
        }

        public override void MoveDown()
        {
            StartCoordinates = new Coordinates(StartCoordinates.X, StartCoordinates.Y + 1);
            FinishCoordinates = new Coordinates(FinishCoordinates.X, FinishCoordinates.Y + 1);
            Draw();
        }

        public override void MoveLeft()
        {
            StartCoordinates = new Coordinates(StartCoordinates.X - 1, StartCoordinates.Y);
            FinishCoordinates = new Coordinates(FinishCoordinates.X - 1 , FinishCoordinates.Y);
            Draw();
        }

        public override void MoveRight()
        {
            StartCoordinates = new Coordinates(StartCoordinates.X + 1, StartCoordinates.Y);
            FinishCoordinates = new Coordinates(FinishCoordinates.X + 1, FinishCoordinates.Y);
            Draw();
        }
    }
}
