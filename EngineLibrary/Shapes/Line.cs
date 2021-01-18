//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace EngineLibrary.Shapes
//{
//    public class Line : Shape
//    {
//        public override double Area
//        {
//            get
//            {
//                return 0;
//            }
//        }

//        public override double Perimeter
//        {
//            get
//            {
//                return Math.Abs(Coordinates[0].X - Coordinates[1].X);
//            }
//        }


//        public Line(Coordinate start, Coordinate finish)
//        {
//            Coordinates.Add(start);
//            Coordinates.Add(finish);
//            Color = ConsoleColor.White;
//            Depth = Char.Parse(3.ToString());
//        }
//        public override void Draw()
//        {
//            for(int x = Coordinates[0].X; x < Coordinates[1].X; x++)
//            {
//                ConsoleWriter.SetPoint(x, Coordinates[0].Y, Color, Depth);
//            }
//        }

//        public override void MoveDown()
//        {
//            if (Coordinates[0].Y <= ConsoleWriter.Height) 
//            {
//                Coordinates[0].Y++; Coordinates[1].Y++;
//            }
//        }

//        public override void MoveLeft()
//        {
//            if (Coordinates[1].X >= 0)
//            {
//                Coordinates[0].X--;Coordinates[1].X--;
//            }
//        }

//        public override void MoveRight()
//        {
//            if (Coordinates[0].X <= ConsoleWriter.Width)
//            {
//                Coordinates[0].X++; Coordinates[1].X++;
//            }
//        }

//        public override void MoveUp()
//        {
//            if (Coordinates[0].Y >= 0)
//            {
//                Coordinates[0].Y--; Coordinates[1].Y--;
//            }
//        }

//        public override void Increase()
//        {
//            Coordinates[1].X++;
//        }

//        public override void Decrease()
//        {
//            Coordinates[1].X--;
//        }
//    }
//}
