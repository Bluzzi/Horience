using Horience.Core.Api.Colors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Horience.Core.Chat
{
    public class Chat
    {
        private StackPanel ChatList;

        const string HOST = "symp.fr";
        const int PORT = 1073;

        public Chat(StackPanel ChatList)
        {
            this.ChatList = ChatList;
            SendConnectPacket();
            new Listener(this);
        }

        // Add a message in panel chat :

        public void AddMessage(string Message) //TODO: sender name devra etre supprimer est get directement via une propriété prédéfini. 
        {
            if (ChatList.Children.Count > 100) ChatList.Children.RemoveAt(0);

            Label MessageLabel = new Label()
            {
                Content = Message,
                Margin = new Thickness(25, 0, 0, 0),
                FontSize = 20,
                Foreground = new SolidColorBrush(ColorConstants.WHITE)
            };

            ChatList.Children.Add(MessageLabel);
        }

        // Create a new message in the message server :

        public void SendMessage(string Message) //TODO: sender name devra etre supprimer est get directement via une propriété prédéfini.
        {
            TcpClient Client = new TcpClient(HOST, PORT);
            byte[] ByteMessage = System.Text.Encoding.UTF8.GetBytes("sendMessage/-/" + Main.GetInstance().GetClient().getName() + " : " + Message);
            NetworkStream Stream = Client.GetStream();

            Stream.Write(ByteMessage, 0, ByteMessage.Length);

            Stream.Close();
        }

        public void SendConnectPacket()
        {
            TcpClient Client = new TcpClient(HOST, PORT);
            byte[] ByteMessage = System.Text.Encoding.UTF8.GetBytes("connect/-/");
            NetworkStream Stream = Client.GetStream();

            Stream.Write(ByteMessage, 0, ByteMessage.Length);

            byte[] Response = new Byte[256];
            string ResponseString = string.Empty;

            Int32 BytesReceived = Stream.Read(Response, 0, Response.Length);
            ResponseString = System.Text.Encoding.UTF8.GetString(Response, 0, BytesReceived);
            string[] separatingStrings = { "/-/" };
            string[] HistoriqueMessages = ResponseString.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

            foreach (string Message in HistoriqueMessages)
            {
                AddMessage(Message);
            }
        }
    }
}
