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


        private void Awake()
        {
            Installer.InstallBinding();
            
            _gameService = AllServices.Container.GetSingle<GameService>();
            _updateService = AllServices.Container.GetSingle<UpdateService>();
        }

        private async void Start()
        {
            _gameService.StartGame();
        }
    }
}