using System;
using System.Threading;

namespace ConsoleShapes
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.CursorVisible = true;
            //TriangleForTestDrawing testDrawing = new TriangleForTestDrawing(new Coordinates(0, 0), new Coordinates(0, 20), new Coordinates(50, 21));
            Triangle triangle = new Triangle(new Coordinates(1, 1), new Coordinates(6, 20), new Coordinates(50, 20), 1);
            Rectangle rectangle = new Rectangle(new Coordinates(1, 1), new Coordinates(20, 20), new Coordinates(1, 20), new Coordinates(20, 1), 2);
            Line line = new Line(new Coordinates(1, 1), new Coordinates(20, 1), 9);
            //Square square = new Square(new Coordinates(0, 0), new Coordinates(0, 20), new Coordinates(50, 20), new Coordinates(50, 0));
            Circle circle = new Circle(5, 5);
            while (true)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        triangle.Draw();
                        break;
                    case ConsoleKey.UpArrow:
                        Console.Clear();
                        triangle.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        Console.Clear();
                        triangle.MoveDown();
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.Clear();
                        triangle.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:

                        Console.Clear();
                        triangle.MoveRight();
                        break;
                }
            }
        }
    }
}
        
    

