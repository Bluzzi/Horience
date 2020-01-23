using System;
using System.IO;
using Horience.Utils;
using Newtonsoft.Json;

namespace Horience
{
    class Program
    {
        private static Program Instance;
        private Logger.Logger Logger = new Logger.Logger("Horience");
        private Configuration Config;

        static void Main(string[] args)
        {
            new Program(args);
        }

        public Program(string[] args)
        {
            Instance = this;
            GetLogger().Info("Starting Horience...");
            Config = new Configuration();
            Console.WriteLine("Starting proxy server on : " + GetConfig().GetIp() + ":" + GetConfig().GetPort());
            Console.ReadKey();
        }

        public static Program GetInstance()
        {
            return Instance;
        }
        
        public Logger.Logger GetLogger()
        {
            return Logger;
        }

        public Configuration GetConfig()
        {
            return Config;
        }
    }
}
