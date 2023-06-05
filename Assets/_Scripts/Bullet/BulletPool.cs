using Zenject;

namespace _Scripts.Bullet
{
    class BulletPool : MonoPoolableMemoryPool<float, float, IMemoryPool, BulletView>
    {
    }
}