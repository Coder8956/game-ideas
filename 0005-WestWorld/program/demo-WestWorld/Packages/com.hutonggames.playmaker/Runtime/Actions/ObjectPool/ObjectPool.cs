//#define PROFILE_OBJECT_POOL

using System;
using System.Collections.Generic;
using System.Diagnostics;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using Object = UnityEngine.Object;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if PROFILE_OBJECT_POOL
using System.Diagnostics;
using Debug = UnityEngine.Debug;
#endif

namespace HutongGames.PlayMaker
{
    /// <summary>
    /// Manages a pool of GameObjects spawned from a prefab.
    /// </summary>
    public class ObjectPool : IDisposable
    {
#if UNITY_EDITOR
#if UNITY_6000_5_OR_NEWER
        [Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
#endif
        private static readonly List<GameObject> PrefabRootsPendingUnload = new();
#if UNITY_6000_5_OR_NEWER
        [Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
#endif
        private static bool _prefabUnloadScheduled;
#endif

        /// <summary>
        /// Raised when the pool changes (Editor Only).
        /// </summary>
        public event Action Changed;
        
        /// <summary>
        /// The hidden pool-owned clone used as the internal template for spawned instances.
        /// </summary>
        public GameObject PoolPrefabInstance { get; private set; }
        
        /// <summary>
        /// The original prefab used to make the pool.
        /// </summary>
        public GameObject SourcePrefab { get; }
        
        public int ActiveCount => _active.Count;

        public int InactiveCount => _inactive.Count;
        
        public int TotalCount => ActiveCount + InactiveCount;
        
        public int MaxSize => _maxSize;
        
        public string LastGetFailureReason { get; private set; }

        public int Version => _version;
        
        /// <summary>
        /// List of instances ready to be spawned.
        /// Note, we use a list instead of a stack because we need random access
        /// to remove destroyed GameObjects. E.g., when a scene is unloaded,
        /// we might want to keep the pool but remove destroyed instances.
        /// </summary>
        private readonly List<GameObject> _inactive;

        /// <summary>
        /// The List of spawned instances coming from this Pool.
        /// </summary>
        private readonly List<GameObject> _active = new();
        
        /// <summary>
        /// The pool scene root, if needed, will be null if we don't organize the hierarchy per settings.
        /// </summary>
        private Transform _poolSceneRoot;
        private readonly int _maxSize;
        private readonly ObjectPoolMaxSizePolicy _maxSizePolicy;
        private readonly bool _useSceneParent;
        private Transform _sceneParent;
        private readonly int _defaultCapacity;
        private readonly int _preloadCount;
        private int _version;

        public ObjectPool(
            GameObject prefab, 
            int preloadCount = 0, 
            int defaultCapacity = 10, 
            int maxSize = 100, 
            bool useSceneParent = false,
            ObjectPoolMaxSizePolicy maxSizePolicy = ObjectPoolMaxSizePolicy.DestroyOldestActive)
        {
            if (maxSize <= 0) throw new ArgumentException("Max Size must be greater than 0", nameof(maxSize));
            
#if PROFILE_OBJECT_POOL
            var timer = Stopwatch.StartNew();
#endif
            
            // Make a copy of the source prefab for the pool
            PoolPrefabInstance = CreatePoolPrefab(prefab);
            PoolPrefabInstance.name = prefab.name;
            SourcePrefab = prefab;
            
            if (!PoolPrefabInstance.HasComponent<PooledObject>())
            {
                // Add the component once to the prefab instead of each instance
                // TODO: Preprocess the prefab to add this at edit/build time?
                PoolPrefabInstance.AddComponent<PooledObject>();
            }
            
            _inactive = new List<GameObject>(Mathf.Min(defaultCapacity, maxSize));
            _maxSize = maxSize;
            _maxSizePolicy = maxSizePolicy;
            _useSceneParent = useSceneParent;
            _defaultCapacity = defaultCapacity;
            _preloadCount = Mathf.Min(preloadCount, maxSize);
            
            EnsurePreloadCount();

#if PROFILE_OBJECT_POOL
            Debug.Log($"ObjectPool: {prefab.name} created in {timer.ElapsedMilliseconds}ms"
#if UNITY_EDITOR
                      + "\nNOTE: This is slower in editor than in a build! " +
                      "Make sure to profile on the target platform."
#endif
                );
#endif
        }
        
        private GameObject CreatePooledObject()
        {
            if (PoolPrefabInstance == null)
            {
                UnityEngine.Debug.LogWarning("ObjectPool: Source prefab is null, cannot create pooled object.");
                return null;
            }
            
            // NOTE: The prefab is already disabled, see above.
            var obj = Object.Instantiate(PoolPrefabInstance);
            RestoreSceneObjectVisibility(obj);
            
            // TODO: Do we need to avoid this GetComponent?
            // Rough profiling suggests there's not much benefit...
            var pooledObject = obj.GetComponent<PooledObject>();
            if (pooledObject) // should always be true
            {
                pooledObject.SetObjectPool(this, _version);
            }
            
            if (_useSceneParent)
            {
                if (!_sceneParent)
                {
                    _sceneParent = new GameObject($"{PoolPrefabInstance.name} Pool").transform;
                }
                obj.transform.SetParent(_sceneParent);
            }
            else
            {
                // Reset parenting
                obj.transform.SetParent(null);
            }
            
            return obj;
        }

        private static void RestoreSceneObjectVisibility(GameObject obj)
        {
            if (!obj) return;
            obj.hideFlags = HideFlags.None;
        }

        private static GameObject CreatePoolPrefab(GameObject prefab)
        {
#if UNITY_EDITOR
            if (Application.isEditor)
            {
                var assetPath = AssetDatabase.GetAssetPath(prefab);
                if (!string.IsNullOrEmpty(assetPath) && PrefabUtility.IsPartOfPrefabAsset(prefab))
                {
                    // Editor-time tooling and integration tests can create pools from prefab assets.
                    // In play mode we still want this path so we don't dirty prefab assets,
                    // but unloading must be deferred because Unity forbids immediate destroy
                    // during callbacks such as physics events.
                    // We need the internal pool template to start disabled so pooled instances stay "cold",
                    // but we must not call prefab.SetActive(false) on the source asset because that dirties it.
                    // Loading prefab contents gives us a temporary editable root that we can disable safely
                    // before cloning the internal template.
                    var prefabRoot = PrefabUtility.LoadPrefabContents(assetPath);
                    try
                    {
                        prefabRoot.SetActive(false);
                        var editorPoolPrefab = Object.Instantiate(prefabRoot);
                        editorPoolPrefab.hideFlags = HideFlags.HideAndDontSave;
                        return editorPoolPrefab;
                    }
                    finally
                    {
                        ScheduleUnloadPrefabContents(prefabRoot);
                    }
                }
            }
#endif

            // We want to spawn the prefab in a disabled state so
            // we don't pay the cost of Awake and OnEnable, then OnDisable.
            // This is particularly important for FSMs because they are more
            // expensive to initialize, and they register themselves with the UpdateManager.
            var wasEnabled = prefab.activeSelf;

            // Note, some sources say this doesn't work on a prefab asset,
            // but all tests indicate that it does!
            prefab.SetActive(false);
            var poolPrefab = Object.Instantiate(prefab);
            prefab.SetActive(wasEnabled);
            return poolPrefab;
        }

#if UNITY_EDITOR
        private static void ScheduleUnloadPrefabContents(GameObject prefabRoot)
        {
            if (prefabRoot == null)
                return;

            PrefabRootsPendingUnload.Add(prefabRoot);

            if (_prefabUnloadScheduled)
                return;

            _prefabUnloadScheduled = true;
            EditorApplication.delayCall += UnloadQueuedPrefabContents;
        }

        private static void UnloadQueuedPrefabContents()
        {
            _prefabUnloadScheduled = false;

            if (PrefabRootsPendingUnload.Count == 0)
                return;

            var pendingRoots = PrefabRootsPendingUnload.ToArray();
            PrefabRootsPendingUnload.Clear();

            for (int i = 0; i < pendingRoots.Length; i++)
            {
                var prefabRoot = pendingRoots[i];
                if (prefabRoot == null)
                    continue;

                PrefabUtility.UnloadPrefabContents(prefabRoot);
            }
        }
#endif

        private bool EnsurePoolPrefab()
        {
            if (PoolPrefabInstance) return true;
            if (!SourcePrefab)
            {
                UnityEngine.Debug.LogWarning("ObjectPool: Source prefab is null, cannot rebuild pool.");
                return false;
            }

            // Rebuild the internal pool prefab when scene reload destroyed it.
            PoolPrefabInstance = CreatePoolPrefab(SourcePrefab);
            PoolPrefabInstance.name = SourcePrefab.name;

            if (!PoolPrefabInstance.HasComponent<PooledObject>())
            {
                PoolPrefabInstance.AddComponent<PooledObject>();
            }

            if (_inactive.Capacity < Mathf.Min(_defaultCapacity, _maxSize))
            {
                _inactive.Capacity = Mathf.Min(_defaultCapacity, _maxSize);
            }

            EnsurePreloadCount();
            return true;
        }

        private void EnsurePreloadCount()
        {
            while (TotalCount < _preloadCount)
            {
                var pooledObject = CreatePooledObject();
                if (!pooledObject) return;
                _inactive.Add(pooledObject);
            }
        }

        /// <summary>
        /// Ensures the pool has a valid internal prefab template.
        /// This can be used by editor tooling to proactively heal pools after scene reload.
        /// </summary>
        public bool EnsureValid()
        {
            return EnsurePoolPrefab();
        }

        /// <summary>
        /// Get an instance from the pool.
        /// NOTE: The instance is disabled so we can do further initialization on it
        /// before enabling it. For example, setting its position and rotation.
        /// </summary>
        /// <returns></returns>
        public GameObject Get()
        {
            LastGetFailureReason = null;

            if (!EnsurePoolPrefab())
            {
                LastGetFailureReason = "the internal pool prefab could not be created or restored.";
                return null;
            }

            PruneDestroyedObjects();

            GameObject go = null;
            while (_inactive.Count > 0)
            {
                go = _inactive[^1];
                _inactive.RemoveAt(_inactive.Count - 1);
                if (go) break;
            }

            if (!go)
            {
                if (TotalCount >= _maxSize)
                {
                    go = HandleMaxSizeExceeded();
                    if (!go)
                    {
                        LastGetFailureReason = GetMaxSizeExceededReason();
                        NotifyChanged();
                        return null;
                    }
                }
                else
                {
                    go = CreatePooledObject();
                    if (!go)
                    {
                        LastGetFailureReason = "a new pooled instance could not be created.";
                        return null;
                    }
                }
            }
            else
            {
                var pooledObject = go.GetComponent<PooledObject>();
                if (pooledObject)
                {
                    pooledObject.SetObjectPool(this, _version);
                }
            }

            _active.Add(go);
            NotifyChanged();
            return go;
        }

        public void Release(GameObject go)
        {
            if (!go) return;
            
            go.SetActive(false);
            _active.Remove(go);
            if (!go)
            {
                NotifyChanged();
                return;
            }
            
            if (_inactive.Count < _maxSize)
            {
                _inactive.Add(go);
            }
            else
            {
                DestroyObject(go);
            }
            
            NotifyChanged();
        }

        public void Remove(GameObject go)
        {
            _inactive.Remove(go);
            _active.Remove(go);
            NotifyChanged();
        }
        
        public void Clear(bool includeActive = false)
        {
            _version++;
            var hadActiveObjects = _active.Count > 0;

            foreach (var go in _inactive)
            {
                if (!go) continue;
                DestroyObject(go);
            }
            _inactive.Clear();

            if (includeActive)
            {
                foreach (var go in _active)
                {
                    if (!go) continue;
                    DestroyObject(go);
                }
            }
            
            // Always clear tracking immediately so pool size is zero after Clear.
            // Active objects can still exist in-scene when includeActive is false,
            // but they are stale and no longer belong to this pool.
            _active.Clear();

            // The internal disabled template is pool-owned and should be rebuilt on-demand.
            if (PoolPrefabInstance)
            {
                DestroyObject(PoolPrefabInstance);
                PoolPrefabInstance = null;
            }

            if (includeActive || !hadActiveObjects)
            {
                if (_sceneParent)
                {
                    DestroyObject(_sceneParent.gameObject);
                    _sceneParent = null;
                }
            }
            NotifyChanged();
        }

        private void PruneDestroyedObjects()
        {
            _inactive.RemoveAll(item => !item);
            _active.RemoveAll(item => !item);
        }

        private GameObject HandleMaxSizeExceeded()
        {
            PruneDestroyedObjects();
            if (TotalCount < _maxSize)
            {
                return CreatePooledObject();
            }

            if (_maxSizePolicy == ObjectPoolMaxSizePolicy.RejectSpawn || _active.Count == 0)
            {
                return null;
            }

            return _maxSizePolicy switch
            {
                ObjectPoolMaxSizePolicy.ReuseOldestActive => ReuseOldestActiveObject(),
                ObjectPoolMaxSizePolicy.DestroyOldestActive => DestroyOldestActiveObjectAndCreateReplacement(),
                _ => null
            };
        }

        private string GetMaxSizeExceededReason()
        {
            return _maxSizePolicy switch
            {
                ObjectPoolMaxSizePolicy.RejectSpawn =>
                    $"the pool is at max size ({_maxSize}) and the overflow policy is set to Reject Spawn.",
                ObjectPoolMaxSizePolicy.DestroyOldestActive =>
                    $"the pool is at max size ({_maxSize}) and the oldest active object could not be replaced.",
                ObjectPoolMaxSizePolicy.ReuseOldestActive =>
                    $"the pool is at max size ({_maxSize}) and the oldest active object could not be reused.",
                _ => $"the pool is at max size ({_maxSize})."
            };
        }

        private GameObject GetOldestActiveObject()
        {
            for (var i = 0; i < _active.Count; i++)
            {
                if (_active[i])
                {
                    return _active[i];
                }
            }

            return null;
        }

        private GameObject DestroyOldestActiveObjectAndCreateReplacement()
        {
            var objectToDestroy = GetOldestActiveObject();
            if (!objectToDestroy)
            {
                return null;
            }

            // This is the safer overflow option for active objects:
            // we retire the oldest live instance completely instead of
            // force-recycling it mid-lifecycle.
            _active.Remove(objectToDestroy);
            DestroyObject(objectToDestroy);
            return CreatePooledObject();
        }

        private GameObject ReuseOldestActiveObject()
        {
            var oldestActiveObject = GetOldestActiveObject();
            if (!oldestActiveObject)
            {
                return null;
            }

            // Normal pooling assumes objects are safe to reuse after an explicit release.
            // This policy is more aggressive: it force-reclaims the oldest object while it
            // is still active, so it should only be used for expendable objects that can be
            // interrupted safely (for example bullets or short-lived VFX).
            _active.Remove(oldestActiveObject);
            oldestActiveObject.SetActive(false);

            var pooledObject = oldestActiveObject.GetComponent<PooledObject>();
            if (pooledObject)
            {
                pooledObject.SetObjectPool(this, _version);
            }

            return oldestActiveObject;
        }

        private void DestroyAll()
        {
            Clear(includeActive: true);
        }

        public void Dispose()
        {
            Clear(includeActive: true);
        }

        private static void DestroyObject(Object obj)
        {
            if (!obj)
            {
                return;
            }

#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                // ObjectPool only destroys pool-owned clones and the optional scene parent,
                // never the source prefab asset referenced by SourcePrefab.
                Object.DestroyImmediate(obj);
                return;
            }
#endif

            Object.Destroy(obj);
        }
        
        [Conditional("UNITY_EDITOR")]
        private void NotifyChanged() => Changed?.Invoke();
    }
}
