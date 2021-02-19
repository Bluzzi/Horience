using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horience.Core.Panel.UI
{
    class Selector
    {
        private Dictionary<string, string[]> Categories = new Dictionary<string, string[]>();

        public Selector()
        {
            /*
            Organisation des dossiers :
            Core/
                Modules/
                    Module.cs
                    Cheat.cs extends de Module
                    Utils.cs extends de Module
                    Cheat/
                        Xray.cs extends de Cheat
                    Utils/
                        ...

            API Selector : 
            - 

            Module :
            - GetType() -> type cheat ou utils
            - GetCategory() -> retourne la category 
            */
                    
            Categories.Add("WORLD", new string[] { "test", "other test" });
            Categories.Add("COMBAT", new string[] { "test", "other test" });
            Categories.Add("MACRO", new string[] { "test", "other test" });
            Categories.Add("UTILITY", new string[] { "test", "other test" });
            Categories.Add("RENDER", new string[] { "test", "other test" });
            Categories.Add("BLATANT", new string[] { "test", "other test" });
        }
    }
}
