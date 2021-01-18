using System;
using System.Linq;

namespace EngineLibrary.Core
{
    public class ConsoleWriter
    {
        public readonly int Width;
        public readonly int Height;

        public double StandartWidth { get; set; } = 130;
        public double StandartHeight { get; set; } = 60;
        public double ScaleX { get; }
        public double ScaleY { get; }

        private Point[][] _activeBuffer;
        private Point[][] _activeView;

        public ConsoleWriter() : this(130, 60)
        {

        }

        public ConsoleWriter(int width, int height)
        {
            Width = width;
            Height = height;

            ScaleX = Width / StandartWidth;
            ScaleY = Height / StandartHeight;

            Console.SetWindowSize(width, height);
            Console.CursorVisible = false;

            _activeBuffer = new Point[width][];
            _activeView = new Point[width][];

            for(int i = 0; i < width; i++)
            {
                _activeBuffer[i] = new Point[height];
                _activeView[i] = new Point[height];
            }

            Console.Clear();
            Clean(_activeBuffer);
            Clean(_activeView);
        }

        public void SlowFlush()
        {
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    var view = _activeView[i][j];
                    var buff = _activeBuffer[i][j];

                    if (!Equals(view, buff))
                    {
                        if (i < 0 || i >= Console.WindowWidth) return;
                        if (j < 0 || j >= Console.WindowHeight) return;
                        Console.SetCursorPosition(i, j);
                        Console.ForegroundColor = buff.Color;
                        Console.Write(buff.Symb);
                    }
                }
            }

            var temp = _activeBuffer;
            _activeBuffer = _activeView;
            _activeView = temp;

            Console.CursorVisible = false;
            Clean(_activeBuffer);
        }

        public void FastFlush()
        {
            Point[][] reversedView = new Point[Height][];
            Point[][] reversedBuff = new Point[Height][];

            for (int i = 0; i < Height; i++)
            {
                reversedView[i] = new Point[Width];
                reversedBuff[i] = new Point[Width];
            }

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    reversedView[j][i] = _activeView[i][j];
                    reversedBuff[j][i] = _activeBuffer[i][j];
                }
            }

            for (var i = 0; i < Height; i++)
            {
                if(!Equals(reversedView, reversedBuff))
                {
                    Console.SetCursorPosition(0, i);
                    Console.ForegroundColor = ConsoleColor.White;
                    char[] symbReversedBuff = reversedBuff[i].Select(p => p.Symb).ToArray();
                    Console.Write(symbReversedBuff);
                }
            }

            Console.CursorVisible = false;
            Clean(_activeBuffer);
        }

        public void WriteText(int x, int y, string text, ConsoleColor color)
        {
            
            for (int symbolIndex = 0, xPos = 0; symbolIndex < text.Length; symbolIndex++, xPos++)
            {
                if (text[symbolIndex] == '\n')
                {
                    y++; 
                    xPos = -1;
                    continue;
                }
                if (text[symbolIndex] == '\t')
                {
                    xPos += 7;
                    continue;
                }
                
                SetPoint(x + xPos, y, text[symbolIndex], color);
            }
        }

        public void SetPoint(int x, int y, char symb, ConsoleColor color = ConsoleColor.White)
        {
            if (x < 0 || x >= Width) return;
            if (y < 0 || y >= Height) return;

            _activeBuffer[x][y] = new Point(color, symb);
        }

        private void Clean(Point[][] view)
        {
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    view[i][j] = Point.Empty;
                }
            }
        }
    }
}
