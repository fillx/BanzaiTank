using System;
using _Scripts.Damage;
using UnityEngine;

namespace _Scripts.Enemy.Model
{
    [Serializable]
    public class EnemyModel : IDamageable
    {
        public event Action<EnemyModel> OnEnemyDeath;

        public string Name;
        public float Attack;
        public float Hp;
        public float DefenceModifier;
        public float MoveSpeed;

        public bool isDead => Hp <= 0;

        public void TakeDamage(float damage)
        {
            Hp -= damage;
            Debug.Log($"Враг {Name} получил урон: {damage}  Hp: {Hp} Armor: {DefenceModifier}");
            if (isDead)
                OnEnemyDeath?.Invoke(this);
        }

        public void Suicide()
        {
            Hp = 0;
            OnEnemyDeath?.Invoke(this);
        }
    }
}