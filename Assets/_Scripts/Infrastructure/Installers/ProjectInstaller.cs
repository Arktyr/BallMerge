using _Scripts.Data.Balls;
using _Scripts.Infrastructure.Input;
using _Scripts.Infrastructure.Installers.Base;
using _Scripts.Infrastructure.Providers.Assets;
using _Scripts.Infrastructure.Providers.Data;
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
            BindProviders();
        }

        private void BindServices()
        {
            IUpdateService updateService = 
                AllServices.Container.RegisterSingle<IUpdateService>(_updateService);

            IInputService inputService = 
                AllServices.Container.RegisterSingle<IInputService>(new InputService());
        }

        private void BindProviders()
        {
            IAssetProvider assetProvider =
                AllServices.Container.RegisterSingle<IAssetProvider>(new AssetProvider());

            IDataProvider dataProvider =
                AllServices.Container.RegisterSingle<IDataProvider>(new DataProvider(_ballData));
        }
    }
}