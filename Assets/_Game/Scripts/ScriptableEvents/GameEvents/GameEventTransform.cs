using System;
using UnityEngine;

namespace ScriptableEvents.GameEvents
{
    [CreateAssetMenu]
    public class GameEventTransform : ScriptableObject
    {
        
        private event Action<Transform> _event;

        public void Raise(Transform value)
        {
            _event?.Invoke(value);
        }

        private void Invoke()
        {
            throw new NotImplementedException();
        }

        public void Register(Action<Transform> onEvent)
        {
            _event += onEvent;
        }
           
        public void UnRegister(Action<Transform> onEvent)
        {
            _event -= onEvent;
        }
    }
}