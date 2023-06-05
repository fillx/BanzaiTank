using System;
using System.Linq;
using _Scripts.Bullet;
using _Scripts.Player;
using _Scripts.Player.Model;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Config
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Player")] public PlayerView Prefab;
        public PlayerModel PlayerModel;
        [FormerlySerializedAs("Bullet")] public BulletView BulletPrefab;
        public Weapon[] Weapons;

        public Weapon GetWeaponConfig(WeaponType weaponType)
        {
            return Weapons.FirstOrDefault(weapon => weapon.WeaponType == weaponType);
        }
    }

    [Serializable]
    public class Weapon
    {
        public WeaponType WeaponType;
        public float Damage;
        public float Speed;
    }

    public enum WeaponType
    {
        OneShot = 0,
        TwoShot = 1
    }
}