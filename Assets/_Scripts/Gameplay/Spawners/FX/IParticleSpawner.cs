using _Scripts.Infrastructure.Singleton;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Gameplay.Spawners.FX
{
    public interface IParticleSpawner : IService
    {
        UniTask WarmUp();
        void SpawnParticle(Vector3 position);
    }
}