using _Scripts.Data.Balls;
using _Scripts.Infrastructure.Providers;
using _Scripts.Infrastructure.Services.Game;
using _Scripts.Infrastructure.Services.Providers.Assets;
using _Scripts.Infrastructure.Services.Update;
using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.Infrastructure.Installers
{
    public class ProjectInstaller : Installer
    {
        [SerializeField] private UpdateService _updateService;

        [SerializeField] private BallData _ballData;
        
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

            IAssetProvider assetProvider =
                AllServices.Container.RegisterSingle<IAssetProvider>(new AssetProvider());

            IDataProvider dataProvider =
                AllServices.Container.RegisterSingle<IDataProvider>(new DataProvider(_ballData));
        }
    }
}