using System;
using UnityEngine;


namespace Variables
{
    
    
    [Serializable]
    public class IntReference
    {
        
        //todo can we make this look nicer with a custom property drawer?
        [SerializeField] private IntVariable _intVariable;
        [SerializeField] private int _simpleValue;
        [SerializeField] private bool _useSimple;

        //[SerializeField] private ScriptableEventInt _onChangedEvent;

        public IntReference(IntVariable variable)
        {
            _intVariable = variable;
            _useSimple = false;
        }
        public IntReference(int value)
        {
            _simpleValue = value;
            _useSimple = true;
        }

        public int GetValue()
        {
            return _useSimple ? _simpleValue : _intVariable.Value;
        }

        public void ApplyChange(int change)
        {
            if (_useSimple)
            {
                _simpleValue += change;
            }
            else
            {
                _intVariable.ApplyChange(change);
            }
        }
    }
}