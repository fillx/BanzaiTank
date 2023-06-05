using _Scripts.Damage;
using _Scripts.Player.Model;
using UnityEngine;
using Zenject;

namespace _Scripts.Player.MonoComponents
{
    public class PlayerDamageTrigger : MonoBehaviour, IDamageableTrigger
    {
        private PlayerModel _model;

        [Inject]
        public void Construct(PlayerModel model)
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