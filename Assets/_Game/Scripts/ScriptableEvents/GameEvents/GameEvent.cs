using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace ScriptableEvents
{
    [CreateAssetMenu(fileName = "new GameEvent", menuName = "ScriptableObject/Events/GameEvent", order = 0)]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> _listeners = new List<GameEventListener>();
        private event Action _event;

        public void Raise()
        {
            for (var i = _listeners.Count -1 ; i >= 0; i--)
            {
                _listeners[i].OnEventRaised();
            }
            _event?.Invoke();
        }

        private void Invoke()
        {
            throw new NotImplementedException();
        }


        public void Register(GameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void Register(Action onEvent)
        {
            _event += onEvent;
        }

        public void UnRegister(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }
        public void UnRegister(Action onEvent)
        {
            _event -= onEvent;
        }
        
        
    }
}