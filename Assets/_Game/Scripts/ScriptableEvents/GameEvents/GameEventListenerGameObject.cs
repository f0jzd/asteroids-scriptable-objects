using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents.GameEvents
{
    public class GameEventListenerGameObject : MonoBehaviour
    {
        [SerializeField] private GameEventGameObject _gameEvent;
        [SerializeField] private UnityEvent<GameObject> _response;
        


        private void OnEnable()
        {
            //_gameEvent.Register(this);
            _gameEvent.Register(OnEventRaised);
        }

        private void OnDisable()
        {
            _gameEvent.UnRegister(OnEventRaised);
        }

        private void OnEventRaised(GameObject value)
        {
            _response?.Invoke(value);//NUll propagation
        }
    }
}