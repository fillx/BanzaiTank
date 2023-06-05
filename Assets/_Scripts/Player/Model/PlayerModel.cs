using System;
using _Scripts.Config;
using _Scripts.Damage;
using UnityEngine;

namespace _Scripts.Player.Model
{
    [Serializable]
    public class PlayerModel : IDamageable
    {
        public event Action<PlayerModel> OnPlayerDeath;
        public float Hp;
        public float DefenceModifier;
        public float MoveSpeed;
        public float TurnSpeed;
        public WeaponType SelectedWeapon;
        public Vector3 Position { get; set; }
        public bool isDead => Hp <= 0;

        public PlayerModel(PlayerConfig defaultSettings)
        {
            Hp = defaultSettings.PlayerModel.Hp;
            MoveSpeed = defaultSettings.PlayerModel.MoveSpeed;
            TurnSpeed = defaultSettings.PlayerModel.TurnSpeed;
            SelectedWeapon = defaultSettings.PlayerModel.SelectedWeapon;
            DefenceModifier = defaultSettings.PlayerModel.DefenceModifier;
        }

        public void TakeDamage(float damage)
        {
            Hp -= damage;
            Debug.Log($"Игрок получил урон: {damage}  Hp: {Hp} Armor: {DefenceModifier}");
            if (isDead)
                OnPlayerDeath?.Invoke(this);
        }
    }
}