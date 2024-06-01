using _Scripts.Gameplay.Services;
using _Scripts.Gameplay.Services.Merge;
using _Scripts.Gameplay.Spawners;
using _Scripts.Gameplay.Spawners.Warmup;
using _Scripts.Infrastructure.Input;
using _Scripts.Infrastructure.Installers;
using _Scripts.Infrastructure.Services.Game;
using _Scripts.Infrastructure.Services.Update;
using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.Infrastructure.EntryPoints
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private Installer Installer;
        
        private IGameService _gameService;
        private IUpdateService _updateService;
        private IWarmupService _warmupService;
        private IInputService _inputService;
        
        private IPendulumService _pendulumService;
        private IMergeService _mergeService;
        
        private void Awake()
        {
            Installer.InstallBinding();
            
            _gameService = AllServices.Container.GetSingle<IGameService>();
            _updateService = AllServices.Container.GetSingle<IUpdateService>();
            _warmupService = AllServices.Container.GetSingle<IWarmupService>();
            _inputService = AllServices.Container.GetSingle<IInputService>();
            _mergeService = AllServices.Container.GetSingle<IMergeService>();

            _pendulumService = AllServices.Container.GetSingle<IPendulumService>();
        }

        private async void Start()
        {
            await _warmupService.WarmUp();
            
            _updateService.AddUpdatable(_inputService);
            
            _pendulumService.StartSpawnBall();
            _mergeService.Initialize();
            
            _gameService.StartGame();
        }
    }
}