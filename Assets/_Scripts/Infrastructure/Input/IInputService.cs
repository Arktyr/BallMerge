using System;
using _Scripts.Infrastructure.Services.Update.Updates;
using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.Infrastructure.Input
{
    public interface IInputService : IUpdatable, IService
    {
        event Action<Vector3> OnMouseClick;
        void Enable();
        void Disable();
    }
}