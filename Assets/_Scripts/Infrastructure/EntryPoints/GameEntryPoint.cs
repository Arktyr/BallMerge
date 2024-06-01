using _Scripts.Gameplay.Services;
using _Scripts.Gameplay.Services.Merge;
using _Scripts.Gameplay.Services.Pendulum;
using _Scripts.Gameplay.Spawners;
using _Scripts.Gameplay.Spawners.Warmup;
using _Scripts.Gameplay.UI.MainMenu;
using _Scripts.Infrastructure.Input;
using _Scripts.Infrastructure.Installers;
using _Scripts.Infrastructure.Installers.Base;
using _Scripts.Infrastructure.Services.Game;
using _Scripts.Infrastructure.Services.Update;
using _Scripts.Infrastructure.Singleton;
using _Scripts.UI.Windows;
using UnityEngine;

namespace _Scripts.Infrastructure.EntryPoints
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private Installer Installer;
        
        private IUpdateService _updateService;
        private IWarmupService _warmupService;
        private IInputService _inputService;
        
        private IPendulumService _pendulumService;
        private IMergeService _mergeService;

        private IWindowService _windowService;
        
        private void Awake()
        {
            Installer.InstallBinding();
            
            _updateService = AllServices.Container.GetSingle<IUpdateService>();
            _warmupService = AllServices.Container.GetSingle<IWarmupService>();
            _inputService = AllServices.Container.GetSingle<IInputService>();
            _mergeService = AllServices.Container.GetSingle<IMergeService>();

            _pendulumService = AllServices.Container.GetSingle<IPendulumService>();
            _windowService = AllServices.Container.GetSingle<IWindowService>();
        }

        private async void Start()
        {
            await _warmupService.WarmUp();
            
            _updateService.AddUpdatable(_inputService);
            
            _pendulumService.StartSpawnBall();
            _mergeService.Initialize();

            _windowService.Open<MainMenuWindow>();
        }
    }
}