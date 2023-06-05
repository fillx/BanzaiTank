using _Scripts.Enemy;
using _Scripts.Enemy.Model;
using Zenject;

namespace Enemy
{
    class EnemyPool : MonoPoolableMemoryPool<EnemyModel, IMemoryPool, EnemyView>
    {
    }
}