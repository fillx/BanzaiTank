using System;
using _Scripts.Enemy.Model;
using _Scripts.Enemy.MonoComponents;
using UnityEngine;
using Zenject;

namespace _Scripts.Enemy
{
    public class EnemyView : MonoBehaviour, IPoolable<EnemyModel, IMemoryPool>, IDisposable
    {
        [field: SerializeField] public EnemyContactWithColliderTrigger attackCollider { get; set; }
        public EnemyModel Model { get; set; }

        private IMemoryPool _pool;

        [Inject]
        public void Construct(EnemyModel model)
        {
            Model = model;
            model.OnEnemyDeath += Death;
        }

        public void Move(Vector3 velocity)
        {
            transform.Translate(velocity * Time.deltaTime);
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void OnSpawned(EnemyModel model, IMemoryPool pool)
        {
            _pool = pool;
            Model.Hp = model.Hp;
            Model.DefenceModifier = model.DefenceModifier;
            Model.MoveSpeed = model.MoveSpeed;
            Model.Name = gameObject.name;
            attackCollider.Damage = model.Attack;
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }

        private void Death(EnemyModel model)
        {
            Dispose();
        }
    }
}