using DG.Tweening;
using UnityEngine;

namespace _Scripts.Gameplay.Animations.Pendulum
{
    public class PendulumAnimation : MonoBehaviour
    {
        [SerializeField] private Transform _anchor;
        
        [SerializeField] private Vector3 _rotationOffset;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;

        private Tween _currentTween;
    
        private void Start()
        {
            StartAnimation();
        }

        public void StartAnimation()
        {
            _currentTween = _anchor
                .DOLocalRotate(_rotationOffset, _duration, RotateMode.LocalAxisAdd)
                .SetEase(_ease)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void StopAnimation() => 
            _currentTween?.Kill();
    }
}
