using System;

namespace ConsoleShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            //TriangleForTestDrawing testDrawing = new TriangleForTestDrawing(new Coordinates(0, 0), new Coordinates(0, 20), new Coordinates(50, 21));
            //Triangle triangle = new Triangle(new Coordinates(0, 0), new Coordinates(0, 20), new Coordinates(50, 20));
            //Square square = new Square(new Coordinates(0, 0), new Coordinates(0, 20), new Coordinates(50, 20), new Coordinates(50, 0));
            while (true)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        //square.Draw();
                        break;
                    case ConsoleKey.UpArrow:
                        Console.Clear();
                        //testDrawing.ChangeCoordinatesY(-1);
                        break;
                    case ConsoleKey.DownArrow:
                        Console.Clear();
                        //testDrawing.ChangeCoordinatesY(1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.Clear();
                        //testDrawing.ChangeCoordinatesX(-1);
                        break;
                    case ConsoleKey.RightArrow:
                        Console.Clear();
                        //testDrawing.ChangeCoordinatesX(1);
                        break;
                }
            }
            
            
        }
    }
}
        
    

