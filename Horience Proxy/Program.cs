using System;
using Horience.Network;
using Horience.Utils;

namespace Horience
{
    class Program
    {
        private static Program Instance;
        private Logger.Logger Logger = new Logger.Logger("Horience");
        private Configuration Config;
        private UdpSocket Socket;

        static void Main(string[] args)
        {
            new Program(args);
        }

        public Program(string[] args)
        {
            Instance = this;
            GetLogger().Info("Starting Horience...");
            Config = new Configuration();
            GetLogger().Info("Starting proxy server on : " + GetConfig().GetIp() + ":" + GetConfig().GetPort());
            Socket = new UdpSocket(GetConfig());
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

        public UdpSocket GetSocket()
        {
            return Socket;
        }
    }
}
