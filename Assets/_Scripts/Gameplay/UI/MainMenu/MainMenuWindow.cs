using _Scripts.Infrastructure.Installers;
using _Scripts.Infrastructure.Services.Game;
using _Scripts.Infrastructure.Singleton;
using _Scripts.UI.Windows;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace _Scripts.Gameplay.UI.MainMenu
{
    public class MainMenuWindow : Injectable, IWindow
    {
        [SerializeField] private WindowView _windowView;
        [SerializeField] private Button _button;
        
        private IGameService _gameService;

        public override void Inject()
        {
            _gameService = AllServices.Container.GetSingle<IGameService>();
        }

        public async void Open()
        {
            gameObject.SetActive(true);
            _button.enabled = true;
            
            await _windowView.StartFadeIn();
        }

        public void StartGame()
        {
            _button.enabled = false;
            
            _windowView.StopAnimation();
            _gameService.StartGame();
        }

        public async void Close()
        {
            await _windowView.StartFadeOut();

            gameObject.SetActive(false);
        }
    }
}