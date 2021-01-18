using EngineLibrary.Interfaces;
using EngineLibrary.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EngineLibrary.Services
{
    public class SceneSaver : ISceneSaver
    {
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        public IList<Shape> LoadScene(int index)
        {
            List<Shape> loadedItems = new List<Shape>();

            string filePath = $"save\\save{index}.json";
            if (!File.Exists(filePath))
                return loadedItems;
            string jsonSave = File.ReadAllText(filePath);

            List<BaseItemSerializable> objs = JsonSerializer.Deserialize<List<BaseItemSerializable>>(jsonSave, _jsonOptions);
            foreach (var obj in objs)
                loadedItems.Add((Shape)JsonSerializer.Deserialize(obj.SerializedBaseItem, Type.GetType(obj.Type), _jsonOptions));

            return loadedItems;
        }

        public void SaveScene(IList<Shape> items, int index)
        {
            string jsonSave;
            string filePath = $"save\\save{index}.json";

            List<BaseItemSerializable> forSaveData = new List<BaseItemSerializable>();
            foreach (var item in items)
                forSaveData.Add(new BaseItemSerializable(JsonSerializer.Serialize(item, item.GetType(), _jsonOptions), item.GetType()));
            jsonSave = JsonSerializer.Serialize<List<BaseItemSerializable>>(forSaveData, _jsonOptions);

            FileInfo file = new FileInfo(filePath);
            file.Directory.Create();
            File.WriteAllText(file.FullName, jsonSave);
        }
    }
}
