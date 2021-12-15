using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents
{
    public class ScriptableEventListener : MonoBehaviour
    {
        [SerializeField] private ScriptableEvent _eventNoPayload;
        [SerializeField] private UnityEvent _responseNoPayload;
        
        
        private void OnEventRaised()//This is the event that will happen
        {
            _responseNoPayload.Invoke();
        }
        
        
        private void OnEnable()
        {
            _eventNoPayload.Register(OnEventRaised);
        }

        private void OnDisable()
        {
            _eventNoPayload.UnRegister(OnEventRaised);//IMPORTANT!!!
        }
    }

    public class ScriptableEventListener<TPayload,TEvent,TUnityEventResponse> : ScriptableEventListener
        where TEvent : ScriptableEvent<TPayload>
        where TUnityEventResponse : UnityEvent<TPayload>
    {
        [SerializeField] private TEvent _event;
        [SerializeField] private TUnityEventResponse _response;
        
        private void OnEventRaised(TPayload payload)//This is the event that will happen
        {
            _response.Invoke(payload);
        }
        
        
        private void OnEnable()
        {
            _event.Register(OnEventRaised);
        }

        private void OnDisable()
        {
            _event.UnRegister(OnEventRaised);//IMPORTANT!!!
        }
        
    }
}