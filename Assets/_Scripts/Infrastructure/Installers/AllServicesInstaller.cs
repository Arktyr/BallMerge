using System.Collections.Generic;

namespace _Scripts.Infrastructure.Installers
{
    public class AllServicesInstaller : Installer
    {
        public List<Installer> Installers;

        public override void InstallBinding()
        {
            BindServices();
        }

        private void BindServices()
        {
            foreach (var installer in Installers) 
                installer.InstallBinding();
        }
    }
}