using System;
using UnityEngine;

namespace _Scripts.Infrastructure.Input
{
    public class InputService : IInputService
    {
        public event Action<Vector3> OnMouseClick;

        private bool _isEnable;
        
        public void Enable() => 
            _isEnable = true;

        public void OnUpdate()
        {
            if (_isEnable == false)
                return;
            
            if (UnityEngine.Input.GetMouseButton(0)) 
                OnMouseClick?.Invoke(UnityEngine.Input.mousePosition);
        }

        public void Disable() => 
            _isEnable = false;
    }
}