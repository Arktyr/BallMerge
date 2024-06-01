using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Infrastructure.Services.Game
{
    public interface IGameService : IService
    {
        void StartGame();
        void ResumeGame();
        void StopGame();
        void EndGame();
    }
}