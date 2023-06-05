using UnityEngine;

namespace _Scripts.Level
{
    public class LevelSchema : MonoBehaviour
    {
        [SerializeField] private MeshCollider enemySpawnCollider;

        public Bounds GetFieldBounds()
        {
            return enemySpawnCollider.bounds;
        }
    }
}