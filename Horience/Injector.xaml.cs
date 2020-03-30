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

            // Check if a checkbox is checked and create Main instance with the mode :
            if (CheatBoxIsChecked && UtilsBoxIsChecked)
            {
                new Main((int) Main.MODES.ALL);
            }
            else if (CheatBoxIsChecked)
            {
                new Main((int) Main.MODES.CHEAT);
            }
            else if (UtilsBoxIsChecked)
            {
                new Main((int) Main.MODES.UTILS);
            }
            else
            {
                ErrorLabel.Content = "Select a category !";
                return;
            }
            
            // Close this window :
            Close();
        }
    }
}
