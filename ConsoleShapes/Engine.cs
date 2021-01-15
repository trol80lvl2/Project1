using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShapes
{
    class Engine
    {
        List<Shape> Shapes { get; set; }
        Shape ActiveShape { get; set; }
        public Engine()
        {
            Shapes = new List<Shape>();
        }

        public void AddShape(Shape shape) 
        {
            Shapes.Add(shape);
        }
        public void DeleteShape()
        {
            Shapes.Remove(ActiveShape);
        }
        public void SelectShape()
        {

        }
    }
}
