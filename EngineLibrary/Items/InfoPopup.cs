using System;
using EngineLibrary.Core;

namespace EngineLibrary.Items
{
    class InfoPopup : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int BorderThickness { get; set; }
        public char BorderSymbol { get; set; }

        public bool IsVisible { get; set; } = true;

        public InfoPopup(int width, int height, int borderThickness, char borderSymbol)
        {
            Width = width;
            Height = height;
            BorderThickness = borderThickness;
            BorderSymbol = borderSymbol;
        }

        public override void Draw(ConsoleWriter writer, char symb = '0')
        {
            if (!IsVisible)
                return;

            DrawRect(writer);
            DrawText(writer);
        }

        private void DrawRect(ConsoleWriter writer)
        {
            for (int y = BorderThickness; y < Height - BorderThickness; y++)
                for (int x = BorderThickness; x < Width - BorderThickness; x++)
                    writer.SetPoint(x + X, y + Y, ' ');

            for (int i = 0; i < Width; i++)
            {
                writer.SetPoint(X + i, Y, BorderSymbol);
                writer.SetPoint(X + i, Y + Height, BorderSymbol);
            }

            for (int i = 0; i < Height; i++)
            {
                writer.SetPoint(X, Y + i, BorderSymbol);
                writer.SetPoint(X + Width - BorderThickness, Y + i, BorderSymbol);
            }
        }

        private void DrawText(ConsoleWriter writer)
        {
            string info = "\t\t\t\tThis hight-performance console renderer made by Roman Holub\n\n" +
                "\tCONTROL KEYS:\n\n" +
                "H - hide/show this menu\n\n" +
                "A, [1-4] - add a shape with standart parametes of the following type:\n\n" +
                "  1 - Line\n\n" +
                "  2 - Triangle\n\n" +
                "  3 - Rectangle\n\n" +
                "  4 - Circle\n\n" +
                "[0-9] - select the shape\n\n" +
                "R - remove selected item\n\n" +
                "<Arrows> - move item or change size (modify mode)\n\n" +
                "M - toggle modify mode\n\n" +
                "F - outline/solid drawing\n\n" +
                "Q - toggle sort (asc/desc) by perimeter (length)\n\n" +
                "W - toggle sort (asc/desc) by area\n\n" +
                "S, [0-9] - save scene to preset\n\n" +
                "L, [0-9] - load scene from preset\n\n" +
                "Esc - exit";
            writer.WriteText(X + 4, Y + 2, info, ConsoleColor.White);
        }

    }
}
