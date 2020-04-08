using Horience.Core.Api.Colors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Horience.Core.UI
{
    class Chat
    {
        private StackPanel ChatList;

        public Chat(StackPanel ChatList)
        {
            this.ChatList = ChatList;
        }

        public void AddMessage(string SenderName, string Message)
        {
            Label MessageLabel = new Label()
            {
                Content = SenderName + " : " + Message,
                Margin = new Thickness(25, 0, 0, 0),
                FontSize = 20,
                Foreground = new SolidColorBrush(ColorConstants.WHITE)
            };

            ChatList.Children.Add(MessageLabel);
        }
    }
}
