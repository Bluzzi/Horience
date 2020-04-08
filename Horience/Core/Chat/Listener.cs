using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Horience.Core.Chat
{
    class Listener
    {
        private Thread ListenerThread;

        private Chat Parent;

        public Listener(Chat Parent)
        {
            this.Parent = Parent;
            ListenerThread = new Thread(() => StartListener());
            ListenerThread.Start();
        }

        public void StartListener()
        {
            IPAddress iP = Dns.GetHostAddresses("symp.fr")[0];
            TcpListener Listener = new TcpListener(IPAddress.Any, 1070);

            Listener.Start();
            Application.Current.Dispatcher.Invoke(() =>
            {
                System.Diagnostics.Debug.WriteLine("oui");
            });
            Byte[] bytes = new Byte[256];
            string StringReceived = null;

            while (true)
            {
                
                TcpClient client = Listener.AcceptTcpClient();
                Console.WriteLine("Connected!");

                NetworkStream stream = client.GetStream();

                int i;

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    StringReceived = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    if (Application.Current == null) return;
                    // Check client messages :
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        System.Diagnostics.Debug.WriteLine("oui");
                        Parent.AddMessage(StringReceived);
                    });
                }
                client.Close();
            }
        }
    }
}
