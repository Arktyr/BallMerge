using _Scripts.Gameplay.UI.EndGameMenu;
using _Scripts.Gameplay.UI.MainMenu;
using _Scripts.Infrastructure.Installers.Base;
using _Scripts.Infrastructure.Singleton;
using _Scripts.UI.Windows;
using UnityEngine;

namespace _Scripts.Infrastructure.Installers
{
    public class WindowInstaller : Installer
    {
        [SerializeField] private MainMenuWindow _mainMenuWindow;
        [SerializeField] private EndGameWindow _endGameWindow;
        
        public override void InstallBinding()
        {
            BindWindows();
        }

        private void BindWindows()
        {
            IWindowService windowService = AllServices.Container.GetSingle<IWindowService>();
            
            windowService.AddWindow(_mainMenuWindow);
            windowService.AddWindow(_endGameWindow);
        }
    }
}