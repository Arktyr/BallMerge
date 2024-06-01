using _Scripts.Infrastructure.Services.Game;
using _Scripts.Infrastructure.Services.Update;
using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.Infrastructure.Installers
{
    public class ProjectInstaller : Installer
    {
        [SerializeField] private UpdateService _updateService;
        
        public override void InstallBinding()
        {
            BindServices();
        }

        private void BindServices()
        {
            IUpdateService updateService = 
                AllServices.Container.RegisterSingle<IUpdateService>(_updateService);
            
            IGameService gameService =
                AllServices.Container.RegisterSingle<IGameService>(new GameService(updateService));
        }
    }
}