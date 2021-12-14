using System;
using UnityEngine;
using UnityEngine.Events;
using Variables;

namespace ScriptableEvents
{
    public class ScriptableEventListenerIntReference : ScriptableEventListener<IntReference, ScriptableEventIntReference,UnityEvent<IntReference>>
    {
        //[SerializeField] private ScriptableEventInt _event;
        //[SerializeField] private UnityEvent<int> _response;//Only supports some types, but is extentidble
        
        
    }
    
    [Serializable]

    public class UnityEventInt : UnityEvent<int>
    {
        
    }
}