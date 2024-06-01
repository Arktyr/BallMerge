using UnityEngine;

namespace _Scripts.Gameplay.Services.Pendulum
{
    public class PendulumService : MonoBehaviour, IPendulumService
    {
        [SerializeField] private Pendulums.Pendulum _pendulum;
        
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