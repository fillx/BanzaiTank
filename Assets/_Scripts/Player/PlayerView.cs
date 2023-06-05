using _Scripts.Bullet;
using _Scripts.Config;
using _Scripts.Player.Model;
using _Scripts.Player.MonoComponents;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    public sealed class PlayerView : MonoBehaviour
    {
        [field: SerializeField] public WeaponComponent[] Weapons { get; set; }
        [field: SerializeField] public Rigidbody Rigidbody { get; set; }

        public Vector3 Direction => Rigidbody.transform.forward;
        public Quaternion Rotation => Rigidbody.rotation;


        [Inject]
        public void Construct(PlayerModel model, BulletFactory bulletFactory)
        {
            model.OnPlayerDeath += Death;
        }

        public void Move(Vector3 velocity)
        {
            Rigidbody.velocity = velocity;
        }

        public void Turn(Quaternion quaternion)
        {
            Rigidbody.MoveRotation(Rotation * quaternion);
        }

        public void ChangeWeapon(WeaponType weaponType)
        {
            for (int i = 0; i < Weapons.Length; i++)
            {
                Weapons[i].gameObject.SetActive(weaponType == Weapons[i].WeaponType);
            }
        }

        private void Death(PlayerModel model)
        {
            gameObject.SetActive(false);
            model.OnPlayerDeath -= Death;
        }
    }
}