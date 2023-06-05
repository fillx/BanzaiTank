using _Scripts.Player.Model;
using _Scripts.SimpleStateMachine;
using UnityEngine;

namespace _Scripts.Enemy.States
{
    public class EnemyAttackState : IStateAction
    {
        private readonly EnemyView _view;
        private readonly PlayerModel _playerModel;
        private readonly EnemyStateMachine _stateMachine;

        private Vector3 _playerPosition;
        private Transform _transform;

        public EnemyAttackState(EnemyView view, PlayerModel playerModelModel, EnemyStateMachine stateMachine)
        {
            _view = view;
            _playerModel = playerModelModel;
            _stateMachine = stateMachine;

            _transform = _view.transform;
        }

        public void EnterState()
        {
        }

        public void Update()
        {
            if (_playerModel.isDead)
                _stateMachine.ChangeState(new EnemyStateIdle());

            _playerPosition = _playerModel.Position;
            float moveSpeed = _view.Model.MoveSpeed;
            var dir = (_playerPosition - _transform.position).normalized * moveSpeed;
            _view.Move(dir);
        }

        public void ExitState()
        {
        }

        public void FixedUpdate()
        {
        }
    }
}