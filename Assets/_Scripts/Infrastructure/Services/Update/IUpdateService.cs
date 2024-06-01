using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Infrastructure.Services.Update
{
    public interface IUpdateService : IService
    {
        void Enable();
        void Disable();
        void AddUpdatable<TUpdate>(TUpdate update);
        void RemoveUpdatable<TUpdate>(TUpdate update);
    }
}