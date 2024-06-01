using _Scripts.Infrastructure.Singleton;

namespace _Scripts.UI.Windows
{
    public interface IWindow : IService
    {
        void Open();
        void Close();
    }
}