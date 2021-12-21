using Asteroids;
using DefaultNamespace.RuntimeSets;
using ScriptableEvents;
using ScriptableEvents.GameEvents;
using UnityEngine;
using Variables;

namespace Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Laser : MonoBehaviour
    {
        
        [Header("Project References: ")] [SerializeField]
        private LaserRuntimeSet _laserRuntimeSet;

        
        [Header("Values")]
        [SerializeField] private float _speed = 0.2f;

        
        [Header("Events: ")]
        [SerializeField] private ScriptableEventIntReference _onPointsChangedEvent;
        [SerializeField] private GameEventAsteroid _onHitAsteroid;
        [SerializeField] private GameEventAsteroidFragment _onHitAsteroidFragment;
        
        [SerializeField] private IntReference pointsReference;
        [SerializeField] private IntVariable points;
        
        private Rigidbody2D _rigidbody;
        
        
        

        private void Start()
        {
            
            _rigidbody = GetComponent<Rigidbody2D>();
            _laserRuntimeSet.Add(gameObject);
        }

        private void OnDestroy()
        {
            _laserRuntimeSet.Remove(gameObject);
        }

        private void FixedUpdate()
        {
            var trans = transform;
            _rigidbody.MovePosition(trans.position + trans.up * _speed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (string.Equals(other.tag, "Asteroid"))
            {
                if (other.GetComponentInParent<Asteroid>())
                {
                    var asteroid = other.GetComponentInParent<Asteroid>();
                    _onHitAsteroid.Raise(asteroid);

                    pointsReference.ApplyChange(+1);
                    _onPointsChangedEvent.Raise(points.Value);
                
                    Destroy(this.gameObject);
                }

                if (other.GetComponentInParent<AsteroidFragments>())
                {
                    var asteroid = other.GetComponentInParent<AsteroidFragments>();
                    _onHitAsteroidFragment.Raise(asteroid);

                    pointsReference.ApplyChange(+1);
                    _onPointsChangedEvent.Raise(points.Value);
                
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
