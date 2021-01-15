using ConsoleShapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    class Circle : Shape, IHaveArea, IHavePerimeter, IFillable
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

        public override void Draw()
        {
            throw new NotImplementedException();
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
