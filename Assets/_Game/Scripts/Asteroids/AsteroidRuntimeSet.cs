using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu]
    public class AsteroidRuntimeSet : ScriptableObject
    {

        private Dictionary<int,GameObject> _asteroids = new Dictionary<int, GameObject>();

        public int Amount => _asteroids.Count;
        
        public void Add(int ID,GameObject astroid)
        {
            _asteroids.Add(ID,astroid);
        }
        public void Remove(int ID)
        {
            _asteroids.Remove(ID);
        }
        private void OnEnable()
        {
            _asteroids.Clear();
        }


    }
}