using System;
using System.Collections.Generic;
using System.Text;

namespace EngineLibrary
{
    public class WriterWrap
    {
        private static ConsoleWriter instance;

        private WriterWrap()
        { }

        public static ConsoleWriter GetInstance()
        {
            if (instance == null)
                instance = new ConsoleWriter(120, 40);
            return instance;
        }
    }
}
