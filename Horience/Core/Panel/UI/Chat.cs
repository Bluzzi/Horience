using Horience.Core.Api.Colors;
using Horience.Core.Network.Request;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Horience.Core.Panel.UI
{
    public class Chat
    {
        private StackPanel ChatList;

        public Chat(StackPanel ChatList)
        {
            this.ChatList = ChatList;

            AddMessageHistory();
        }

        /// <summary>
        /// Send a message to the server.
        /// </summary>
        /// <param name="Message"></param>
        public void SendMessage(string Message)
        {
            (new Request(RequestType.SEND_MESSAGE, Message)).Send();
        }

        /// <summary>
        /// Update the message list with a array of new messages.
        /// </summary>
        /// <param name="Messages"></param>
        public void UpdateMessageList(string[] Messages)
        {
            foreach (string Message in Messages) AddMessage(Message);
        }

        /// <summary>
        /// Add message in the panel interface.
        /// </summary>
        /// <param name="Message"></param>
        private void AddMessage(string Message)
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

        /// <summary>
        /// Add message history from the server.
        /// </summary>
        private void AddMessageHistory()
        {
            Request Request = new Request(RequestType.CONNECT);

            Response Response = Request.Send();

            if(Response != null)
            {
                foreach (string Message in Response.ToArray())
                {
                    AddMessage(Message);
                }
            }
        }
    }
}