using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Component added to objects that are part of an object pool.
    /// Stores a reference to the object pool so the object can release itself back to the pool.
    /// </summary>
    [Icon(Strings.PlaymakerIconPath)]
    public class PooledObject : MonoBehaviour
    {
        private ObjectPool _objectPool;
        private int _poolVersion;
        
        public void SetObjectPool(ObjectPool objectPool, int poolVersion)
        {
            _objectPool = objectPool;
            _poolVersion = poolVersion;
        }
        
        public void Release()
        {
            if (_objectPool != null &&
                ObjectPoolManager.ContainsPool(_objectPool) &&
                _objectPool.Version == _poolVersion)
            {
                _objectPool.Release(gameObject);
                return;
            }

            // The pool is gone or stale (e.g., pool was cleared), so avoid leaking orphaned instances.
            _objectPool = null;
            Destroy(gameObject);
        }
        
        private void OnDestroy()
        {
            _objectPool?.Remove(gameObject);
            _objectPool = null;
        }
    }
}
