using EngineLibrary.Core;
using EngineLibrary.Items.Interfaces;
using System;

namespace EngineLibrary.Items
{
    public class Line : Shape, IModifiable, IGeometricObject
    {
        public int Length { get; set; }
        public Line(int x, int y, int length) : base(x, y) 
        {
            Length = length;
        }
        public Line()
        {

        }

        public override void Draw(ConsoleWriter writer, char symb)
        {
            for (int i = 0; i < Length * writer.ScaleX; i++)
                writer.SetPoint((int)(X * writer.ScaleX) + i, (int)(Y * writer.ScaleX), symb); 
        }

        public void ChangeHorizontal(int delta)
        {
            if (Length + delta <= 0)
                return;
            Length += delta;
        }

        public void ChangeVertical(int delta)
        {
            ChangeHorizontal(delta);
        }

        public int GetPerimeterOrLength()
        {
            return Length;
        }

        public double GetArea()
        {
            return 0;
        }
    }
}
