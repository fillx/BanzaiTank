using _Scripts.Bullet;
using _Scripts.Config;
using _Scripts.GameCamera;
using _Scripts.Player.Handlers;
using _Scripts.Player.Model;
using _Scripts.Player.MonoComponents;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        public PlayerConfig playerConfig;

        public override void InstallBindings()
        {
            Container.Bind<PlayerConfig>().FromInstance(playerConfig).AsSingle().NonLazy();
            Container.Bind<PlayerView>()
                .FromComponentInNewPrefab(playerConfig.Prefab).AsSingle().NonLazy();

            Container.Bind<PlayerModel>().AsSingle();
            Container.Bind<Transform>().FromInstance(playerConfig.Prefab.transform);

            Container.Bind<WeaponComponent>().AsTransient();
            Container.Bind<PlayerDamageTrigger>().AsSingle();

            Container.BindInterfacesTo<PlayerCameraHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerMoveHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerWeaponHandler>().AsSingle();

            Container.BindFactory<float, float, BulletView, BulletFactory>()
                .FromPoolableMemoryPool<float, float, BulletView, BulletPool>(poolBinder => poolBinder
                    .WithInitialSize(30)
                    .FromComponentInNewPrefab(playerConfig.BulletPrefab)
                    .UnderTransformGroup("Bullets"));
        }
    }
}