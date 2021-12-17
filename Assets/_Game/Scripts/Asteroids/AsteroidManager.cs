using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Asteroids;
using ScriptableEvents;
using ScriptableEvents.GameEvents;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] private AsteroidRuntimeSet _asteroidRuntimeSet;
    [SerializeField] private GameEventGameObject _onAsteroidDestroyed;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AsteroidDestroyer(GameObject astroid)
    {
        
        Debug.Log("Destroying ASterrdod");
        
        Destroy(astroid);
        
        
        

        //_asteroidRuntimeSet.Remove(asteroidID);


    }
}
