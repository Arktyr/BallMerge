using _Scripts.Gameplay.Pendulums;
using _Scripts.Gameplay.Services.Merge;
using _Scripts.Gameplay.Services.Score;
using _Scripts.Gameplay.UI.EndGameMenu;
using _Scripts.Infrastructure.Input;
using _Scripts.Infrastructure.Installers;
using _Scripts.Infrastructure.Installers.Base;
using _Scripts.Infrastructure.Services.Update;
using _Scripts.Infrastructure.Singleton;
using _Scripts.UI.Windows;
using UnityEngine;

namespace _Scripts.Infrastructure.Services.Game
{
    public class GameService : Injectable, IGameService
    {
        private IUpdateService _updatableService;
        private IInputService _inputService;
        private IWindowService _windowService;
        private IMergeService _mergeService;
        private IScoreService _scoreService;
        
        public override void Inject()
        {
            _updatableService = AllServices.Container.GetSingle<IUpdateService>();
            _inputService = AllServices.Container.GetSingle<IInputService>();
            _windowService = AllServices.Container.GetSingle<IWindowService>();
            _mergeService = AllServices.Container.GetSingle<IMergeService>();
            _scoreService = AllServices.Container.GetSingle<IScoreService>();
        }

        public void StartGame()
        {
            _mergeService.ClearCells();
            _scoreService.ResetScore();
            
            _inputService.Enable();
            _updatableService.Enable();
            
            _windowService.Close();
            Debug.LogError("Start Game");
        }

        public void ResumeGame()
        {
            _inputService.Enable();
            _updatableService.Enable();
            Debug.LogError("Resume Game");
        }

        public void StopGame()
        {
            _inputService.Disable();
            _updatableService.Disable();
            Debug.LogError("Stop Game");
        }
        
        public void EndGame()
        {
            _inputService.Disable();
            _updatableService.Disable();
            Debug.LogError("End Game");
            _windowService.Open<EndGameWindow>();
        }

        private void OnApplicationQuit() => 
            EndGame();
    }
}