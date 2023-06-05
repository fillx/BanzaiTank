using _Scripts.Bullet;
using _Scripts.Enemy.Model;
using Zenject;

namespace _Scripts.Enemy.MonoComponents
{
    public class EnemyContactWithColliderTrigger : DamageOnTriggerComponent
    {
        private EnemyModel _model;

        [Inject]
        public void Constuct(EnemyModel model)
        {
            _model = model;
        }

        protected override void OnSuccessTrigger()
        {
            _model.Suicide();
        }
    }
}