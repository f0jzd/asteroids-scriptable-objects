using Asteroids;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents.GameEvents
{
    public class GameEventListenerAsteroid : MonoBehaviour
    {
        [SerializeField] private GameEventAsteroid _gameEvent;
        [SerializeField] private UnityEvent<Asteroid> _response;
        
        private void OnEnable()
        {
            //_gameEvent.Register(this);
            _gameEvent.Register(OnEventRaised);
        }

        private void OnDisable()
        {
            _gameEvent.UnRegister(OnEventRaised);
        }

        public void OnEventRaised(Asteroid value)
        {
            _response?.Invoke(value);//NUll propagation
        }
    }
}