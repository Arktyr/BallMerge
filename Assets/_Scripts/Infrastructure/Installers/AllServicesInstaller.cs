using System.Collections.Generic;
using _Scripts.Gameplay.Pendulums;

namespace _Scripts.Infrastructure.Installers
{
    public class AllServicesInstaller : Installer
    {
        public List<Installer> Installers;
        public List<Injectable> Injectables;

        public override void InstallBinding()
        {
            BindServices();
            InjectObjects();
        }

        private void InjectObjects()
        {
            foreach (var injectable in Injectables) 
                injectable.Inject();
        }

        private void BindServices()
        {
            foreach (var installer in Installers) 
                installer.InstallBinding();
        }
    }
}