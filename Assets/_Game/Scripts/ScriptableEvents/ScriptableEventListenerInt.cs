using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents
{
    public class ScriptableEventListenerInt : ScriptableEventListener<int, ScriptableEventInt,UnityEvent<int>>
    {
        //[SerializeField] private ScriptableEventInt _event;
        //[SerializeField] private UnityEvent<int> _response;//Only supports some types, but is extentidble
        
        
    }

    public class UnityEventInt : UnityEvent<int>
    {
        
    }
}