using Infrastructure.Singleton;

namespace Infrastructure.Services.Update
{
    public interface IUpdateService : IService
    {
        void Enable();
        void Disable();
        void AddUpdatable<TUpdate>(TUpdate update);
        void RemoveUpdatable<TUpdate>(TUpdate update);
    }
}