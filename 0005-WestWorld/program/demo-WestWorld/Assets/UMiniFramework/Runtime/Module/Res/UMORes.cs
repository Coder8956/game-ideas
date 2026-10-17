using System;
using UnityEngine;

namespace UMiniFramework.Runtime
{
    public class UMORes : UMMonoSingletonBase<UMORes>
    {
        // ==================== 生命周期 ====================

        protected override void OnInit()
        {
        }

        // ==================== 公开接口 ====================

        // ── Load ──────────────────────────────────────────────

        /// <summary>
        /// 加载任意资源
        /// </summary>
        public static UnityEngine.Object Load(string path)
        {
            return Resources.Load(path);
        }

        /// <summary>
        /// 加载指定类型资源
        /// </summary>
        public static T Load<T>(string path) where T : UnityEngine.Object
        {
            return Resources.Load<T>(path);
        }

        /// <summary>
        /// 加载所有资源
        /// </summary>
        public static UnityEngine.Object[] LoadAll(string path)
        {
            return Resources.LoadAll(path);
        }

        /// <summary>
        /// 加载所有指定类型资源
        /// </summary>
        public static T[] LoadAll<T>(string path) where T : UnityEngine.Object
        {
            return Resources.LoadAll<T>(path);
        }

        // ── Instantiate ──────────────────────────────────────

        /// <summary>
        /// 加载并实例化
        /// </summary>
        public static GameObject InstantiateGO(string path)
        {
            GameObject prefab = Load<GameObject>(path);

            if (prefab == null)
            {
                Debug.LogError($"[UMORes] Resource Not Found : {path}");
                return null;
            }

            return GameObject.Instantiate(prefab);
        }

        /// <summary>
        /// 加载并实例化到父节点
        /// </summary>
        public static GameObject InstantiateGO(string path, Transform parent, bool worldPositionStays = false)
        {
            GameObject prefab = Load<GameObject>(path);

            if (prefab == null)
            {
                Debug.LogError($"[UMORes] Resource Not Found : {path}");
                return null;
            }

            return GameObject.Instantiate(prefab, parent, worldPositionStays);
        }

        /// <summary>
        /// 加载并实例化组件
        /// </summary>
        public static T InstantiateGOGetComponent<T>(string path) where T : Component
        {
            GameObject go = InstantiateGO(path);

            if (go == null)
                return null;

            return go.GetComponent<T>();
        }

        // ── Unload ───────────────────────────────────────────

        /// <summary>
        /// 卸载资源
        /// </summary>
        public static void UnloadAsset(UnityEngine.Object asset)
        {
            if (asset != null)
                Resources.UnloadAsset(asset);
        }

        /// <summary>
        /// 卸载未使用资源
        /// </summary>
        public static AsyncOperation UnloadUnusedAssets()
        {
            return Resources.UnloadUnusedAssets();
        }
    }
}
