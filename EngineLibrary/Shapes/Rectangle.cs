//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace EngineLibrary.Shapes
//{
//    public class Rectangle : Shape
//    {
//        public override double Area
//        {
//            get
//            {
//                return LeftSideLength * TopSideLength;
//            }
//        }
//        public override double Perimeter
//        {
//            get
//            {
//                return 2 * (LeftSideLength + TopSideLength);
//            }
//        }
//        private int LeftSideLength { get; set; }
//        private int TopSideLength { get; set; }

//        public Rectangle(Coordinate topLeft, Coordinate botRight)
//        {
//            Coordinates.Add(topLeft);//[0]topLeft
//            Coordinates.Add(botRight);//[1]botRight
//            Coordinates.Add(new Coordinate(Coordinates[1].X, Coordinates[0].Y));//[2]topRight
//            Coordinates.Add(new Coordinate(Coordinates[0].X, Coordinates[1].Y));//[3]botLeft

//            LeftSideLength = Coordinates[0].Y - Coordinates[3].Y;
//            TopSideLength = Coordinates[2].X - Coordinates[0].X;
//        }

//        public override void Draw()
//        {
//            Depth = Char.Parse(9.ToString());
//            //isFilled = true;
//            if (isFilled)
//            {
//                for(int y = Coordinates[0].Y; y < Coordinates[1].Y/2; y++)
//                {
//                    for(int x = Coordinates[0].X; x < Coordinates[1].X; x++)
//                    {
//                        ConsoleWriter.SetPoint(x, y, Color, Depth);
//                    }
//                }
//            }
//            else
//            {
//                for (int y = Coordinates[0].Y; y < Coordinates[1].Y / 2; y++)
//                {
//                    for (int x = Coordinates[0].X; x < Coordinates[1].X; x++)
//                    {
//                        if(x == Coordinates[0].X || x == Coordinates[1].X-1 || y == Coordinates[0].Y || y == Coordinates[1].Y/2-1)
//                            ConsoleWriter.SetPoint(x, y, Color, Depth);
//                    }
//                }
//            }
//        }

//        public override void MoveDown()
//        {
//            if (Coordinates[0].Y <= ConsoleWriter.Height)
//            {
//                Coordinates[0].Y ++; Coordinates[1].Y +=2;
//                Coordinates[2].Y ++; Coordinates[3].Y +=2 ;
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
//            if(Coordinates[0].X <= ConsoleWriter.Width)
//            {
//                Coordinates[0].X++;Coordinates[1].X++;
//            }
//        }

//        public override void MoveUp()
//        {
//            if (Coordinates[1].Y >= 0)
//            {
//                Coordinates[0].Y--; Coordinates[1].Y -= 2;
//                Coordinates[2].Y--; Coordinates[3].Y -= 2;
//                //Coordinates[0].Y--; Coordinates[1].Y--;
//            }
                
//        }

//        public override void Increase()
//        {
//            Coordinates[2].X++;
//            Coordinates[1].X++;
//            Coordinates[3].Y ++;
//            Coordinates[1].Y ++;
//        }

//        public override void Decrease()
//        {
//            Coordinates[2].X--;
//            Coordinates[1].X--;
//            Coordinates[3].Y--;
//            Coordinates[1].Y --;
//        }
//    }
//}
