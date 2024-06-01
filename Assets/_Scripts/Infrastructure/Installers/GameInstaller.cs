using _Scripts.Gameplay.Pool;
using _Scripts.Gameplay.Services;
using _Scripts.Gameplay.Services.Merge;
using _Scripts.Gameplay.Services.Score;
using _Scripts.Infrastructure.Services.Game;
using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.Infrastructure.Installers
{
    public class GameInstaller : Installer
    {
        [SerializeField] private PendulumService _pendulumService;
        [SerializeField] private MergeService _mergeService;
        [SerializeField] private GameService _gameService;
        
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

            IMergeService mergeService =
                AllServices.Container.RegisterSingle<IMergeService>(_mergeService);

            IScoreService scoreService =
                AllServices.Container.RegisterSingle<IScoreService>(new ScoreService());
            
            IGameService gameService =
                AllServices.Container.RegisterSingle<IGameService>(_gameService);
        }
    }
}