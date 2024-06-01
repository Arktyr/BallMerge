using System.Collections.Generic;
using _Scripts.Infrastructure.Services.Update.Updates;
using UnityEngine;

namespace _Scripts.Infrastructure.Services.Update
{
    public class UpdateService : MonoBehaviour, IUpdateService
    {
        private readonly List<IUpdatable> _updatables = new();
        private readonly List<IFixedUpdatable> _fixedUpdatables = new();
        private readonly List<ILateUpdatable> _lateUpdatables = new();
            
        private bool IsStopped = true;

        public void Enable() => 
            IsStopped = false;

        public void AddUpdatable<TUpdate>(TUpdate update)
        {
            if (update == null)
                return;

            if (update is IFixedUpdatable fixedUpdatable)
            {
                if (_fixedUpdatables.Contains(fixedUpdatable) == false) 
                    _fixedUpdatables.Add(fixedUpdatable);
            }

            if (update is IUpdatable updatable)
            {
                if (_updatables.Contains(updatable) == false)
                    _updatables.Add(updatable);
            }

            if (update is ILateUpdatable lateUpdatable)
            {
                if (_lateUpdatables.Contains(lateUpdatable) == false)
                    _lateUpdatables.Add(lateUpdatable);
            }
        }

        private void Update()
        {
            if (IsStopped)
                return;
            
            foreach (var update in _updatables) 
                update?.OnUpdate();
        }

        private void FixedUpdate()
        {
            if (IsStopped)
                return;

            foreach (var update in _fixedUpdatables)
                update?.FixedUpdate();
        }

        private void LateUpdate()
        {
            if (IsStopped)
                return;
            
            foreach (var update in _lateUpdatables) 
                update?.LateUpdatable();
        }

        public void RemoveUpdatable<TUpdate>(TUpdate update)
        {
            if (update == null)
                return;

            if (update is IFixedUpdatable fixedUpdatable)
            {
                if (_fixedUpdatables.Contains(fixedUpdatable)) 
                    _fixedUpdatables.Remove(fixedUpdatable);
            }

            if (update is IUpdatable updatable)
            {
                if (_updatables.Contains(updatable))
                    _updatables.Remove(updatable);
            }

            if (update is ILateUpdatable lateUpdatable)
            {
                if (_lateUpdatables.Contains(lateUpdatable))
                    _lateUpdatables.Remove(lateUpdatable);
            }
        }

        public void Disable() => 
            IsStopped = true;
    }
}