using System.Windows;
using System.Windows.Controls;

namespace Horience.Core
{
    public partial class Panel : Window
    {
        public Panel()
        {
            InitializeComponent();

            for(int tgm = 0; tgm < 10; tgm++)
            {
                Button category = new Button
                {
                    Content = "Woah " + tgm.ToString()
                };

                Category.Children.Add(category);
            }
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
