using _Scripts.Infrastructure.Services.Update;
using UnityEngine;

namespace _Scripts.Infrastructure.Services.Game
{
    public class GameService : IGameService
    {
        private readonly IUpdateService _updatableService;

        public GameService(IUpdateService updateService)
        {
            _updatableService = updateService;
        }

        public void StartGame()
        {
            _updatableService.Enable();
            Debug.LogError("Start Game");
        }

        public void ResumeGame()
        {
            _updatableService.Disable();
            Debug.LogError("Resume Game");
        }

        public void StopGame()
        {
            _updatableService.Disable();
            Debug.LogError("Stop Game");
        }

        public void EndGame()
        {
            _updatableService.Disable();
            Debug.LogError("End Game");
        }

        private void OnApplicationQuit() => 
            EndGame();

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                StopGame();
                return;
            }
            
            ResumeGame();
        }
    }
}