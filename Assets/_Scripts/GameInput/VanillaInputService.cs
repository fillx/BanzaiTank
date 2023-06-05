using UnityEngine;

namespace _Scripts.GameInput
{
    /// <summary>
    /// Работоет с классической импут системой Unity
    /// </summary>
    public class VanillaInputService : IInputService
    {
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";
        private const string Fire1 = "Fire1";
        private const string NextWeapon = "NextWeapon";
        private const string PreviousWeapon = "PreviousWeapon";

        public float VerticalAxis => Input.GetAxis(Vertical);
        public float HorizontalAxis => Input.GetAxis(Horizontal);
        public bool isActionButtonUp => Input.GetButtonUp(Fire1);
        public bool isNextWeaponButtonUp => Input.GetKeyDown(KeyCode.Q);
        public bool isPreviousWeaponButtonUp => Input.GetKeyDown(KeyCode.E);
    }
}