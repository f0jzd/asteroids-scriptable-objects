using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents
{
    public class GameEventListener : MonoBehaviour
    {

        [SerializeField] private GameEvent _gameEvent;
        [SerializeField] private UnityEvent _response;
        


        private void OnEnable()
        {
            //_gameEvent.Register(this);
            _gameEvent.Register(OnEventRaised);
        }

        private void OnDisable()
        {
            _gameEvent.UnRegister(OnEventRaised);
        }

        public void OnEventRaised()
        {
            _response?.Invoke();//NUll propagation
        }
    }
}