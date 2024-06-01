using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Gameplay.UI.MainMenu
{
    public class WindowView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Ease _ease;
        [SerializeField] private float _duration;

        private Tween _tween;
        
        public async UniTask StartFadeIn()
        {
            _tween = _canvasGroup
                .DOFade(1, _duration)
                .SetEase(_ease);

            
            await _tween.ToUniTask();

        }
        
        public async UniTask StartFadeOut()
        {
            _tween = _canvasGroup
                .DOFade(0, _duration)
                .SetEase(_ease);
            
            await _tween.ToUniTask();
        }

        public void StopAnimation() => 
            _tween?.Kill();
    }
}