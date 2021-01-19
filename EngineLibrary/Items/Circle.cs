using EngineLibrary.Core;
using EngineLibrary.Items.Interfaces;
using System;

namespace EngineLibrary.Items
{
    public class Circle : Shape, IModifiable, IGeometricObject
    {
        public int Radius { get; set; }

        public Circle(int x, int y, int radius) : base(x, y)
        {
            Radius = radius;
        }

        public Circle()
        {

        }

        public void ChangeHorizontal(int delta)
        {
            if (Radius + delta <= 0)
                return;
            Radius += delta;
        }

        public void ChangeVertical(int delta)
        {
            ChangeHorizontal(delta);
        }

        public override void Draw(ConsoleWriter writer, char symb)
        {
            int tempRadius = (int)(Radius * writer.ScaleX);
            double rIn = tempRadius - 0.45;
            double rOut = tempRadius + 0.45;
            int tempX = (int)(X / 2*writer.ScaleX), tempY =(int)( Y / 2*writer.ScaleX);
            double xc = tempX - tempRadius, yc = tempY - tempRadius;//Coordonates[0] - center of circle
            double yn = 0, xn = 0;
            for (double y = (tempRadius + yc) , i = 0; y >= (-tempRadius - yc); --y, i++)
            {
                if (yc < 0)
                    yn = y + yc;
                else
                    yn = y;
                for (double x = (-tempRadius - xc), j = 0; x < (rOut + xc); x += 0.5, j++)
                {
                    if (xc < 0)
                        xn = x - xc;
                    else
                        xn = x;
                    double value = xn * xn + yn * yn;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        writer.SetPoint((int)j, (int)i, symb);
                    }
                    else if (isFilled && value < rIn * rIn && value < rOut * rOut)
                    {
                        writer.SetPoint((int)j , (int)i, symb);
                    }
                }
            }
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public int GetPerimeterOrLength()
        {
            return (int)(2 * Math.PI * Radius);
        }
    }
}
