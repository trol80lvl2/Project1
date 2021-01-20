using EngineLibrary.Interfaces;
using EngineLibrary.Items;
using EngineLibrary.Items.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EngineLibrary.Services
{
    public class ItemsHandler : IItemsHandler
    {
        public IList<Shape> Items { get; private set; } = new List<Shape>();
        public Shape CurrentItem { get; private set; }

        private readonly ISceneSaver _saver = new SceneSaver();

        public void AddItem(int typeIndex)
        {
            if (Items.Count > 9)
                return;


            switch (typeIndex)
            {
                case 1:
                    Items.Add(new Line(0, GetShiftedCoordinate(5), 50));
                    break;
                case 2:
                    Items.Add(new Triangle(19, GetShiftedCoordinate(10), 10));
                    break;
                case 3:
                    Items.Add(new Rectangle(0, GetShiftedCoordinate(10), 30, 30));
                    break;
                case 4:
                    Items.Add(new Circle(20, 20 + GetShiftedCoordinate(20), 10));
                    break;
            }

            if (Items.Count > 0)
                CurrentItem = Items[Items.Count - 1];
        }

        public void RemoveItem()
        {
            Items.Remove(CurrentItem);
            if (Items.Count > 0)
                CurrentItem = Items[Items.Count - 1];
        }

        public void SelectItem(int index)
        {
            if (index >= 0 && index < Items.Count)
                CurrentItem = Items[index];
        }

        private int GetShiftedCoordinate(int shiftValue)
        {
            return Items.Count > 0 ? Items[Items.Count - 1].Y + shiftValue : 0;
        }

        public void SaveScene(int index)
        {
            _saver.SaveScene(Items, index);
        }

        public void LoadScene(int index)
        {
            Items = _saver.LoadScene(index);
            if (Items.Count > 0)
                CurrentItem = Items[Items.Count - 1];
        }

        public void ToggleSortByLength()
        {
            var orderedAsc = Items.OrderBy(i => (i as IGeometricObject)?.GetPerimeterOrLength());
            if (!Items.SequenceEqual(orderedAsc))
                Items = orderedAsc.ToList();
            else
                Items = orderedAsc.Reverse().ToList();
        }

        public void ToggleSortByArea()
        {
            var orderedAsc = Items.OrderBy(i => (i as IGeometricObject)?.GetArea());
            if (!Items.SequenceEqual(orderedAsc))
                Items = orderedAsc.ToList();
            else
                Items = orderedAsc.Reverse().ToList();
        }

    }
}
