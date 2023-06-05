using _Scripts.Config;
using _Scripts.Enemy.Model;
using _Scripts.Level;
using UnityEngine;
using Zenject;

namespace _Scripts.Enemy
{
    public class EnemySpawner : ITickable
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly EnemySpawnConfig _spawnConfig;
        private readonly LevelSchema _levelSchema;

        private int _maxEnemyCount;
        private uint _currentEnemyCount;
        private float _spawnInterval;

        public EnemySpawner(EnemyFactory enemyFactory, EnemySpawnConfig spawnConfig, LevelSchema levelSchema)
        {
            _enemyFactory = enemyFactory;
            _spawnConfig = spawnConfig;
            _levelSchema = levelSchema;
            _maxEnemyCount = spawnConfig.MaxEnemiesOnLevel;
        }

        public void Tick()
        {
            if (_currentEnemyCount < _maxEnemyCount && _spawnInterval < Time.time)
            {
                Spawn();
                _spawnInterval = Time.time + _spawnConfig.SpawnInterval;
            }
        }

        private void Spawn()
        {
            var prefab = _spawnConfig.Enemies[Random.Range(0, _spawnConfig.Enemies.Length)];
            var instance = _enemyFactory.Create(prefab.EnemyModel);
            instance.transform.position = GetRandomPoint();
            instance.Model.OnEnemyDeath += OnEnemyDied;
            _currentEnemyCount++;
        }

        void OnEnemyDied(EnemyModel model)
        {
            model.OnEnemyDeath -= OnEnemyDied;
            _currentEnemyCount--;
        }

        private Vector3 GetRandomPoint()
        {
            Bounds bounds = _levelSchema.GetFieldBounds();
            int sideIndex = Random.Range(0, 4);
            Vector3 spawnPosition = Vector3.zero;
            float y = 0.5f;

            switch (sideIndex)
            {
                case 0:
                    spawnPosition = new Vector3
                    (
                        Random.Range(bounds.min.x, bounds.max.x),
                        y,
                        bounds.min.z
                    );
                    break;
                case 1:
                    spawnPosition = new Vector3
                    (
                        Random.Range(bounds.min.x, bounds.max.x),
                        y,
                        bounds.max.z
                    );
                    break;
                case 2:
                    spawnPosition = new Vector3
                    (
                        bounds.min.x,
                        y,
                        Random.Range(bounds.min.z, bounds.max.z)
                    );
                    break;
                case 3:
                    spawnPosition = new Vector3
                    (
                        bounds.max.x,
                        y,
                        Random.Range(bounds.min.z, bounds.max.z)
                    );
                    break;
            }

            return spawnPosition;
        }
    }
}