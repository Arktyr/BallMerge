using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Gameplay.Balls
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private Rigidbody2D _rigidbody;

        public float Points { get; private set; }

        public Color CurrentColor { get; private set;}

        public bool IsOnGround => _rigidbody.velocity.magnitude < 0.1f;
        
        public event Action<Ball> OnDestroyed;

        public void Construct(Color color,
            float points)
        {
            _sprite.color = color;
            Points = points;

            CurrentColor = color;
        }

        public void Release()
        {
            _rigidbody.simulated = true;
        }


        public void Destroy()
        {
            _rigidbody.simulated = false;
            OnDestroyed?.Invoke(this);
        }
    }
}