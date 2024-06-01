using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Gameplay.Services.Merge
{
    public interface IMergeService : IService
    {
        void Initialize();
        void ClearCells();
    }
}