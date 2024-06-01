using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Gameplay.Services.Score
{
    public interface IScoreService : IService
    {
        float CurrentScore { get; }
        void AddScore(float points);
        void ResetScore();
    }
}