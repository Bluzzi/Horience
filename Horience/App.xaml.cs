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
                new Main(ModeType.ALL);
            }
            else
            {
                (new Injector()).Show();
            }
        }
    }
}
