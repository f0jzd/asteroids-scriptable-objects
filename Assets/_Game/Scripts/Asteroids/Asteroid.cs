using System;
using ScriptableEvents;
using UnityEngine;
using Variables;
using Random = UnityEngine.Random;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        
        [SerializeField] private AsteroidRuntimeSet _asteroidRuntimeSet;
        [SerializeField] private ScriptableEventInt _onAsteroidDestroyed;
        private AsteroidManager _asteroidManager;
        
        
        [Header("Config:")]
        [SerializeField] private float _minForce;
        [SerializeField] private float _maxForce;
        [SerializeField] private float _minSize;
        [SerializeField] private float _maxSize;
        [SerializeField] private float _minTorque;
        [SerializeField] private float _maxTorque;

        [Header("References:")]
        [SerializeField] private Transform _shape;

        private Rigidbody2D _rigidbody;
        private Vector3 _direction;
        private int instanceId;

        private void Start()
        {
            
            _asteroidRuntimeSet.Add(gameObject);
            
            instanceId = GetInstanceID();
            
            _rigidbody = GetComponent<Rigidbody2D>();
            
            SetDirection();
            AddForce();
            AddTorque();
            SetSize();
        }

        
        //TODO move to singel listener,something like on  ASteroidDestroyer?
        public void OnHitByLaser(IntReference asteroidId)
        {
            
            if (instanceId == asteroidId.GetValue())
            {
                Destroy(gameObject);
            }
        }
        
        public void OnHitByLaserInt(int asteroid)
        {
            
            if (instanceId == asteroid)
            {
                Destroy(gameObject);
            }
        }

        public void HitByLaser()
        {
            //_asteroidManager.AsteroidDestroyer(this.gameObject);
            _onAsteroidDestroyed.Raise(this.instanceId);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (string.Equals(other.tag, "Laser"))
            {
                HitByLaser();
            }
        }


        private void SetDirection()
        {
            var size = new Vector2(3f, 3f);
            var target = new Vector3
            (
                Random.Range(-size.x, size.x),
                Random.Range(-size.y, size.y)
            );

            _direction = (target - transform.position).normalized;
        }

        private void AddForce()
        {
            var force = Random.Range(_minForce, _maxForce);
            _rigidbody.AddForce( _direction * force, ForceMode2D.Impulse);
        }

        private void AddTorque()
        {
            var torque = Random.Range(_minTorque, _maxTorque);
            var roll = Random.Range(0, 2);

            if (roll == 0)
                torque = -torque;
            
            _rigidbody.AddTorque(torque, ForceMode2D.Impulse);
        }

        private void SetSize()
        {
            var size = Random.Range(_minSize, _maxSize);
            _shape.localScale = new Vector3(size, size, 0f);
        }
    }
}
