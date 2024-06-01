using _Scripts.Gameplay.Services.Score;
using _Scripts.Gameplay.UI.MainMenu;
using _Scripts.Infrastructure.Installers;
using _Scripts.Infrastructure.Installers.Base;
using _Scripts.Infrastructure.Services.Game;
using _Scripts.Infrastructure.Singleton;
using _Scripts.UI.Windows;
using TMPro;
using UnityEngine;

namespace _Scripts.Gameplay.UI.EndGameMenu
{
    public class EndGameWindow : Injectable, IWindow
    {
        [SerializeField] private WindowView _windowView;
        [SerializeField] private TMP_Text _score;
        
        private IGameService _gameService;
        private IWindowService _windowService;
        private IScoreService _scoreService;
        
        public override void Inject()
        {
            _gameService = AllServices.Container.GetSingle<IGameService>();
            _windowService = AllServices.Container.GetSingle<IWindowService>();
            _scoreService = AllServices.Container.GetSingle<IScoreService>();
        }

        public async void Open()
        {
            gameObject.SetActive(true);

            _score.text = _scoreService.CurrentScore.ToString();
            
            await _windowView.StartFadeIn();
        }

        public void RestartGame() => 
            _gameService.StartGame();

        public void ReturnToMenu() => 
            _windowService.Open<MainMenuWindow>();

        public async void Close()
        {
            await _windowView.StartFadeOut();
            
            gameObject.SetActive(false);
        }
    }
}