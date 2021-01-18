//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace EngineLibrary.Shapes
//{
//    public class Triangle : Shape
//    {
//        public override double Area
//        {
//            get
//            {
//                return Height * BottomLength / 2;
//            }
//        }

//        public override double Perimeter
//        {
//            get
//            {
//                return BottomLength + 2 * SideLength;
//            }
//        }
//        public int Height { get; set; }
//        private int BottomLength { get; set; }
//        private double SideLength { get; set; }

//        public Triangle(int height, Coordinate top)
//        {
//            Coordinates.Add(top);
//            Height = height;
//            Depth = Char.Parse(3.ToString());
//            isFilled = true;
//        }
//        public override void Draw()
//        {
//            int i = 0;
//            Coordinate temp = Coordinates[0];

//            int xTo = temp.X, xFrom = temp.X;
//            int yTo = temp.Y + Height, yFrom = temp.Y;

//            if (isFilled)
//            {
//                for (int j = yFrom; j < yTo; j++)
//                {
//                    for (int k = xFrom; k <= xTo; k++)
//                    {
//                        ConsoleWriter.SetPoint(k, j, Color, Depth);
//                    }
//                    xFrom--; xTo++;
//                }

//            }
//            else
//            {
//                yTo--;
//                for (int j = yFrom; j < yTo; j++)
//                {
//                    ConsoleWriter.SetPoint(xFrom, j, Color, Depth);
//                    ConsoleWriter.SetPoint(xTo, j, Color, Depth);
//                    xFrom--; xTo++;
//                }
//                for (int u = xFrom; u <= xTo; u++)
//                {
//                    ConsoleWriter.SetPoint(u, yTo, Color, Depth);
//                }
//            }
//            BottomLength = xTo - xFrom - 1;
//            Coordinate sideVectorCoordinate = new Coordinate(Coordinates[0].X - (Coordinates[0].X - BottomLength / 2), Coordinates[0].Y - (Coordinates[0].Y + Height));
//            SideLength = Math.Round(Math.Sqrt(sideVectorCoordinate.X * sideVectorCoordinate.X + sideVectorCoordinate.Y * sideVectorCoordinate.Y), 4);

//        }

//        public override void MoveDown()
//        {
//            if (Coordinates[0].Y <= ConsoleWriter.Height)
//                Coordinates[0].Y++;
//        }

//        public override void MoveLeft()
//        {
//            if (Coordinates[0].X + BottomLength / 2 >= 0)
//                Coordinates[0].X--;
//        }

//        public override void MoveRight()
//        {
//            if (Coordinates[0].X - BottomLength / 2 <= ConsoleWriter.Width)
//                Coordinates[0].X++;
//        }

//        public override void MoveUp()
//        {
//            if (Coordinates[0].Y + Height >= 0)
//                Coordinates[0].Y--;
//        }

//        public override void Increase()
//        {
//            Coordinates[0].Y--;
//            Height++;
//        }

//        public override void Decrease()
//        {
//            Coordinates[0].Y++;
//            Height--;
//        }
//    }
//}
