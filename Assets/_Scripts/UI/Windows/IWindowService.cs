using Infrastructure.Singleton;

namespace _Scripts.UI.Windows
{
    public interface IWindowService : IService
    {
        void AddWindow(IWindow window);
        void RemoveWindow(IWindow window);
        void Open<TWindow>() where TWindow : IWindow;
        void Close();
    }
}