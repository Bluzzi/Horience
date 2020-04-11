using System.Diagnostics;
using System.Media;
using System.Windows;
using System.Windows.Media;
using Horience.Core;
using Horience.Core.Api.Colors;
using TimerSystem = System.Timers.Timer;

namespace Horience
{
    public partial class Injector : Window
    {
        public Injector()
        {
            InitializeComponent();
        }

        // Button for enable or disable cheat and utils mode :

        private bool Cheat = false;
        private bool Utils = false;

        private void ButtonCheat(object sender, RoutedEventArgs e)
        {
            if (TimerElapsed < 1)
            {
                Cheat = !Cheat;
                CheatButton.Background = Cheat ? new SolidColorBrush(ColorConstants.GREEN) : new SolidColorBrush(ColorConstants.RED);
            }
        }

        private void ButtonUtils(object sender, RoutedEventArgs e)
        {
            if(TimerElapsed < 1)
            {
                Utils = !Utils;
                UtilsButton.Background = Utils ? new SolidColorBrush(ColorConstants.GREEN) : new SolidColorBrush(ColorConstants.RED);
            }
        }

        // Inject the cheat, this close injector window and open the panel with specified mode :

        private void Inject(object sender, RoutedEventArgs e)
        {
            // Check if no mode selected :
            if (!Cheat && !Utils)
            {
                DisplayError("You must select a mode");
                return;
            }

            if (Process.GetProcessesByName("Minecraft.Windows").Length == 0)
            {
                DisplayError("You must launch Minecraft");
                return;
            }

            InjectButton.Visibility = Visibility.Hidden;

            // Call loadPanel method with mode selected :
            if (Cheat && Utils)
            {
                StartLoadingPanel(ModeType.ALL);
            }
            else if (Cheat)
            {
                StartLoadingPanel(ModeType.CHEAT);
            }
            else if (Utils)
            {
                StartLoadingPanel(ModeType.UTILS);
            }
        }

        // Panel loader :

        private readonly TimerSystem Timer = new TimerSystem();
        private int TimerElapsed = 0;

        private ModeType Mode;

        private void StartLoadingPanel(ModeType Mode)
        {
            this.Mode = Mode;

            Timer.Interval = 20;
            Timer.Elapsed += LoadingPanel;
            Timer.AutoReset = true;

            Timer.Start();
        }

        private void LoadingPanel(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (TimerElapsed > 100)
            {
                Timer.Stop();

                Dispatcher.Invoke(() => {
                    // Close this window and open the panel :
                    new Main(Mode);

                    Close();
                });
            }
            else
            {
                Dispatcher.Invoke(() => {
                    InjectProgressBar.Value += 0.1;
                });

                TimerElapsed++;
            }
        }

        // Error message :

        private readonly TimerSystem ErrorTimer = new TimerSystem();

        private void DisplayError(string ErrorMessage)
        {
            // Set error message :
            Error.Content = ErrorMessage;

            // Play window error sound :
            SystemSounds.Beep.Play();

            // Start delayed timer for hide error :
            ErrorTimer.Interval = 1000 * 5;
            ErrorTimer.Elapsed += HideError;
            ErrorTimer.AutoReset = false;

            ErrorTimer.Start();
        }

        private void HideError(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                Error.Content = "";
            });

            ErrorTimer.Stop();
        }
    }
}
