using System;
using _Scripts.Enemy;
using _Scripts.Enemy.Model;
using UnityEngine;

namespace _Scripts.Config
{
    [CreateAssetMenu(fileName = "EnemySpawnConfig", menuName = "Game/Configs/EnemySpawnConfig")]
    public class EnemySpawnConfig : ScriptableObject
    {
        public float SpawnInterval;
        public int MaxEnemiesOnLevel;
        public EnemyConfig[] Enemies;
    }

    [Serializable]
    public class EnemyConfig
    {
        public EnemyView Prefab;
        public EnemyModel EnemyModel;
    }
}