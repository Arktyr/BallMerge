using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Gameplay.Services.Pendulum
{
    public interface IPendulumService : IService
    {
        void StartSpawnBall();
        void StopSpawnBall();
    }
}