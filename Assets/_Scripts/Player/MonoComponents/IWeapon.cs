using _Scripts.Config;
using UnityEngine;

namespace _Scripts.Player.MonoComponents
{
    public interface IWeapon
    {
        public Transform[] BulletSpawnPositions { get; set; }
        public WeaponType WeaponType { get; set; }
        public void Fire();
    }
}