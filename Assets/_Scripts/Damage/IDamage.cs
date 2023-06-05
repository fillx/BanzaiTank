namespace _Scripts.Damage
{
    public interface IDamage
    {
        public float GetDamage();
        void ApplyDamage(IDamageable damageable);
    }
}