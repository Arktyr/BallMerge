using System;
using _Scripts.Gameplay.Balls;
using UnityEngine;

namespace _Scripts.Gameplay.Merge
{
    public class MergeCell : MonoBehaviour
    {
        [SerializeField] private Vector3 _gizmoSize;
        [SerializeField] private Color _gizmoColor;
        
        public Ball CurrentBall { get; private set; }

        public bool IsEmpty => CurrentBall == null;

        public event Action OnBallSetted;

        public void SetBall(Ball ball)
        {
            CurrentBall = ball;
            OnBallSetted?.Invoke();
        }

        public void Clear(bool isDestroyBall)
        {
            Debug.Log(CurrentBall);
            
            if (CurrentBall == null)
                return;
            
            if (isDestroyBall)
                CurrentBall.Destroy();
            
            CurrentBall = null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = _gizmoColor;
            Gizmos.DrawCube(transform.position, _gizmoSize);
        }
    }
}