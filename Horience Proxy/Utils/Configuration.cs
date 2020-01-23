using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Horience.Utils
{
    public class Configuration
    {
        public static readonly IDictionary<string, object> BaseConfig = new Dictionary<string, object>()
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

        public string BindIp;
        public int BindPort;
        public string RemoteHost;
        public int RemotePort;

        public Configuration()
        {
            if (!File.Exists("config.json"))
            {
                Program.GetInstance().GetLogger().Error("Configuration file not found, creating one.");
                Create();
            }

            Dictionary<string, object> Rows = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText("config.json"));
            BindIp = (string) Rows["BindIp"];
            BindPort = Convert.ToInt32(Rows["BindPort"]);
            RemoteHost = (string) Rows["RemoteIp"];
            RemotePort = Convert.ToInt32(Rows["RemotePort"]);
        }

        public string GetIp()
        {
            return BindIp;
        }
        
        public int GetPort()
        {
            return BindPort;
        }
        
        public string GetRemoteIp()
        {
            return RemoteHost;
        }
        
        public int GetRemotePort()
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