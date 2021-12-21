using System;
using Asteroids;
using UnityEngine;

namespace ScriptableEvents.GameEvents
{
    [CreateAssetMenu]
    public class GameEventAsteroidFragment : ScriptableObject
    {
        
        private event Action<AsteroidFragments> _event;

        public void Raise(AsteroidFragments value)
        {
            _event?.Invoke(value);
        }

        private void Invoke()
        {
            throw new NotImplementedException();
        }

        public void Register(Action<AsteroidFragments> onEvent)
        {
            _event += onEvent;
        }
           
        public void UnRegister(Action<AsteroidFragments> onEvent)
        {
            _event -= onEvent;
        }
    }
}