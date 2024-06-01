using System;
using UnityEngine;

namespace _Scripts.Infrastructure.Game.Balls
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;

        private float _points;

        public event Action<Ball> OnDestroyed;
        
        public void Construct(Color color,
            float points)
        {
            _sprite.color = color;
            _points = points;
        }


        public void Destroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}