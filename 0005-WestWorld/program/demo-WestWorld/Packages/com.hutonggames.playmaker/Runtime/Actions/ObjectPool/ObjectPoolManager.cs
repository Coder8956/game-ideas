using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Manages ObjectPools.
    /// We have an ObjectPool for each Prefab we want to pool.
    /// </summary>
    public static class ObjectPoolManager
    {
#if UNITY_EDITOR
        static ObjectPoolManager()
        {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }
#endif

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitInEditor()
        {
            ClearAll();
            ObjectPools.Clear();
            SpawnFailureWarnings.Clear();
        }
        
        /// <summary>
        /// Raised when pools are added or removed.
        /// </summary>
        public static event Action Changed; 
        
        public static IEnumerable<ObjectPool> Pools => ObjectPools.Values.ToList();

        public static int PoolCount => ObjectPools.Values.Count;
        
        private static readonly Dictionary<GameObject, ObjectPool> ObjectPools = new ();
        private static readonly HashSet<GameObject> SpawnFailureWarnings = new ();

        public static bool TryGetPool(GameObject prefab, out ObjectPool pool)
        {
            if (prefab == null)
            {
                pool = null;
                return false;
            }
            
            return ObjectPools.TryGetValue(prefab, out pool);
        }
        
        public static void Create(
            GameObject prefab, 
            int preloadCount, 
            int defaultCapacity, 
            int maxSize, 
            bool useSceneParent,
            ObjectPoolMaxSizePolicy maxSizePolicy)
        {
            GetOrCreatePool(prefab, preloadCount, defaultCapacity, maxSize, useSceneParent, maxSizePolicy);
        }

        /// <summary>
        /// Returns true if the pool is still managed by ObjectPoolManager.
        /// Used to detect orphaned pooled objects after pools are recreated/cleared on subsystem reset.
        /// </summary>
        public static bool ContainsPool(ObjectPool pool)
        {
            if (pool == null) return false;
            return ObjectPools.ContainsValue(pool);
        }
        
        private static ObjectPool GetOrCreatePool(
            GameObject prefab, 
            int preloadCount=0, 
            int defaultCapacity=10, 
            int maxSize=100, 
            bool useSceneParent=false,
            ObjectPoolMaxSizePolicy maxSizePolicy=ObjectPoolMaxSizePolicy.DestroyOldestActive)
        {
            if (ObjectPools.TryGetValue(prefab, out var objectPool)) return objectPool;
            
            objectPool = new ObjectPool(prefab, preloadCount, defaultCapacity, maxSize, useSceneParent, maxSizePolicy);
            ObjectPools[prefab] = objectPool;
            NotifyChanged();

            return objectPool;
        }
        
        public static GameObject SpawnObject(GameObject prefab, Transform atTransform) => 
            SpawnObject(prefab, atTransform.position, atTransform.rotation);
        
        public static GameObject SpawnObject(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            if (PlayMakerUpdate.AppIsQuitting)
            {
                return null;
            }

            if (prefab == null)
            {
                Debug.LogWarning("ObjectPoolManager: Source prefab is null, cannot spawn pooled object.");
                return null;
            }
            
            var objectPool = GetOrCreatePool(prefab);
            var spawnedObject = objectPool.Get();
            if (spawnedObject == null) 
            {
                LogSpawnFailureOnce(prefab, objectPool.LastGetFailureReason);
                return null;
            }

            SpawnFailureWarnings.Remove(prefab);
            
            // NOTE: It's important to set the transform BEFORE activating the instance
            // because the FSM might read the GameObject's position when it starts.
            // E.g., a tween action might store its start position,
            // which will be wrong until we set it here!
            spawnedObject.transform.SetPositionAndRotation(position, rotation);
            
            // NOTE: We do not set active here because 
            // the calling action may want to do other setup 
            // before activating the instance. E.g., setting the parent.
            //spawnedObject.SetActive(true);
            
            return spawnedObject;
        }
        
        public static void ClearPool(GameObject prefab, bool includeActive = false)
        {
            if (prefab == null) return;
            
            if (!ObjectPools.TryGetValue(prefab ,out var pool))
            {
                Debug.LogWarning($"ObjectPoolManager: Pool not found for prefab: {prefab.name}");
                return;
            }
            
            pool.Clear(includeActive);
            SpawnFailureWarnings.Remove(prefab);
            NotifyChanged();
        }

        public static void ClearAll(bool includeActive = false)
        {
            foreach (var pool in ObjectPools.Values)
            {
                pool?.Clear(includeActive);
            }
            SpawnFailureWarnings.Clear();
            NotifyChanged();
        }

#if UNITY_EDITOR
        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.ExitingPlayMode)
                return;

            ClearAll(includeActive: true);
            ObjectPools.Clear();
            SpawnFailureWarnings.Clear();
            NotifyChanged();
        }
#endif

        private static void LogSpawnFailureOnce(GameObject prefab, string reason)
        {
            if (!prefab)
            {
                Debug.LogWarning("ObjectPoolManager: Failed to spawn pooled object.");
                return;
            }

            if (!SpawnFailureWarnings.Add(prefab))
            {
                return;
            }

            var reasonSuffix = string.IsNullOrWhiteSpace(reason)
                ? string.Empty
                : $" Reason: {reason}";

            Debug.LogWarning($"ObjectPoolManager: Failed to spawn pooled object for prefab: {prefab.name}.{reasonSuffix}");
        }
        
        [Conditional("UNITY_EDITOR")]
        private static void NotifyChanged() => Changed?.Invoke();
    }
}
