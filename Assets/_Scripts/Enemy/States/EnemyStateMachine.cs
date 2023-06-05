using System.Collections.Generic;
using _Scripts.SimpleStateMachine;
using Zenject;

namespace _Scripts.Enemy.States
{
    public class EnemyStateMachine : SimpleStateMachine.SimpleStateMachine
    {
        protected override IStateAction CurrentState { get; set; }
        public virtual List<IStateAction> States { get; set; }

        [Inject]
        public void Construct(EnemyStateIdle idle, EnemyAttackState attack)
        {
            States = new List<IStateAction>
            {
                idle,
                attack
            };
        }

        public override void Initialize()
        {
            ChangeState(States[1]);
        }
    }
}