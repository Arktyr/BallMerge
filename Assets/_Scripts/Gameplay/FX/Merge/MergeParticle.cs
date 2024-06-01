using System;
using UnityEngine;

namespace _Scripts.Gameplay.FX.Merge
{
    [RequireComponent(typeof(ParticleSystem))]
    public class MergeParticle : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        public event Action<MergeParticle> OnFXEnded;
        
        public void Enable()
        {
            gameObject.SetActive(true);
        }

        private void OnParticleSystemStopped()
        {
            OnFXEnded?.Invoke(this);
            Disable();
        }

        public void Disable() => 
            gameObject.SetActive(false);
    }
}