using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableEvents.GameEvents
{
    [CreateAssetMenu(fileName = "new Vector3 Event", menuName = "ScriptableObject/Events/VectorEvents", order = 0)]
    public class GameEventVector3 : ScriptableObject
    {
        
            private event Action<Vector3> _event;

            public void Raise(Vector3 value)
            {
                _event?.Invoke(value);
            }

            private void Invoke()
            {
                throw new NotImplementedException();
            }

            public void Register(Action<Vector3> onEvent)
            {
                _event += onEvent;
            }

            
            public void UnRegister(Action<Vector3> onEvent)
            {
                _event -= onEvent;
            }
    }
}