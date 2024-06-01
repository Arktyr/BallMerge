using _Scripts.Gameplay.Pool;
using _Scripts.Gameplay.Spawners;
using _Scripts.Gameplay.Spawners.Ball;
using _Scripts.Gameplay.Spawners.FX;
using _Scripts.Gameplay.Spawners.Warmup;
using _Scripts.Infrastructure.Installers.Base;
using _Scripts.Infrastructure.Providers;
using _Scripts.Infrastructure.Providers.Assets;
using _Scripts.Infrastructure.Providers.Data;
using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Infrastructure.Installers
{
    public class SpawnersInstaller : Installer
    {
        public override void InstallBinding()
        {
            BindSpawners();
        }

        private void BindSpawners()
        {
            IAssetProvider assetProvider = AllServices.Container.GetSingle<IAssetProvider>();
            IDataProvider dataProvider = AllServices.Container.GetSingle<IDataProvider>();
            IObjectPool objectPool = AllServices.Container.GetSingle<IObjectPool>();

            IBallSpawner ballSpawner =
                AllServices.Container
                    .RegisterSingle<IBallSpawner>(new BallSpawner(assetProvider, dataProvider, objectPool));

            IParticleSpawner particleSpawner =
                AllServices.Container
                    .RegisterSingle<IParticleSpawner>(new ParticleSpawner(objectPool, assetProvider));


            IWarmupService warmupService =
                AllServices.Container
                    .RegisterSingle<IWarmupService>(new WarmupService(ballSpawner, particleSpawner));
        }
    }
}