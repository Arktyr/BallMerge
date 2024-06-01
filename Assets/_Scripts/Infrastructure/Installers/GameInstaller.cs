using _Scripts.Gameplay.Pool;
using _Scripts.Gameplay.Services;
using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.Infrastructure.Installers
{
    public class GameInstaller : Installer
    {
        [SerializeField] private PendulumService _pendulumService;
        
        public override void InstallBinding()
        {
            BindServices();
        }

        private void BindServices()
        {
            IObjectPool objectPool =
                AllServices.Container.RegisterSingle<IObjectPool>(new ObjectPool());

            IPendulumService pendulumService =
                AllServices.Container.RegisterSingle<IPendulumService>(_pendulumService);
        }
    }
}