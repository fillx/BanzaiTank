namespace _Scripts.Damage
{
    public class Defence : DamageableDecorator
    {
        private readonly float _defenceModifier;

        public Defence(IDamageable damageable, float defenceModifier) : base(damageable)
        {
            _defenceModifier = defenceModifier;
        }

        public override void TakeDamage(float damage)
        {
            float modifiedDamage = damage * _defenceModifier;
            _damageable.TakeDamage(modifiedDamage);
        }
    }
}