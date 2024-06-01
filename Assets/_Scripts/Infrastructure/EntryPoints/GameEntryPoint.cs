using Infrastructure.Game;
using Infrastructure.Installers;
using Infrastructure.Services.Update;
using Infrastructure.Singleton;
using UnityEngine;

namespace Infrastructure.EntryPoints
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