using System;
using UnityEngine;

namespace _Scripts.Gameplay.Balls
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private Rigidbody2D _rigidbody;

        private float _points;

        public event Action<Ball> OnDestroyed;
        public event Action<Ball> OnLanded; 

        public void Construct(Color color,
            float points)
        {
            _sprite.color = color;
            _points = points;
        }

        public void Release()
        {
            _rigidbody.simulated = true;
        }


        public void Land() => 
            OnLanded?.Invoke(this);

        public void Destroy()
        {
            _rigidbody.simulated = false;
            OnDestroyed?.Invoke(this);
        }
    }
}