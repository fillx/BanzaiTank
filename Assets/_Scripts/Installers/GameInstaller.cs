using _Scripts.Config;
using _Scripts.Enemy;
using _Scripts.Enemy.Model;
using _Scripts.GameInput;
using _Scripts.Level;
using Enemy;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public LevelSchema LevelSchema;
        public EnemySpawnConfig Config;

        public override void InstallBindings()
        {
            Container.Bind<IInputService>().To<VanillaInputService>().AsSingle();
            Container.Bind<LevelSchema>().FromInstance(LevelSchema).AsSingle().NonLazy();
            Container.Bind<EnemySpawnConfig>().FromInstance(Config).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle();
            Container.BindFactory<EnemyModel, EnemyView, EnemyFactory>()
                .FromPoolableMemoryPool<EnemyModel, EnemyView, EnemyPool>(poolBinder => poolBinder
                    .WithInitialSize(Config.MaxEnemiesOnLevel)
                    .FromSubContainerResolve()
                    .ByNewPrefabInstaller<EnemyInstaller>(GetRandomEnemyPrefab)
                    .UnderTransformGroup("Enemies"));

            Object GetRandomEnemyPrefab(InjectContext context)
            {
                return Config.Enemies[Random.Range(0, Config.Enemies.Length)].Prefab;
            }
        }
    }
}