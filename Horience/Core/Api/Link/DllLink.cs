using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horience.Core.Api.Link
{
    class DllLink
    {

        private string MessageReceived;
        private string LastMessageReceived;
        public bool IsConnected;

        private NamedPipeServerStream pipeStream;
        private StreamReader StreamReader;

        public void setupLink()
        {
           using (NamedPipeServerStream pipeServer =
           new NamedPipeServerStream("HorienceTransaction", PipeDirection.InOut))
            {
                pipeStream = pipeServer;
                pipeServer.WaitForConnection();
                IsConnected = true;
                StreamReader = new StreamReader(pipeServer);
            }
            
        }

        public void CheckForUpdates()
        {
            try
            {
                  string temp;
                  while ((temp = StreamReader.ReadLine()) != null)
                  {
                        List<string> output = new List<string>();
                        while (StreamReader.Peek() >= 0)
                        {
                            char character = (char)StreamReader.Read();
                            output.Add(character.ToString());

                        }
                        MessageReceived = string.Join("", output.ToArray());
                    }
            }
            catch (IOException e)
            {
                throw e;
            }
        }

        public void SendMessage(string message)
        {
            using (StreamWriter sw = new StreamWriter(pipeStream))
            {
                sw.WriteLine(message);
            }
        }

        public bool HasNewMessage()
        {
            if(LastMessageReceived != MessageReceived)
            {
                LastMessageReceived = MessageReceived;
                return true;
            }

            return false;
        }

        public string GetNewMessage()
        {
            return MessageReceived;
        }
    }
}
