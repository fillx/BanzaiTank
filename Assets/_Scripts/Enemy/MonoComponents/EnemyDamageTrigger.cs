using _Scripts.Damage;
using _Scripts.Enemy.Model;
using UnityEngine;
using Zenject;

namespace _Scripts.Enemy.MonoComponents
{
    public class EnemyDamageTrigger : MonoBehaviour, IDamageableTrigger
    {
        private EnemyModel _model;

        [Inject]
        public void Construct(EnemyModel model)
        {
            _model = model;
        }

        public void DamageOnTrigger(float damage)
        {
            Defence defence = new Defence(_model, _model.DefenceModifier);
            defence.TakeDamage(damage);
        }
    }
}