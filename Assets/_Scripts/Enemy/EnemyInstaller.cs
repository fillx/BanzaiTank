using _Scripts.Enemy.Model;
using _Scripts.Enemy.MonoComponents;
using _Scripts.Enemy.States;
using Zenject;

namespace _Scripts.Enemy
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyModel>().AsSingle();
            Container.Bind<EnemyContactWithColliderTrigger>().AsSingle();
            Container.Bind<EnemyDamageTrigger>().AsSingle();
            Container.Bind<EnemyStateIdle>().AsSingle();
            Container.Bind<EnemyAttackState>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyStateMachine>().AsSingle();
        }
    }
}