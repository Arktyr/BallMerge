using _Scripts.Infrastructure.Singleton;
using _Scripts.UI.Windows;

namespace _Scripts.Infrastructure.Installers
{
    public class UIInstaller : Installer
    {
        public override void InstallBinding()
        {
            BindServices();
        }

        private void BindServices()
        {
            IWindowService windowService = 
                AllServices.Container.RegisterSingle<IWindowService>(new WindowService());
        }
    }
}