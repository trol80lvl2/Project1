using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    public abstract class Shape
    {
        public int Depth { get; set; }
        public ConsoleColor Color { get; set; }
        public abstract void Draw();
        public abstract void MoveUp();
        public abstract void MoveDown();
        public abstract void MoveLeft();
        public abstract void MoveRight();
    }
}
