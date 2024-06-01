using _Scripts.Gameplay.Pendulums;
using UnityEngine;

namespace _Scripts.Gameplay.Services
{
    public class PendulumService : MonoBehaviour, IPendulumService
    {
        [SerializeField] private Pendulum _pendulum;
        
        public void StartSpawnBall()
        {
            _pendulum.Initialize();
            _pendulum.SpawnBall();
        }

        public void StopSpawnBall()
        {
            _pendulum.StopSpawnBall();
        }
    }
}