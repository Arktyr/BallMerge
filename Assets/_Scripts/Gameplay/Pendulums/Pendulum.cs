using System.Collections.Generic;
using _Scripts.Gameplay.Animations.Pendulum;
using _Scripts.Gameplay.Balls;
using _Scripts.Gameplay.Spawners.Ball;
using _Scripts.Infrastructure.Input;
using _Scripts.Infrastructure.Installers.Base;
using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.Gameplay.Pendulums
{
    public class Pendulum : Injectable
    {
        [SerializeField] private Transform _rootToSpawnBall;
        [SerializeField] private PendulumAnimation _pendulumAnimation;

        [SerializeField] private List<BallTrigger> _ballTriggers;

        private IBallSpawner _ballSpawner;
        private IInputService _inputService;
        
        private Ball _currentBall;
        
        public override void Inject()
        {
            _ballSpawner = AllServices.Container.GetSingle<IBallSpawner>();
            _inputService = AllServices.Container.GetSingle<IInputService>();
        }

        public void Initialize()
        {
            _pendulumAnimation.StartAnimation();
            
            _inputService.OnMouseClick += ReleaseBall;

            foreach (var ballTrigger in _ballTriggers) 
                ballTrigger.OnBallLanded += OnBallLanded;
        }

        public void SpawnBall()
        {
            Ball ball = _ballSpawner.SpawnBall(_rootToSpawnBall.position, _rootToSpawnBall.rotation);
            ball.transform.SetParent(_rootToSpawnBall);
            
            _currentBall = ball;
        }

        public void StopSpawnBall()
        {
            _pendulumAnimation.StopAnimation();
            
            _inputService.OnMouseClick -= ReleaseBall;
            
            _currentBall = null;
        }

        private void OnBallLanded(Ball ball)
        {
            _currentBall = null;
            SpawnBall();
        }

        private void ReleaseBall(Vector3 position)
        {
            if (_currentBall == null)
                return;
            
            _currentBall.transform.SetParent(null);
            _currentBall.Release();
        }

        private void OnDestroy()
        {
            _inputService.OnMouseClick -= ReleaseBall;

            foreach (var ballTrigger in _ballTriggers) 
                ballTrigger.OnBallLanded -= OnBallLanded;
        }
    }
}