﻿using UnityEngine;

namespace DefaultNamespace
{
    public class MyMono : MonoBehaviour
    {
        [SerializeField] private FloatRef _myNewName;

        //[SerializeField] private TextMeshProUGUI _text;

        public void Update()
        {
            //_text.text = _myFloatRef.Value.ToString();
        }
    }
}