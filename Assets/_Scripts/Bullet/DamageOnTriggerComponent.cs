using _Scripts.Damage;
using UnityEngine;

namespace _Scripts.Bullet
{
    public abstract class DamageOnTriggerComponent : MonoBehaviour
    {
        public float Damage { private get; set; }

        public virtual void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageableTrigger damageable))
            {
                damageable.DamageOnTrigger(Damage);
                OnSuccessTrigger();
            }
        }

        protected abstract void OnSuccessTrigger();
    }
}