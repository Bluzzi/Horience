using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using Horience.Core;

namespace Horience
{
    public partial class Injector : Window
    {
        private System.Timers.Timer _timer = new System.Timers.Timer();
        private int _timerElapsed = 0;
        public static Panel created;

        public Injector()
        {
            InitializeComponent();
        }

        // Inject the cheat, this close injector window and open the panel with specified mode :

        private void Inject(object sender, RoutedEventArgs e)
        {
            //Hide Button:
            InjectButton.Visibility = Visibility.Hidden;
            // Get checkbox values :
            bool CheatBoxIsChecked = CheatCheckBox.IsChecked ?? false;
            bool UtilsBoxIsChecked = UtilsCheckBox.IsChecked ?? false;

            // Minecraft Process
            /**
             *To Edit when dll is implemented in the code
             */
            //VAMemory memory = new VAMemory("Minecraft.Windows");
            // If Process = false = Minecraft Windows not open 
            // Otherwise, if Process = true, it's on.
            //To put back when all good memory.CheckProcess() == false
            if (false)
            {
                ErrorLabel.Content = "You must start Minecraft before.";
                //set the button back since injection failed
                InjectButton.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                // Check if a checkbox is checked and create Main instance with the mode :
                if (CheatBoxIsChecked && UtilsBoxIsChecked)
                {
                    GenerateAnimation();
                    new Main((int)Main.MODES.ALL);
                }
                else if (CheatBoxIsChecked)
                {
                    GenerateAnimation();
                    new Main((int)Main.MODES.CHEAT);
                }
                else if (UtilsBoxIsChecked)
                {
                    GenerateAnimation();
                    new Main((int)Main.MODES.UTILS);
                }
                else
                {
                    ErrorLabel.Content = "Select a category !";
                    //set the button back since injection failed
                    InjectButton.Visibility = Visibility.Visible;
                    return;
                }
            }
        }

        private void GenerateAnimation()
        {
            _timer.Interval = 20;
            _timer.Elapsed += ProgressTick;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void ProgressTick(object sender, System.Timers.ElapsedEventArgs e)
        {
                if (_timerElapsed > 100)
                {
                    _timer.Stop();
                    Dispatcher.Invoke(() => {
                        // Close this window :
                        Close();

                        // Show the panel window
                        created.Show();
                    });
                }
                else
                {
                    Dispatcher.Invoke(() => {
                             InjectProgressBar.Value += 0.1;
                    });
                    _timerElapsed++;
                } 
        }
        private void CheatCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Color color = Color.FromRgb(0, 185, 67);
            CheatLabel.Foreground = new SolidColorBrush(color);
        }

        private void CheatCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Color color = Color.FromRgb(116, 20, 20);
            CheatLabel.Foreground = new SolidColorBrush(color);
        }

    }
}
