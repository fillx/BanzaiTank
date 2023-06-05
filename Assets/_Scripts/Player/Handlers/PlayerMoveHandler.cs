using _Scripts.GameInput;
using _Scripts.Player.Model;
using UnityEngine;
using Zenject;

namespace _Scripts.Player.Handlers
{
    public class PlayerMoveHandler : IFixedTickable
    {
        private readonly PlayerModel _playerModel;
        private readonly PlayerView _view;
        private readonly IInputService _inputService;
        private float _moveSpeed;
        private float _turnSpeed;

        public PlayerMoveHandler(PlayerView view, PlayerModel playerModel, IInputService inputService)
        {
            _playerModel = playerModel;
            _inputService = inputService;
            _view = view;

            _moveSpeed = playerModel.MoveSpeed;
            _turnSpeed = playerModel.TurnSpeed;
        }

        public void FixedTick()
        {
            if (_playerModel.isDead)
                return;
            Move();
            Turn();
        }

        private void Move()
        {
            _playerModel.Position = _view.transform.position;
            Vector3 movement = _view.Direction * (_inputService.VerticalAxis * _moveSpeed);
            _view.Move(movement);
        }

        private void Turn()
        {
            float turn = _inputService.HorizontalAxis * _turnSpeed * Time.fixedDeltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            _view.Turn(turnRotation);
        }
    }
}