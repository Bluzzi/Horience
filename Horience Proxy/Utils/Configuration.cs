using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Horience.Utils
{
    public class Configuration
    {
        private static readonly IDictionary<string, object> BaseConfig = new Dictionary<string, object>()
        {
            {
                "BindIp", "0.0.0.0"
            },
            {
                "BindPort", 19132
            },
            {
                "RemoteIp", "0.0.0.0"
            },
            {
                "RemotePort", 19133
            }
        };

        private string BindIp;
        private long BindPort;
        private string RemoteHost;
        private long RemotePort;

        public Configuration()
        {
            if (!File.Exists("config.json"))
            {
                Program.GetInstance().GetLogger().Error("Configuration file not found, creating one.");
                Create();
            }

            IDictionary<string, object> Rows = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText("config.json"));
            BindIp = (string) Rows["BindIp"];
            BindPort = (long) Rows["BindPort"];
            RemoteHost = (string) Rows["RemoteIp"];
            RemotePort = (long) Rows["RemotePort"];
        }

        public string GetIp()
        {
            return BindIp;
        }
        
        public long GetPort()
        {
            return BindPort;
        }
        
        public string GetRemoteIp()
        {
            return RemoteHost;
        }
        
        public long GetRemotePort()
        {
            return RemotePort;
        }

        public void Create()
        {
            File.Create("config.json").Close();
            File.WriteAllText("config.json", JsonConvert.SerializeObject(BaseConfig, Formatting.Indented));
        }
    }
}