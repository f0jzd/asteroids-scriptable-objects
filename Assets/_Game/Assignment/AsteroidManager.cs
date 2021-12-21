using Asteroids;
using ScriptableEvents.GameEvents;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    private AsteroidSpawner _asteroidSpawner;
    [SerializeField] private AsteroidRuntimeSet _asteroidRuntimeSet;
    //[SerializeField] private GameEventGameObject _onAsteroidDestroyed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _asteroidSpawner = FindObjectOfType<AsteroidSpawner>();

    }

    public void AsteroidDestroyer(Asteroid asteroid)
    {
        
        Debug.Log(asteroid._shape);
        
        _asteroidSpawner.SpawnFragments(asteroid._shape.transform.position, asteroid._shape.transform);
        
        _asteroidRuntimeSet.Remove(asteroid.GetInstanceID());
        Destroy(asteroid.gameObject);
    }
    public void AsteroidFragmentDestroyer(AsteroidFragments asteroid)
    {
        
        Debug.Log(asteroid._shape);
        
        _asteroidSpawner.SpawnFragments(asteroid._shape.transform.position, asteroid._shape.transform);
        
        _asteroidRuntimeSet.Remove(asteroid.GetInstanceID());
        Destroy(asteroid.gameObject);
    }
}
