namespace _Scripts.Damage
{
    public abstract class DamageableDecorator : IDamageable
    {
        protected IDamageable _damageable;

        protected DamageableDecorator(IDamageable damageable)
        {
            _damageable = damageable;
        }

        public virtual void TakeDamage(float damage)
        {
            _damageable.TakeDamage(damage);
        }
    }
}