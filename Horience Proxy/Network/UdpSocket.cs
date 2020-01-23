using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Horience.Utils;

namespace Horience.Network
{
    public class UdpSocket
    {
        private Configuration _config;
        private UdpClient Client;

        public UdpSocket(Configuration configuration)
        {
            _config = configuration;
            
            EndPoint endPoint = new IPEndPoint(IPAddress.Parse(GetConfig().GetIp()), (int) GetConfig().GetPort());
            Client = CreateClient();

            try
            {
                Client.Client.Bind(endPoint);
                Program.GetInstance().GetLogger().Info("Successfully bound to : " + endPoint);
            }
            catch (Exception ex)
            {
                Program.GetInstance().GetLogger().Error("Can not bind to : " + endPoint);
                Console.ReadKey();
                Environment.Exit(Environment.ExitCode);
            }

            new Thread(Receive) { IsBackground = true }.Start(Client);
        }

        private void Receive(object client)
        {
            UdpClient Client = (UdpClient) client;

            while (true)
            {
                if (Client.Client == null) return;

                IPEndPoint ipEndPoint = null;

                try
                {
                    Byte[] receiveBytes = Client.Receive(ref ipEndPoint);

                    try
                    {
                        Program.GetInstance().GetLogger().Debug("Received bytes : " + receiveBytes.ToString());
                    }
                    catch (Exception ex)
                    {
                        Program.GetInstance().GetLogger().Debug("Can not process : " + ipEndPoint);
                    }
                }
                catch (Exception ex)
                {
                    Program.GetInstance().GetLogger().Error(ipEndPoint + " is down");
                    
                    if (Client.Client != null)
                    {
                        continue;
                    }

                    return;
                }
            }
        }
        
        private UdpClient CreateClient()
        {
            UdpClient Client = new UdpClient();

            Client.Client.ReceiveBufferSize = int.MaxValue;
            Client.Client.SendBufferSize = int.MaxValue;
            Client.DontFragment = false;
            Client.EnableBroadcast = true;

            if (Environment.OSVersion.Platform != PlatformID.Unix && Environment.OSVersion.Platform != PlatformID.MacOSX)
            {
                uint IOC_IN = 0x80000000;
                uint IOC_VENDOR = 0x18000000;
                uint SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;
                Client.Client.IOControl((int) SIO_UDP_CONNRESET, new byte[] { Convert.ToByte(false) }, null);
            }
            
            return Client;
        }

        public Configuration GetConfig()
        {
            return _config;
        }
    }
}