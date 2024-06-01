using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.UI.Windows
{
    public class WindowService : IWindowService
    {
        private readonly List<IWindow> _windows = new();

        private IWindow _currentWindow;

        public void AddWindow(IWindow window)
        {
            if (window == null)
                return;
            
            if (_windows.Contains(window))
                return;

            _windows.Add(window);
        }

        public void RemoveWindow(IWindow window)
        {
            if (window == null)
                return;
            
            if (_windows.Contains(window) == false)
                return;

            _windows.Remove(window);
        }

        public void Open<TWindow>() where TWindow : IWindow
        {
            IWindow window = _windows.Find((window => window is TWindow));

            if (window == null)
            {
                Debug.LogError($"{typeof(TWindow)} : This Window Not Found");
                return;
            }

            _currentWindow?.Close();

            if (_currentWindow == window)
            {
                _currentWindow = null;
                return;
            }
            
            window.Open();
            _currentWindow = window;
        }

        public void Close()
        {
            _currentWindow?.Close();
            _currentWindow = null;
        }
    }
}