using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents.GameEvents
{
    public class GameEventListenerTransform : MonoBehaviour
    {
        [SerializeField] private GameEventTransform _gameEvent;
        [SerializeField] private UnityEvent<Transform> _response;
        


        private void OnEnable()
        {
            //_gameEvent.Register(this);
            _gameEvent.Register(OnEventRaised);
        }

        private void OnDisable()
        {
            _gameEvent.UnRegister(OnEventRaised);
        }

        public void OnEventRaised(Transform value)
        {
            _response?.Invoke(value);//NUll propagation
            
            //Attempt at Define symbol
            /*#if DEBUG
            Debug.Log(value);
            #endif*/
        }
        
    }
}