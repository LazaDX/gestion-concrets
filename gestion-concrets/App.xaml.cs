using System.Windows;
using gestion_concrets.Services;

namespace gestion_concrets
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DatabaseService.InitializeTableDatabase();
        }
    }
}
