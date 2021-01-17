using System;
using System.Collections.Generic;
using System.Text;

namespace EngineLibrary
{
    public class ConsoleWriter
    {
        public readonly int Width;
        public readonly int Height;

        private Point[,] _activeBuffer;
        private Point[,] _activeView;

        public ConsoleWriter(int width, int height)
        {
            Width = width;
            Height = height;

            Console.SetWindowSize(width, height);

            _activeBuffer = new Point[width, height];
            _activeView = new Point[width, height];

            Clean(_activeBuffer);
            Clean(_activeView);
        }

        public void SetPoint(int i, int j, ConsoleColor color, char symb)
        {
            if (i < 0 || i >= Width) return;
            if (j < 0 || j >= Height) return;

            _activeBuffer[i, j] = new Point(color, symb);
        }

        public void Flush()
        {
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    var view = _activeView[i, j];
                    var buff = _activeBuffer[i, j];

                    if (!Equals(view, buff))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.ForegroundColor = buff.Color;
                        Console.Write(buff.Symb);
                    }
                }
            }

            var temp = _activeBuffer;
            _activeBuffer = _activeView;
            _activeView = temp;

            Clean(_activeBuffer);
        }

        private void Clean(Point[,] view)
        {
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    view[i, j] = Point.Empty;
                }
            }
        }
        public void Clean()
        {
            Clean(_activeBuffer);
            Clean(_activeView);
        }
    }
}
