﻿using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        
        
        [SerializeField] private Asteroid _asteroidPrefab;
        
        [SerializeField] private float _minSpawnTime;
        [SerializeField] private float _maxSpawnTime;
        [SerializeField] private int _minAmount;
        [SerializeField] private int _maxAmount;

        
        [Header("Fragment related variables: ")]
        [SerializeField] private AsteroidFragments _asteroidFragments;
        [SerializeField] private float MaxFragmentSize;
        [SerializeField] private float fragmentLifetime;
        [SerializeField] private bool DestroySelf;
        
        

        private Asteroid spawnedItem;
        private AsteroidFragments spawnedItFragments;
        
        private float _timer;
        private float _nextSpawnTime;
        private Camera _camera;
        
        [SerializeField] private AsteroidRuntimeSet _asteroidRuntimeSet;
        
        


        private enum SpawnLocation
        {
            Top,
            Bottom,
            Left,
            Right
        }

        private void Start()
        {
            _camera = Camera.main;
            Spawn();
            UpdateNextSpawnTime();
        }

        private void Update()
        {
            UpdateTimer();

            if (!ShouldSpawn())
                return;

            Spawn();
            UpdateNextSpawnTime();
            _timer = 0f;
        }

        private void UpdateNextSpawnTime()
        {
            _nextSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
        }

        private void UpdateTimer()
        {
            _timer += Time.deltaTime;
        }

        private bool ShouldSpawn()
        {
            return _timer >= _nextSpawnTime;
        }

        private void Spawn()
        {
            var amount = Random.Range(_minAmount, _maxAmount + 1);
            for (var i = 0; i < amount; i++)
            {
                var location = GetSpawnLocation();
                var position = GetStartPosition(location);
                spawnedItem = Instantiate(_asteroidPrefab, position, Quaternion.identity);
            }
        }

        public void SpawnFragments(Vector3 position, Transform asteroidSize)
        {
            if (asteroidSize.transform.localScale.x / 2 > MaxFragmentSize && asteroidSize.transform.localScale.y / 2 > MaxFragmentSize)
            {
                var amount = Random.Range(2, 5);

                //if (!(asteroidSize.localScale.x / 2 > 0.2f) || !(asteroidSize.localScale.y / 2 > 0.2f)) return;
                for (var i = 0; i < amount; i++)
                {
                    var spawnedFragItem = Instantiate(_asteroidFragments, position, Quaternion.identity);//YOU ARE SPAWNING A NEW ASTEROID NOT ACOPY

                    var newSize = new Vector3(
                        asteroidSize.transform.localScale.x / 2,
                        asteroidSize.transform.localScale.y / 2);

                    spawnedFragItem._shape.localScale = newSize;
                    

                    if (DestroySelf)
                    {
                        Destroy(spawnedFragItem.gameObject,fragmentLifetime);
                        _asteroidRuntimeSet.Remove(spawnedFragItem.gameObject.GetInstanceID());
                    }
                }
            }
        }

        private static SpawnLocation GetSpawnLocation()
        {
            var roll = Random.Range(0, 4);

            return roll switch
            {
                1 => SpawnLocation.Bottom,
                2 => SpawnLocation.Left,
                3 => SpawnLocation.Right,
                _ => SpawnLocation.Top
            };
        }

        private Vector3 GetStartPosition(SpawnLocation spawnLocation)
        {
            var pos = new Vector3 { z = Mathf.Abs(_camera.transform.position.z) };
            
            const float padding = 5f;
            switch (spawnLocation)
            {
                case SpawnLocation.Top:
                    pos.x = Random.Range(0f, Screen.width);
                    pos.y = Screen.height + padding;
                    break;
                case SpawnLocation.Bottom:
                    pos.x = Random.Range(0f, Screen.width);
                    pos.y = 0f - padding;
                    break;
                case SpawnLocation.Left:
                    pos.x = 0f - padding;
                    pos.y = Random.Range(0f, Screen.height);
                    break;
                case SpawnLocation.Right:
                    pos.x = Screen.width - padding;
                    pos.y = Random.Range(0f, Screen.height);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(spawnLocation), spawnLocation, null);
            }
            
            return _camera.ScreenToWorldPoint(pos);
        }
    }
}
