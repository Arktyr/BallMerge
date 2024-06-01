using Infrastructure.Singleton;

namespace Infrastructure.Game
{
    public interface IGameService : IService
    {
        void StartGame();
        void ResumeGame();
        void StopGame();
        void EndGame();
    }
}