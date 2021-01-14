using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{

    public class TriangleForTestDrawing
    {
        Coordinates p1,p2,p3;

        public TriangleForTestDrawing(Coordinates point1, Coordinates point2, Coordinates point3)
        {
            p1 = point1;
            p2 = point2;
            p3 = point3;
        }
        public TriangleForTestDrawing()
        {

        }

        public void Draw()
        {
            DrawLine(p1, p2);
            DrawLine(p2, p3);
            DrawLine(p1,p3);
        }

        public void ChangeCoordinatesY(int amount)
        {
            p1.Y += amount;
            p2.Y += amount;
            p3.Y += amount;
            Draw();

        }

        public void ChangeCoordinatesX(int amount)
        {
            p1.X += amount;
            p2.X += amount;
            p3.X += amount;
            Draw();
        }

        public void DrawLine(Coordinates coordinates1, Coordinates coordinates2)
        {
            double dx = coordinates2.X - coordinates1.X;
            double dy = coordinates2.Y - coordinates1.Y;

            double maxDelta = Math.Abs(Math.Max(dx, dy));
            dx = dx / maxDelta;
            dy = dy / maxDelta;

            double xScale = (Math.Max(coordinates1.X, coordinates2.X) > (Console.WindowWidth - 1))
                    ? Math.Max(coordinates1.X, coordinates2.X) / (Console.WindowWidth - 1)
                    : 1;
            double yScale = (Math.Max(coordinates1.Y, coordinates1.Y) > (Console.WindowHeight - 1))
                                ? Math.Max(coordinates1.Y, coordinates1.Y) / (Console.WindowHeight - 1)
                                : 1;
            double scale = Math.Max(xScale, yScale);

            int graphX = (int)Math.Round(coordinates1.X / scale);
            int graphY = (int)Math.Round(coordinates1.Y / scale);

            double x = coordinates1.X;
            double y = coordinates1.Y;

            do
            {
                Console.SetCursorPosition(Math.Abs(graphX), Math.Abs(graphY));
                Console.Write('1');
                x += dx;
                y += dy;
                graphX = (int)Math.Round(x / scale);
                graphY = (int)Math.Round(y / scale);
            }
            while (Math.Abs(graphX - coordinates2.X) != 0 || Math.Abs(graphY - coordinates2.Y) != 0);
        }
    }
}
