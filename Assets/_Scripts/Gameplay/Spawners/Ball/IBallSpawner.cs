using _Scripts.Infrastructure.Singleton;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Gameplay.Spawners.Ball
{
    public interface IBallSpawner : IService
    {
        UniTask WarmUp();
        Balls.Ball SpawnBall(Vector3 position, Quaternion rotation);
    }
}