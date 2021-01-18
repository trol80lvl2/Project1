using EngineLibrary.Items;
using System.Collections.Generic;

namespace EngineLibrary.Interfaces
{
    public interface ISceneSaver
    {
        void SaveScene(IList<Shape> items, int index);
        IList<Shape> LoadScene(int index);
    }
}
