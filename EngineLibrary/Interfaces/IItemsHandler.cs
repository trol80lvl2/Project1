using EngineLibrary.Items;
using System.Collections.Generic;

namespace EngineLibrary.Interfaces
{
    public interface IItemsHandler
    {
        IList<Shape> Items { get; }
        Shape CurrentItem { get; }
        void AddItem(int typeIndex);
        void RemoveItem();
        void SelectItem(int index);
        void SaveScene(int index);
        void LoadScene(int index);
        void ToggleSortByLength();
        void ToggleSortByArea();
    }
}
