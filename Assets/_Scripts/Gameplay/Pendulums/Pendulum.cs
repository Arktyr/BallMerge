using System;
using _Scripts.Gameplay.Animations.Pendulum;
using _Scripts.Gameplay.Balls;
using _Scripts.Gameplay.Spawners;
using _Scripts.Infrastructure.Input;
using _Scripts.Infrastructure.Installers;
using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.Gameplay.Pendulums
{
    public class Pendulum : Injectable
    {
        [SerializeField] private Transform _rootToSpawnBall;
        [SerializeField] private PendulumAnimation _pendulumAnimation;
        
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
        }

        public void SpawnBall()
        {
            Ball ball = _ballSpawner.SpawnBall(_rootToSpawnBall.position, _rootToSpawnBall.rotation);
            ball.transform.SetParent(_rootToSpawnBall);
            
            _currentBall = ball;
            
            _currentBall.OnLanded += OnBallLanded;
        }

        public void StopSpawnBall()
        {
            _pendulumAnimation.StopAnimation();
            
            _inputService.OnMouseClick -= ReleaseBall;

            if (_currentBall != null)
                _currentBall.OnLanded -= OnBallLanded;
            
            _currentBall = null;
        }

        private void OnBallLanded(Ball ball)
        {
            _currentBall.OnLanded -= OnBallLanded;
            SpawnBall();
        }

        private void ReleaseBall(Vector3 position)
        {
            Debug.Log("33");
            
            if (_currentBall == null)
                return;
            
            _currentBall.transform.SetParent(null);
            _currentBall.Release();
            _currentBall = null;
        }
    }
}