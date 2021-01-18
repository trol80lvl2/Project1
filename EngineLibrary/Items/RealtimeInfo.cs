using System;
using System.Collections.Generic;
using System.Linq;
using EngineLibrary.Core;

namespace EngineLibrary.Items
{
    class RealtimeInfo : Shape
    {
        private string _message;
        public string Message 
        { 
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                if (_localWriter != null) 
                {
                    Draw(_localWriter);
                    _localWriter.SlowFlush();
                }
            } 
        }
        private Dictionary<string, string> info = new Dictionary<string, string>();
        private static RealtimeInfo instance;
        private ConsoleWriter _localWriter;
        private int _maxLength;

        protected RealtimeInfo()
        {

        }
        public static RealtimeInfo GetInstance()
        {
            if (instance == null)
                instance = new RealtimeInfo();
            return instance;
        }

        public void SetInfo(string name, string value)
        {
            info[name] = value;
        }

        public void SetInfo(string name, int value)
        {
            info[name] = value.ToString();
        }

        public override void Draw(ConsoleWriter writer, char symb = '0')
        {
            if (_localWriter != writer)
                _localWriter = writer;

            string outputString = "";
            string maxLengthKey = info.OrderByDescending(s => s.Key.Length + s.Value.Length).First().Key;

            int maxLength = maxLengthKey.Length + info[maxLengthKey].Length;
            if (maxLength > _maxLength)
                _maxLength = maxLength;

            foreach (var item in info)
            {
                outputString += $"{item.Key}: {item.Value}\n";
            }
            outputString += $"{Message}";
            writer.WriteText(writer.Width - (_maxLength + 5), 1, outputString, ConsoleColor.Green);
        }
    }
}
