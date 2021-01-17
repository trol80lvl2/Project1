using System;
using System.Collections.Generic;
using System.Text;

namespace EngineLibrary
{
    public abstract class Shape
    {
        public ConsoleWriter ConsoleWriter { get; private set; }

        public ConsoleColor Color { get; set; }
        public abstract double Area { get; }
        public abstract double Perimeter { get; }
        public List<Coordinate> Coordinates { get; set; }
        public char Depth { get; set; }
        public bool isFilled { get; set; }
        public abstract void Draw();
        public abstract void MoveUp();
        public abstract void MoveDown();
        public abstract void MoveLeft();
        public abstract void MoveRight();
        public abstract void Increase();
        public abstract void Decrease();


        public Shape()
        {
            Coordinates = new List<Coordinate>();
            ConsoleWriter = WriterWrap.GetInstance();
        }
    }
}
