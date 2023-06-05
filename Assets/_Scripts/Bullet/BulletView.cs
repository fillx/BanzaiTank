using UnityEngine;
using Zenject;

namespace _Scripts.Bullet
{
    public class BulletView : DamageOnTriggerComponent, IPoolable<float, float, IMemoryPool>
    {
        private IMemoryPool _pool;
        private float _speed;
        private float _startTime;
        private float _lifeTime = 5;

        public void OnSpawned(float damage, float speed, IMemoryPool pool)
        {
            _pool = pool;
            _startTime = Time.time;
            Damage = damage;
            _speed = speed;
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void Update()
        {
            transform.position += transform.forward * _speed * Time.deltaTime;

            if (Time.time - _startTime > _lifeTime)
            {
                _pool.Despawn(this);
            }
        }

        protected override void OnSuccessTrigger()
        {
            _pool.Despawn(this);
        }
    }
}