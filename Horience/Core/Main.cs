using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horience.Core
{
    class Main
    {
        enum MODE
        {
            CHEAT = 0,
            UTILS = 1,
            ALL = 2,
        }

        public const int MODE_CHEAT = 0;
        public const int MODE_UTILS = 1;
        public const int MODE_ALL = 2;

        private static Main Instance;

        private int Mode;

        public Main(int Mode)
        {
            if(new List<int>().Exists(Mode, element => element == "d"))

            if (Main.Instance == null)
            {
                // Save instance and application mode :
                Instance = this;
                this.Mode = Mode;

                // Open the panel :
                (new Panel()).Show();
            }
            else
            {
                throw new Exception("Main class can't have mutliple instances");
            }
        }

        public static Main getInstance()
        {
            return Instance;
        }

        public int getMode()
        {
            return Mode;
        }
    }
}
