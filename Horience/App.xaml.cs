using Horience.Core;
using System.Windows;

namespace Horience
{
    public partial class App : Application
    {
        private void Start(object sender, StartupEventArgs e)
        {
            if (Info.IS_BETA)
            {
                new Main((int)Core.Main.MODES.ALL);
            }
            else
            {
                Injector Window = new Injector();

                Window.Show();
            }
        }
    }
}
