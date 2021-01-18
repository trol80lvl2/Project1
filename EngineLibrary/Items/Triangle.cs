using EngineLibrary.Core;
using EngineLibrary.Items.Interfaces;
using System;

namespace EngineLibrary.Items
{
    public class Triangle : Shape, IModifiable, IGeometricObject
    {
        public int Height { get; private set; }
        public int BottomLength { get; private set; }
        public Triangle(int x, int y, int height) : base(x, y)
        {
            Height = height;
        }
        public Triangle()
        {

        }
        public void ChangeHorizontal(int delta)
        {
            ChangeVertical(delta);
        }

        public void ChangeVertical(int delta)
        {
            if (Height + delta <= 0)
                return;
            Height += delta;
        }

        public override void Draw(ConsoleWriter writer, char symb)
        {
            int i = 0;

            int xTo = X, xFrom = X;
            int yTo = Y + Height, yFrom = Y;

            if (isFilled)
            {
                for (int j = yFrom; j < yTo; j++)
                {
                    for (int k = xFrom; k <= xTo; k++)
                    {
                        writer.SetPoint(k, j, symb);
                    }
                    xFrom--; xTo++;
                }

            }
            else
            {
                yTo--;
                for (int j = yFrom; j < yTo; j++)
                {
                    writer.SetPoint(xFrom, j, symb);
                    writer.SetPoint(xTo, j, symb);
                    xFrom--; xTo++;
                }
                for (int u = xFrom; u <= xTo; u++)
                {
                    writer.SetPoint(u, yTo, symb);
                }
            }
            BottomLength = xTo - xFrom - 1;
        }

        public double GetArea()
        {
            return BottomLength * Height / 2;
        }

        public int GetPerimeterOrLength()
        {
            return (int)Math.Sqrt(Height * Height + (BottomLength / 2) * (BottomLength / 2)) * 2 + BottomLength;    
        }
    }
}
