using _Scripts.Infrastructure.Singleton;
using Cysharp.Threading.Tasks;

namespace _Scripts.Gameplay.Spawners.Warmup
{
    public interface IWarmupService : IService
    {
        UniTask WarmUp();
    }
}