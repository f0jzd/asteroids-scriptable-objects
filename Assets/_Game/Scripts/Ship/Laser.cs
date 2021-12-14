using Asteroids;
using ScriptableEvents;
using UnityEngine;
using Variables;

namespace Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Laser : MonoBehaviour
    {
        
        [Header("Values")]
        [SerializeField] private float _speed = 0.2f;



        [Header("Events: ")]
        [SerializeField] private ScriptableEventIntReference _onHitAsteroidEvent;
        [SerializeField] private ScriptableEventInt _onHitAsteroidEventSimple;
        [SerializeField] private IntReference pointsReference;
        [SerializeField] private IntVariable points;
        

        private Rigidbody2D _rigidbody;
        private float _lifetime;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
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
                var asteroid = other.GetComponentInParent<Asteroid>();
                var id = asteroid.GetInstanceID();
                //_onHitAsteroidEvent.Raise(id);
                _onHitAsteroidEventSimple.Raise(id);
                
                //asteroid.DestroyMe();
                
                
                
                
                Debug.Log("Hit ass");
                Destroy(other.gameObject);
                pointsReference.ApplyChange(1);
                
                
                
                
                //_onHitAsteroidEvent.Raise(points.Value);
                
                //Destroy other, add points => update hud
                
                //Call event
                //OnLaserHitAsteroidEvent.Raise(identifier?)
                //Listener destroys asteroid
            }
        }
    }
}
