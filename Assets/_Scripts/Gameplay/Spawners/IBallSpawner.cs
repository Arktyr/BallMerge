using _Scripts.Infrastructure.Singleton;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Gameplay.Spawners
{
    public interface IBallSpawner : IService
    {
        UniTask WarmUp();
        void SpawnBall(Vector3 position, Quaternion rotation);
    }
}