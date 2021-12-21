using Asteroids;
using ScriptableEvents.GameEvents;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    private AsteroidSpawner _asteroidSpawner;
    [SerializeField] private AsteroidRuntimeSet _asteroidRuntimeSet;
    
    void Start()
    {
        _asteroidSpawner = FindObjectOfType<AsteroidSpawner>();

    }

    public void AsteroidDestroyer(Asteroid asteroid)
    {
        _asteroidSpawner.SpawnFragments(asteroid._shape.transform.position, asteroid._shape.transform);
        
        _asteroidRuntimeSet.Remove(asteroid.GetInstanceID());
        Destroy(asteroid.gameObject);
    }
    public void AsteroidFragmentDestroyer(AsteroidFragments asteroid)
    {
        
        _asteroidSpawner.SpawnFragments(asteroid._shape.transform.position, asteroid._shape.transform);
        
        _asteroidRuntimeSet.Remove(asteroid.GetInstanceID());
        Destroy(asteroid.gameObject);
    }
}
