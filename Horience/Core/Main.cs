using System;
using Horience.Core.Api;

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

        private readonly int Mode;

        public Main(int Mode)
        {
            if (!Enum.IsDefined(typeof(MODES), (object) Mode))
            {
                throw new Exception("Invalid mode, don't use magic number");
            }

            if (Main.Instance == null)
            {
                // Save instance and application mode :
                Instance = this;
                this.Mode = Mode;

                // Open the panel and set the created static variable in Injector:
                (new Panel()).Show();
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

        public ApiGetters GetApi()
        {
            return new ApiGetters();
        }

        public int GetMode()
        {
            return Mode;
        }
    }
}
