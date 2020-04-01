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
    }
}
