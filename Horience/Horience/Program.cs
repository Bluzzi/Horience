using System;
using Horience.Logging;

namespace Horience
{
    class Program
    {
        private Logger Logger = new Logger("Horience");

        static void Main(string[] args)
        {
            new Program(args);
        }

        public Program(string[] args)
        {
            GetLogger().Info("Starting Horience...");
        }

        public Logger GetLogger()
        {
            return Logger;
        }
    }
}
