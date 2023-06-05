using _Scripts.Config;
using _Scripts.GameInput;
using _Scripts.Player.Model;
using Zenject;

namespace _Scripts.Player
{
    public class PlayerWeaponHandler : ITickable, IInitializable
    {
        private readonly IInputService _inputService;
        private readonly PlayerView _view;
        private readonly PlayerModel _model;

        private WeaponType weaponType;

        public PlayerWeaponHandler(IInputService inputService, PlayerModel model, PlayerView view)
        {
            _inputService = inputService;
            _model = model;
            _view = view;
        }

        public void Initialize()
        {
            weaponType = _model.SelectedWeapon;
            ChangeWeapon(0);
        }

        public void Tick()
        {
            if (_model.isDead)
                return;

            if (_inputService.isActionButtonUp)
                ShootAction();

            if (_inputService.isNextWeaponButtonUp)
                ChangeWeapon(1);

            if (_inputService.isPreviousWeaponButtonUp)
                ChangeWeapon(-1);
        }

        private void ShootAction()
        {
            _view.Weapons[(int)weaponType].Fire();
        }

        private void ChangeWeapon(int axis)
        {
            weaponType = (WeaponType)(((int)weaponType + axis + _view.Weapons.Length) % _view.Weapons.Length);
            _view.ChangeWeapon(weaponType);
            _model.SelectedWeapon = weaponType;
        }
    }
}