using EngineLibrary.Core;

namespace EngineLibrary.Items
{
    public abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool isFilled { get; set; } = false;

        public Shape()
        {

        }

        public Shape(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual void Move(int dX, int dY)
        {
            X += dX;
            Y += dY;
        }

        public abstract void Draw(ConsoleWriter writer, char symb = '0');
    }
}
