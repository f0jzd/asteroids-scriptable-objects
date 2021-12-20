using Asteroids;
using UnityEngine;

namespace ScriptableEvents
{
    
    [CreateAssetMenu(fileName = "new ScriptableEventAsteroid", menuName = "ScriptableObject/ScriptableEvent-Asteroid", order = 0)]

    public class ScriptableEventAsteroid : ScriptableEvent<Asteroid>
    {
        
    }
}