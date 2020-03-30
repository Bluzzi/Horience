using System.Diagnostics;
using System.Windows;
using Horience.Core;

namespace Horience
{
    public partial class Injector : Window
    {
        public Injector()
        {
            InitializeComponent();
        }

        // Inject the cheat, this close injector window and open the panel with specified mode :

        private void Inject(object sender, RoutedEventArgs e)
        {
            // Get checkbox values :
            bool CheatBoxIsChecked = CheatCheckBox.IsChecked ?? false;
            bool UtilsBoxIsChecked = UtilsCheckBox.IsChecked ?? false;

            // Create Main instance with the mode :
            if (CheatBoxIsChecked && UtilsBoxIsChecked)
            {
                new Main(Main.MODE_ALL);
            } 
            else if (CheatBoxIsChecked)
            {
                new Main(Main.MODE_CHEAT);
            }
            else
            {
                new Main(Main.MODE_UTILS);
            }

            // Close this window :
            Close();
        }
    }
}
