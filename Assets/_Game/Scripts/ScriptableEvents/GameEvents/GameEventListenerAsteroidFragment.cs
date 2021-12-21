using Asteroids;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents.GameEvents
{
    public class GameEventListenerAsteroidFragment : MonoBehaviour
    {
        [SerializeField] private GameEventAsteroidFragment _gameEvent;
        [SerializeField] private UnityEvent<AsteroidFragments> _response;
        
        private void OnEnable()
        {
            //_gameEvent.Register(this);
            _gameEvent.Register(OnEventRaised);
        }

        private void OnDisable()
        {
            _gameEvent.UnRegister(OnEventRaised);
        }

        public void OnEventRaised(AsteroidFragments value)
        {
            _response?.Invoke(value);//NUll propagation
        }
    }
}