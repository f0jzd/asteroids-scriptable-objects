using System;
using ScriptableEvents.GameEvents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Mouse : MonoBehaviour
    {
        [SerializeField] private GameEventVector3 _eventVector3;
        
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _eventVector3.Raise(Input.mousePosition);
            }
        }
    }
}