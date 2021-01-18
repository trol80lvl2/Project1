//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace EngineLibrary.Shapes
//{
//    public class Circle : Shape
//    {
//        public int Radius { get; private set; }
//        public override double Area
//        {
//            get
//            {
//                return Math.Round(Radius * Radius * Math.PI, 4);
//            }
//        }

//        public override double Perimeter
//        {
//            get
//            {
//                return Math.Round(2 * Math.PI * Radius, 4);
//            }
//        }

//        public Circle(int radiusLength, Coordinate centerCoordinate)
//        {
//            isFilled = false;
//            Radius = radiusLength;
//            Coordinates.Add(centerCoordinate);
//            Coordinates.AddRange(new List<Coordinate>()
//            {
//                 new Coordinate(centerCoordinate.X,centerCoordinate.Y-Radius) // [1] top coordinate
//                ,new Coordinate(centerCoordinate.X+Radius, centerCoordinate.Y) //[2] left coordinate
//                ,new Coordinate(centerCoordinate.X,centerCoordinate.Y+Radius) //[3] bot coordinate
//                ,new Coordinate(centerCoordinate.X-Radius,centerCoordinate.Y) //[4] right coordinate
//            });
//        }

//        //fix coordinates
//        public override void Draw()
//        {
//            int tempRadius = Radius;
//            double rIn = tempRadius - 0.40;
//            double rOut = tempRadius + 0.40;
//            int tempX = Coordinates[0].X / 2, tempY = Coordinates[0].Y / 2;
//            double xc = tempX - tempRadius, yc = tempY - tempRadius;//Coordonates[0] - center of circle
//            double yn = 0, xn = 0;
//            for (double y = Radius + yc, i = 0; y >= -Radius - yc; --y, i++)
//            {
//                if (yc < 0)
//                    yn = y + yc;
//                else
//                    yn = y;
//                for (double x = -Radius - xc, j = 0; x < rOut + xc; x += 0.5, j++)
//                {
//                    if (xc < 0)
//                        xn = x - xc;
//                    else
//                        xn = x;
//                    double value = xn * xn + yn * yn;
//                    if (value >= rIn * rIn && value <= rOut * rOut)
//                    {
//                        ConsoleWriter.SetPoint((int)j, (int)i, Color, Depth);
//                    }
//                    else if (isFilled && value < rIn * rIn && value < rOut * rOut)
//                    {
//                        ConsoleWriter.SetPoint((int)j, (int)i, Color, Depth);
//                    }

//                }

//            }
//        }
//        //Rewrite borders
//        public override void MoveDown()
//        {
//            if (Coordinates[1].Y < ConsoleWriter.Height)
//                Coordinates[0].Y += 2;
//            RecalculateCoordinates();
//        }

//        public override void MoveLeft()
//        {
//            if (Coordinates[4].X > 0)
//                Coordinates[0].X -= 2;
//            RecalculateCoordinates();
//        }

//        public override void MoveRight()
//        {
//            if (Coordinates[2].X <= ConsoleWriter.Width)
//                Coordinates[0].X += 2;
//            RecalculateCoordinates();
//        }

//        public override void MoveUp()
//        {
//            if (Coordinates[3].Y >= 0)
//                Coordinates[0].Y -= 2;
//            RecalculateCoordinates();
//        }
//        private void RecalculateCoordinates()
//        {
//            Coordinates[1] = new Coordinate(Coordinates[0].X, Coordinates[0].Y - Radius); // [1] top coordinate
//            Coordinates[2] = new Coordinate(Coordinates[0].X - Radius, Coordinates[0].Y); //[2] left coordinate
//            Coordinates[3] = new Coordinate(Coordinates[0].X, Coordinates[0].Y + Radius); //[3] bot coordinate
//            Coordinates[4] = new Coordinate(Coordinates[0].X + Radius, Coordinates[0].Y);
//        }

//        public override void Increase()
//        {
//            Radius++;
//            RecalculateCoordinates();
//        }

//        public override void Decrease()
//        {
//            Radius--;
//            RecalculateCoordinates();
//        }
//    }
//}
