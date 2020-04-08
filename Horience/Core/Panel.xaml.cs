using Horience.Core.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Horience.Core
{
    public partial class Panel : Window
    {
        private Chat ChatUI;

        private Dictionary<string, string[]> Categories = new Dictionary<string, string[]>();

        public Panel()
        {
            InitializeComponent();

            ChatUI = new Chat(Chat);

            Categories.Add("World", new string[] { "test", "other test" });
            Categories.Add("Combat", new string[] { "test", "other test" });
            Categories.Add("Macro", new string[] { "test", "other test" });
            Categories.Add("Utility", new string[] { "test", "other test" });
            Categories.Add("Render", new string[] { "test", "other test" });
            Categories.Add("Blatant", new string[] { "test", "other test" });

            foreach (var CategoryInfo in Categories)
            {
                Button category = new Button
                {
                    Name = CategoryInfo.Key.ToString(),
                    Content = CategoryInfo.Key.ToString()
                };

                category.Click += OnClickButton;

                Category.Children.Add(category);
            }
        }

        private void OnClickButton(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(String.Join(" ", Categories[((Button)sender).Content.ToString()]));
        }

        // UI Getters :

        private Chat GetChat()
        {
            return ChatUI;
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
