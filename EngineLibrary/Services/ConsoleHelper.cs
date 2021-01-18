using EngineLibrary.Items;
using System;

namespace EngineLibrary.Services
{
    public static class ConsoleHelper
    {
        public static int ReadDigitOrDefault()
        {
            var realtimeInfo = RealtimeInfo.GetInstance();
            realtimeInfo.Message = "Awaiting 2nd key";
            ConsoleKeyInfo saveIndex = Console.ReadKey(true);
            realtimeInfo.Message = "";
            return ((int)saveIndex.Key > 47 && (int)saveIndex.Key < 58) ? (int)(saveIndex.Key - '0') : 0;
        }
    }
}
