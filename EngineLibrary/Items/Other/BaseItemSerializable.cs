using System;

namespace EngineLibrary.Items
{
    public class BaseItemSerializable
    {
        public string SerializedBaseItem { get; set; }
        public string Type { get; set; }
        public BaseItemSerializable(string item, Type type)
        {
            SerializedBaseItem = item;
            Type = type.FullName;
        }
        public BaseItemSerializable()
        {

        }
    }
}
