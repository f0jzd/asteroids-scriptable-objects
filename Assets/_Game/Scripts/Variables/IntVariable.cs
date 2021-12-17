using System;
using UnityEngine;

namespace Variables
{
    
    // Todo can we use generics to avoid duplication?
    [CreateAssetMenu(fileName = "new FloatVariable", menuName = "ScriptableObject/Variables/IntVariable")]
    public class IntVariable : ScriptableObject
    {
    
        [SerializeField] private int _value;

        private int _currentValue;

        public int Value => _currentValue;

        public virtual void ApplyChange(int change)
        {
            _currentValue += change;
        }

        public virtual void SetValue(int newValue)
        {
            _currentValue = newValue;
        }

        private void OnEnable()
        {
            _currentValue = _value;
        }
    }

    /*public class VariableBase<T> : ScriptableObject
    {
        [SerializeField] private int _value;

        private int _currentValue;

        public int Value => _currentValue;

        public virtual void ApplyChange(T change)
        {
            _currentValue += change;
        }

        private void OnEnable()
        {
            _currentValue = _value;
        }
        
    }*/

    /*public class myIntThhingy : VariableBase<int>
    {
        
    }*/
}