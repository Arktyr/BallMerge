using System.Collections.Generic;
using _Scripts.Gameplay.Spawners.FX;
using Cysharp.Threading.Tasks;

namespace _Scripts.Gameplay.Spawners.Warmup
{
    public class WarmupService : IWarmupService
    {
        private readonly IBallSpawner _ballSpawner;
        private readonly IParticleSpawner _particleSpawner;
        
        private readonly List<UniTask> _warmups = new();

        public WarmupService(IBallSpawner ballSpawner,
            IParticleSpawner particleSpawner)
        {
            _ballSpawner = ballSpawner;
            _particleSpawner = particleSpawner;
        }

        public async UniTask WarmUp()
        {
            _warmups.Add(_ballSpawner.WarmUp());
            _warmups.Add(_particleSpawner.WarmUp());

            await UniTask.WhenAll(_warmups);
        }
    }
}