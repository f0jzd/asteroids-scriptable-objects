using System;
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
        [SerializeField] private GameEventGameObject _onAsteroidDestroyed;

        //[SerializeField] private ScriptableEventInt _onHitAsteroidEventSimple;
        [SerializeField] private IntReference pointsReference;
        [SerializeField] private IntVariable points;
        
        private Rigidbody2D _rigidbody;
        
        
        

        private void Start()
        {
            
            _rigidbody = GetComponent<Rigidbody2D>();
            _laserRuntimeSet.Add(gameObject);
            Debug.Log("Amount of Lasers: " + _laserRuntimeSet.Amount);
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
                var asteroid = other.GetComponentInParent<Asteroid>();
                var id = asteroid.GetInstanceID();
                //_onHitAsteroidEvent.Raise(id);
                //_onHitAsteroidEventSimple.Raise(id);
                
                //asteroid.DestroyMe();

                Debug.Log("Hit asteroid");
                //Destroy(other.gameObject);
                
                _onAsteroidDestroyed.Raise(other.gameObject);
                
                pointsReference.ApplyChange(+1);
                _onPointsChangedEvent.Raise(points.Value);
                
                
                
                
                //_onHitAsteroidEvent.Raise(points.Value);
                
                //Destroy other, add points => update hud
                
                //Call event
                //OnLaserHitAsteroidEvent.Raise(identifier?)
                //Listener destroys asteroid
            }
        }
    }
}
