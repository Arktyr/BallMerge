using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Gameplay.Balls
{
    [RequireComponent(typeof(Collider2D))]
    public class BallTrigger : MonoBehaviour
    {
        public event Action<Ball> OnBallLanded;

        private async void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Ball ball))
            {
                await UniTask.WaitUntil((() => ball.IsOnGround));
                OnBallLanded?.Invoke(ball);
            }
        }
    }
}