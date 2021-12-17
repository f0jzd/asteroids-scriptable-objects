using System;
using System.Collections.Generic;
using ScriptableEvents;
using Ship;
using UnityEngine;

namespace DefaultNamespace.RuntimeSets
{
    [CreateAssetMenu]
    public class LaserRuntimeSet : ScriptableObject
    {
        
        //This will keep track of all the lasers in the scene, and we will create a script to print how many we have
        //If we did this for asteroid we could make them destroy a random one, looks at collection and destroys a random one.
        private readonly List<GameObject> _lasers = new List<GameObject>();
        //public HashSet<Laser> _lasershash = new HashSet<Laser>();//Can also be used but cannot take duplicates.

        public int Amount => _lasers.Count;//Can be changed to an int variable that changes when we add and remove

        public void Add(GameObject laser)
        {
            _lasers.Add(laser);
        }

        public void Remove(GameObject laser)
        {
            _lasers.Remove(laser);
        }

        
        //Todo which is the best method for clearing?
        private void OnEnable()
        {
            _lasers.Clear();
        }
    }
}