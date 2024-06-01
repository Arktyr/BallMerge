using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace _Scripts.Gameplay.Spawners.Warmup
{
    public class WarmupService : IWarmupService
    {
        private readonly IBallSpawner _ballSpawner;
        
        private readonly List<UniTask> _warmups = new();

        public WarmupService(IBallSpawner ballSpawner)
        {
            _ballSpawner = ballSpawner;
        }

        public async UniTask WarmUp()
        {
            _warmups.Add(_ballSpawner.WarmUp());


            await UniTask.WhenAll(_warmups);
        }
    }
}