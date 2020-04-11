using System;
using System.Net.Sockets;

namespace Horience.Core.Network.Request
{
    public enum RequestType
    {
        /// <summary>
        /// Register IP of client and send the message history.
        /// Response : yes
        /// </summary>
        CONNECT = 0,
        /// <summary>
        /// Save the message and save it to all connected clients data.
        /// Response : no
        /// </summary>
        SEND_MESSAGE = 1,
        /// <summary>
        /// Send new messages received by the server to the client.
        /// Response : yes
        /// </summary>
        GET_MESSAGES = 2
    }

    class Request
    {
        private const string HOST = "symp.fr";
        private const int PORT = 1073;

        private TcpClient Client = new TcpClient(HOST, PORT);

        private string Response;

        private RequestType RequestType;
        private string Message;

        public Request(RequestType RequestType, string Message = null)
        {
            this.RequestType = RequestType;
            this.Message = Message;
        }

        /// <summary>
        /// Send the request to the server.
        /// </summary>
        /// <returns>
        /// The server response.
        /// </returns>
        public Response Send()
        {
            NetworkStream Stream = Client.GetStream();

            byte[] ByteMessage = null;
            byte[] ResponseBuffer = new Byte[4096];

            switch (RequestType)
            {
                case RequestType.CONNECT:
                    ByteMessage = System.Text.Encoding.UTF8.GetBytes(
                        "connect/-/"
                        );
                    ResponseBuffer = new byte[65536];
                    break;

                case RequestType.SEND_MESSAGE:
                    ByteMessage = System.Text.Encoding.UTF8.GetBytes(
                        "sendMessage/-/" + Main.GetInstance().GetClient().getName() + " : " + Message
                        );
                    break;

                case RequestType.GET_MESSAGES:
                    ByteMessage = System.Text.Encoding.UTF8.GetBytes("getMessages/-/");
                    break;
            }

            Stream.Write(ByteMessage, 0, ByteMessage.Length);

            Int32 BytesReceived = Stream.Read(ResponseBuffer, 0, ResponseBuffer.Length);

            Response = System.Text.Encoding.UTF8.GetString(ResponseBuffer, 0, BytesReceived);

            Stream.Close();
            Client.Close();

            return Response != null && Response.Length > 0 ? new Response(Response) : null;
        }
    }
}
