using _Scripts.Bullet;
using _Scripts.Config;
using UnityEngine;
using Zenject;

namespace _Scripts.Player.MonoComponents
{
    public class WeaponComponent : MonoBehaviour, IWeapon
    {
        [field: SerializeField] public Transform[] BulletSpawnPositions { get; set; }
        [field: SerializeField] public WeaponType WeaponType { get; set; }

        private BulletFactory _factory;
        private Config.Weapon _weapon;

        [Inject]
        public void Construct(BulletFactory bulletFactory, PlayerConfig config)
        {
            _factory = bulletFactory;
            _weapon = config.GetWeaponConfig(WeaponType);
        }

        public void Fire()
        {
            foreach (var spawnPoint in BulletSpawnPositions)
            {
                var instance = _factory.Create(_weapon.Damage, _weapon.Speed);
                instance.transform.forward = spawnPoint.forward;
                instance.transform.position = spawnPoint.position;
            }
        }
    }
}