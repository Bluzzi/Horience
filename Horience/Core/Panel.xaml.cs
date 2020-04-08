using Horience.Core.Chat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Windows;
using System.Windows.Controls;

namespace Horience.Core
{
    public partial class Panel : Window
    {
        private readonly Chat.Chat ChatUI;

        private Dictionary<string, string[]> Categories = new Dictionary<string, string[]>();

        public Panel()
        {
            InitializeComponent();

            ChatUI = new Chat.Chat(Chat);

            Categories.Add("WORLD", new string[] { "test", "other test" });
            Categories.Add("COMBAT", new string[] { "test", "other test" });
            Categories.Add("MACRO", new string[] { "test", "other test" });
            Categories.Add("UTILITY", new string[] { "test", "other test" });
            Categories.Add("RENDER", new string[] { "test", "other test" });
            Categories.Add("BLATANT", new string[] { "test", "other test" });

            foreach (var CategoryInfo in Categories)
            {
                Button category = new Button
                {
                    Name = CategoryInfo.Key.ToString(),
                    Content = CategoryInfo.Key.ToString()
                };

                category.Click += OnSelectorClick;

                Selector.Children.Add(category);
            }
        }

        // UI Getters :

        public Chat.Chat GetChat()
        {
            return ChatUI;
        }

        // Cheat or Utils selector :

        private void OnSelectorClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(String.Join(" ", Categories[((Button)sender).Content.ToString()]));
        }

        // Message text box manager :

        private void OnSendClick(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void SendKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.ToString() == System.Windows.Forms.Keys.Enter.ToString()) SendMessage();
        }

        private void SendMessage()
        {
            if (TextZone.Text.Length > 0)
            {
                GetChat().SendMessage(TextZone.Text);
                TextZone.Text = "";
            }
        }

        // Animation or other cool things :

        private void ChangeSize(object sender, SizeChangedEventArgs e)
        {
            if (e.PreviousSize == new Size(0, 0)) return;

            Window Sender = (Window)sender;

            if (Sender.Height == e.PreviousSize.Height && Sender.Width == e.PreviousSize.Width)
            {
                Sender.BorderThickness = new Thickness(0);
            } 
            else
            {
                Sender.BorderThickness = new Thickness(1);
            }
        }
    }
}
