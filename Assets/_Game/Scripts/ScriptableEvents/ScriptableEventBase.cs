using System;
using TMPro;
using UnityEngine;

namespace ScriptableEvents
{
    [CreateAssetMenu(fileName = "new ScriptableEvent", menuName = "ScriptableObject/ScriptableEvent", order = 0)]
    public abstract class ScriptableEventBase : ScriptableObject
    {
    
        
        private event Action _eventNoPayload;

        //private event Action<int> _eventWithInt;

        public void Register(Action onEventNoPayload)//What happens when the event is raised`?
        {
            _eventNoPayload += onEventNoPayload;
        }
        public void UnRegister(Action onEventNoPayload)//What happens when the event is raised`?
        {
            _eventNoPayload -= onEventNoPayload;
        }

        public void Raise()
        {
            _eventNoPayload?.Invoke();//If the event is not null we can invoke, else it will not
        }
    }

    [CreateAssetMenu(fileName = "new ScriptableEvent", menuName = "ScriptableObject/ScriptableEvent", order = 0)]
    public class ScriptableEvent : ScriptableEventBase
    {
    }

    public abstract class ScriptableEvent<TPayload> : ScriptableEventBase
    {
        
        private event Action<TPayload> _event;
        
        public void Register(Action<TPayload> onEventNoPayload)//What happens when the event is raised`?
        {
            _event += onEventNoPayload;
        }
        public void UnRegister(Action<TPayload> onEventNoPayload)//What happens when the event is raised`?
        {
            _event -= onEventNoPayload;
        }
        
        public void Raise(TPayload newValue)
        {
            _event?.Invoke(newValue);//If the event is not null we can invoke, else it will not
        }
        
        
    }
}