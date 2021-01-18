using EngineLibrary.Core;
using EngineLibrary.Items.Interfaces;
using System;

namespace EngineLibrary.Items
{
    public class Rectangle : Shape, IModifiable, IGeometricObject
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int x, int y, int width, int height) : base(x, y)
        {
            Width = width;
            Height = height;
        }
        public Rectangle()
        {

        }

        public void ChangeHorizontal(int delta)
        {
            if (Width + delta <= 0)
                return;
            Width += delta;
        }

        public void ChangeVertical(int delta)
        {
            if (Height + delta <= 0)
                return;
            Height += delta;
        }

        public override void Draw(ConsoleWriter writer, char symb)
        {
            for (int x = 0; x < Width * writer.ScaleX; x++)
            {
                writer.SetPoint((int)(X * writer.ScaleX) + x, (int)(Y * writer.ScaleX), symb);
                writer.SetPoint((int)(X * writer.ScaleX) + x, (int)((Y + Height / 2) * writer.ScaleX), symb);
            }

            for (int y = 0; y < Height / 2 * writer.ScaleX; y++)
            {
                writer.SetPoint((int)(X * writer.ScaleX), (int)(Y * writer.ScaleX) + y, symb);
                writer.SetPoint((int)((X + Width - 0.1) * writer.ScaleX), (int)(Y * writer.ScaleX) + y, symb);
            }

            if (isFilled)
                for (int y = 0; y < Height / 2 * writer.ScaleX; y++)
                    for (int x = 0; x < Width * writer.ScaleX; x++)
                        writer.SetPoint((int)(X * writer.ScaleX) + x, (int)(Y * writer.ScaleX) + y, symb);

        }

        public int GetPerimeterOrLength()
        {
            return 2 * Width + 2 * Height;
        }

        public double GetArea()
        {
            return Width * Height;
        }
    }
}
