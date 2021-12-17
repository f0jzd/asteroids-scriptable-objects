using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu]
    public class AsteroidRuntimeSet : ScriptableObject
    {

        private readonly List<GameObject> _asteroids = new List<GameObject>();

        public int Amount => _asteroids.Count;
        
        public void Add(GameObject astroid)
        {
            _asteroids.Add(astroid);
        }
        public void Remove(GameObject astroid)
        {
            _asteroids.Remove(astroid);
        }
        public void GetInstanceID(GameObject astroid)
        {
            astroid.GetInstanceID();
        }
        
        private void OnEnable()
        {
            _asteroids.Clear();
        }


    }
}