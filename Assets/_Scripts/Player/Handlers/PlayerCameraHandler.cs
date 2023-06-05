using _Scripts.Player;
using _Scripts.Player.Model;
using UnityEngine;
using Zenject;

namespace _Scripts.GameCamera
{
    public class PlayerCameraHandler : ILateTickable
    {
        private readonly PlayerView _playerView;
        private Camera _camera;
        private Transform _followTarget;
        private Transform _cameraTransform;
        private Vector3 offsetPosition;
        private Vector3 offsetRotation;

        public PlayerCameraHandler(PlayerView followTarget)
        {
            _playerView = followTarget;
            _camera = Camera.main;
            _cameraTransform = _camera.transform;
            offsetPosition = new Vector3(0, 15, 10);
            offsetRotation = new Vector3(40, 0, 0);
        }

        public void LateTick()
        {
            _cameraTransform.position = _playerView.transform.position -
                                        _playerView.transform.forward * offsetPosition.z +
                                        _playerView.transform.up * offsetPosition.y;
            _cameraTransform.rotation = _playerView.transform.rotation * Quaternion.Euler(offsetRotation);
        }
    }
}