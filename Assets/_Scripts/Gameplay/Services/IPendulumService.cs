using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Gameplay.Services
{
    public interface IPendulumService : IService
    {
        void StartSpawnBall();
        void StopSpawnBall();
    }
}