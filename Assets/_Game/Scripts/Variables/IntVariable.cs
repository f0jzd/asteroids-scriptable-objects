﻿using System;
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

        public void ApplyChange(int change)
        {
            _currentValue += change;
        }

        private void OnEnable()
        {
            _currentValue = _value;
        }
    }
}