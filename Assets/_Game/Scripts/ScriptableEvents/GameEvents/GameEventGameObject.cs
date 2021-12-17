using System;
using UnityEngine;

namespace ScriptableEvents.GameEvents
{
    
    [CreateAssetMenu]
    public class GameEventGameObject : ScriptableObject
    {
        private event Action<GameObject> _event;

        public void Raise(GameObject value)
        {
            _event?.Invoke(value);
        }

        private void Invoke()
        {
            throw new NotImplementedException();
        }

        public void Register(Action<GameObject> onEvent)
        {
            _event += onEvent;
        }

            
        public void UnRegister(Action<GameObject> onEvent)
        {
            _event -= onEvent;
        }
    }
}