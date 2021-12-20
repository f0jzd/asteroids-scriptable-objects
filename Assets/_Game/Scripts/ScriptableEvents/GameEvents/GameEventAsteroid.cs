using System;
using Asteroids;
using UnityEngine;

namespace ScriptableEvents.GameEvents
{
    [CreateAssetMenu(fileName = "new GameEventAsteroid", menuName = "ScriptableObject/Events/GameEventAsteroid", order = 0)]

    public class GameEventAsteroid : ScriptableObject
    {
        
        private event Action<Asteroid> _event;

        public void Raise(Asteroid value)
        {
            _event?.Invoke(value);
        }

        private void Invoke()
        {
            throw new NotImplementedException();
        }

        public void Register(Action<Asteroid> onEvent)
        {
            _event += onEvent;
        }
           
        public void UnRegister(Action<Asteroid> onEvent)
        {
            _event -= onEvent;
        }
    }
}