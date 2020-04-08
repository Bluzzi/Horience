using System;
using System.Diagnostics;
using Horience.Core.Api;
using TimerSystem = System.Timers.Timer;
using System.Windows;
using System.Threading;

namespace Horience.Core
{
    class Main
    {
        public enum MODES
        {
            CHEAT = 0,
            UTILS = 1,
            ALL = 2,
        }

        private static Main Instance;
        private readonly Panel PanelInstance;

        private readonly Client Client = new Client();

        private readonly int Mode;

        private readonly TimerSystem Timer = new TimerSystem();

        public Main(int Mode)
        {
            if (!Enum.IsDefined(typeof(MODES), (object)Mode))
            {
                throw new Exception("Invalid mode, don't use magic number");
            }

            if (Main.Instance == null)
            {
                // Save instance and application mode :
                Instance = this;
                this.Mode = Mode;

                // Open the panel and set the created static variable in Injector:
                PanelInstance = new Panel();
                PanelInstance.Show();

                // Define the genral timer properties :
                Timer.Interval = 50; // 50 * 20 = 1000 (timer is executed every Minecraft tick)
                Timer.Elapsed += Running;
                Timer.AutoReset = true;

                Timer.Start();
            }
            else
            {
                throw new Exception("Main class can't have mutliple instances");
            }
        }

        // Getters :

        public static Main GetInstance()
        {
            return Instance;
        }

        public Panel GetPanel()
        {
            return PanelInstance;
        }

        public ApiGetters GetApi()
        {
            return new ApiGetters();
        }

        public Client GetClient()
        {
            return Client;
        }

        public int GetMode()
        {
            return Mode;
        }

        // Timer method :

        private void Running(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Application.Current == null) return;

            // Check client messages :
            Application.Current.Dispatcher.Invoke(() =>
            {
                //GetPanel().GetChat().CheckNewMessages();
            });

            // Check if Minecraft is running :
            if (Process.GetProcessesByName("Minecraft.Windows").Length == 0)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Process.GetCurrentProcess().Kill();
                });

                return;
            }
        }
    }
}
