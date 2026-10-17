using UnityEngine;

namespace UMiniFramework.Runtime
{
    /// <summary>
    /// MonoBehaviour 单例
    /// 只能由框架创建
    /// </summary>
    public abstract class UMMonoSingletonBase<T> : MonoBehaviour
        where T : UMMonoSingletonBase<T>
    {
        // ==================== 静态字段 ====================

        private static bool IsCreating;

        // ==================== 属性 ====================

        /// <summary>
        /// 子类使用，外部不可见
        /// </summary>
        protected static T Instance { get; private set; }

        /// <summary>
        /// 是否已创建
        /// </summary>
        public static bool IsCreated => Instance != null;

        // ==================== 生命周期 ====================

        protected virtual void Awake()
        {
            if (!IsCreating)
            {
                Debug.LogError($"{typeof(T).Name} 只能通过 Create() 创建。");
                DestroyImmediate(gameObject);
                return;
            }

            if (Instance != null && Instance != this)
            {
                DestroyImmediate(gameObject);
                return;
            }

            Instance = (T) this;

            OnInit();
        }

        /// <summary>
        /// 子类初始化回调
        /// </summary>
        protected abstract void OnInit();

        protected virtual void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        // ==================== 公开接口 ====================

        /// <summary>
        /// 创建单例
        /// </summary>
        internal static T Create()
        {
            if (Instance != null)
                return Instance;

            IsCreating = true;

            var go = new GameObject(typeof(T).Name);

            DontDestroyOnLoad(go);

            go.AddComponent<T>();

            IsCreating = false;

            return Instance;
        }

        /// <summary>
        /// 创建单例并挂载到父节点
        /// </summary>
        internal static T Create(GameObject parent)
        {
            Create();
            Instance.transform.SetParent(parent.transform);
            return Instance;
        }
    }
}
