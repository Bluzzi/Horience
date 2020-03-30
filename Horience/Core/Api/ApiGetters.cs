using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horience.Core.Api
{
    class ApiGetters
    {
        private bool build = false; 

        /// Get the current Version of Horience
        public static float getVersion()
        {
            return 0.1F;
        }

        public bool isDevelopmentBuild()
        {
            if(build == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
