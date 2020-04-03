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

        private NamedPipeServerStream pipeStream;

        public void setupLink()
        {
           using (NamedPipeServerStream pipeServer =
           new NamedPipeServerStream("HorienceTransaction", PipeDirection.InOut))
            {
                pipeStream = pipeServer;
                pipeServer.WaitForConnection();
                try
                {
                    using (StreamReader sr = new StreamReader(pipeServer))
                    {
                        string temp;
                        while ((temp = sr.ReadLine() + sr.ReadLine()) != null)
                        {
                            MessageReceived = temp;
                            while (sr.Peek() >= 0)
                            {
                               // Debug.Write((char)sr.Read());
                            }
                        }
                    }
                }
                // Catch the IOException that is raised if the pipe is broken
                // or disconnected.
                catch (IOException e)
                {
                    throw e;
                }
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
