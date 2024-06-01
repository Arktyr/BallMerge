using _Scripts.Gameplay.Balls;
using _Scripts.Infrastructure.Singleton;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Gameplay.Spawners
{
    public interface IBallSpawner : IService
    {
        UniTask WarmUp();
        Ball SpawnBall(Vector3 position, Quaternion rotation);
    }
}