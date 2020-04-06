using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Horience.Core
{
    public partial class Panel : Window
    {
        public Panel()
        {
            InitializeComponent();

            for(int tgm = 0; tgm < 25; tgm++)
            {
                Button category = new Button
                {
                    //Name = tgm.ToString(),
                    Content = "Woah " + tgm.ToString()
                };

                category.Name = "hello" + tgm.ToString();
                category.Click += OnClickButton;
                Category.Children.Add(category);
            }
        }

        private void OnClickButton(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = new Random().Next(1, 10).ToString();
        }

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
                Sender.BorderThickness = new Thickness(2);
            }
        }
    }
}
