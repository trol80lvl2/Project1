using EngineLibrary.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineLibrary
{
    public class Engine
    {
        private ConsoleWriter consoleWriter = WriterWrap.GetInstance();
        ConsoleColor activeShapeColor = ConsoleColor.Blue;
        private List<Shape> shapes = new List<Shape>();
        Shape activeShape;

        public Engine()
        {
            int x = 20;
            for (int i = 0; i < 4; i++)
            {
                Console.CursorVisible = false;
                Circle circle = new Circle(10, new Coordinate(x, consoleWriter.Height / 2));
                circle.Color = ConsoleColor.Blue;
                circle.Depth = Char.Parse(i.ToString());
                shapes.Add(circle);
                activeShape = circle;
                x += 30;
                activeShape.Draw();
            }
            //Line triangle = new Line(new Coordinate(25, 10), new Coordinate(45,10));
            //shapes.Add(triangle);
            //activeShape = triangle;
            //activeShape.Draw();
            //consoleWriter.Flush();

            Triangle rectangle = new Triangle(10, new Coordinate(20, 10));
            rectangle.Color = ConsoleColor.Green;
            shapes.Add(rectangle);
            activeShape = rectangle;
            activeShape.Draw();
            consoleWriter.Flush();
        }
        public void Start()
        {
            while (true)
            {
                ConsoleKeyInfo key = new ConsoleKeyInfo();
                if(TryReadDigit(out key))
                {
                    try
                    {
                        activeShape.Color = activeShapeColor;
                        
                        activeShape = shapes[Convert.ToInt32(key.KeyChar)-49];
                        activeShapeColor = activeShape.Color;
                        activeShape.Color = ConsoleColor.Red;
                    }
                    catch
                    {
                        activeShape.Color = ConsoleColor.Red;
                    }
                }
                else
                {
                    bool isModifying = false;
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            activeShape.MoveUp();
                            break;
                        case ConsoleKey.DownArrow:
                            activeShape.MoveDown();
                            break;
                        case ConsoleKey.LeftArrow:
                            activeShape.MoveLeft();
                            break;
                        case ConsoleKey.RightArrow:
                            activeShape.MoveRight();
                            break;
                        case ConsoleKey.F:
                            activeShape.isFilled = !activeShape.isFilled;
                            activeShape.Draw();
                            break;
                        case ConsoleKey.M:
                            isModifying = !isModifying;
                            while (isModifying)
                            {
                                var innerKey = Console.ReadKey(true).Key;
                                switch (innerKey)
                                {
                                    case ConsoleKey.UpArrow:
                                        activeShape.Increase();
                                        break;
                                    case ConsoleKey.DownArrow:
                                        activeShape.Decrease();
                                        break;
                                    case ConsoleKey.M:
                                        isModifying = false;
                                        break;
                                }
                                foreach (var shape in shapes)
                                {
                                    shape.Draw();
                                }
                                consoleWriter.Flush();
                                //consoleWriter.Flush();
                            }
                            break;
                    }
                }
                //consoleWriter.Clean();

                foreach(var shape in shapes)
                {
                    shape.Draw();
                }
                consoleWriter.Flush();
            }
        }
        public void AddShape()
        {
            consoleWriter.Clean();
            int x = 15;
            for(int i = 0; i < 4; i++)
            {
                Circle circle = new Circle(10, new Coordinate(x, consoleWriter.Height / 2));
                circle.Color = ConsoleColor.Blue;
                circle.Depth = Char.Parse(i.ToString());
                circle.Draw();
                x += 30;
            }
            consoleWriter.Flush();
        }
        public static bool TryReadDigit(out ConsoleKeyInfo consoleKey)
        {
            ConsoleKeyInfo saveIndex = Console.ReadKey(true);
            consoleKey = saveIndex;
            return ((int)saveIndex.Key > 47 && (int)saveIndex.Key < 58) ? true : false;
        }
    }
}
