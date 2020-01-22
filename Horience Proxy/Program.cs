using System;
using System.IO;
using Horience.Utils;
using Newtonsoft.Json;

namespace Horience
{
    class Program
    {
        private Logger.Logger Logger = new Logger.Logger("Horience");

        static void Main(string[] args)
        {
            new Program(args);
        }

        public Program(string[] args)
        {
            GetLogger().Info("Starting Horience...");

            if (!File.Exists("config.json"))
            {
                GetLogger().Error("config.json file not found.");
                Console.ReadKey();
                return;
            }
            Configuration Config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("config.json"));
            GetLogger().Info("Starting proxy server on : " + Config.bindIp + ":" + Config.bindPort);
            
            Console.ReadKey();
        }

        public Logger.Logger GetLogger()
        {
            return Logger;
        }
    }
}
