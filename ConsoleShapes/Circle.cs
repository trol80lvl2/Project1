using ConsoleShapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    public class Circle : Shape, IHaveArea, IHavePerimeter, IFillable
    {
        public int Radius { get; private set; }

        public double S
        {
            get
            {
                return Math.Round(Math.PI * Radius * Radius, 4); 
            }
        }

        public double P
        {
            get
            {
                return Math.Round(2 * Math.PI * Radius, 4); 
            }
        }
        public Circle(int radius, int depth)
        {
            Radius = radius;
            Depth = depth;
        }

        public override void Draw()
        {
            double thickness = 0.4;
            int symbol = Depth;

            Console.WriteLine();
            double rIn = Radius - thickness, rOut = Radius + thickness;

            for (double y = Radius; y >= -Radius; --y)
            {
                for (double x = -Radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write(symbol);
                    }
                    else 
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void Fill()
        {
            throw new NotImplementedException();
        }

        public override void MoveDown()
        {
            throw new NotImplementedException();
        }

        public override void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public override void MoveRight()
        {
            throw new NotImplementedException();
        }

        public override void MoveUp()
        {
            throw new NotImplementedException();
        }
    }
}
