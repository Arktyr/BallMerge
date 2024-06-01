using _Scripts.Gameplay.Pool;
using _Scripts.Infrastructure.Input;
using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Infrastructure.Installers
{
    public class GameInstaller : Installer
    {
        public override void InstallBinding()
        {
            BindServices();
        }

        private void BindServices()
        {
            IInputService inputService = 
                AllServices.Container.RegisterSingle<IInputService>(new InputService());

            IObjectPool objectPool =
                AllServices.Container.RegisterSingle<IObjectPool>(new ObjectPool());
        }
    }
}