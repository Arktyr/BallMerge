using _Scripts.Gameplay.Pendulums;
using _Scripts.Infrastructure.Input;
using _Scripts.Infrastructure.Installers;
using _Scripts.Infrastructure.Services.Update;
using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.Infrastructure.Services.Game
{
    public class GameService : Injectable, IGameService
    {
        private IUpdateService _updatableService;
        private IInputService _inputService;

        public override void Inject()
        {
            _updatableService = AllServices.Container.GetSingle<IUpdateService>();
            _inputService = AllServices.Container.GetSingle<IInputService>();
        }

        public void StartGame()
        {
            _inputService.Enable();
            _updatableService.Enable();
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
        }

        private void OnApplicationQuit() => 
            EndGame();

        private void OnApplicationPause(bool pauseStatus)
        {
            if (_inputService == null)
                return;
            
            if (_updatableService == null)
                return;
            
            if (pauseStatus)
            {
                StopGame();
                return;
            }
            
            ResumeGame();
        }
    }
}