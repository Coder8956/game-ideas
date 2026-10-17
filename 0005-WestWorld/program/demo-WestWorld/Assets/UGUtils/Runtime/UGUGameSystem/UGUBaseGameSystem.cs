using UnityEngine;

namespace UGU.Runtime
{
    /// <summary>
    /// 游戏系统基类
    /// 只能通过 UGUGameSystemUtils.Create() 创建全局唯一实例。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("")]
    public abstract class UGUBaseGameSystem<T> : MonoBehaviour
        where T : UGUBaseGameSystem<T>
    {
        /// <summary>
        /// 是否正通过 Create() 创建
        /// </summary>
        internal static bool IsCreating;

        /// <summary>
        /// 全局实例
        /// </summary>
        protected internal static T Instance { get; internal set; }

        /// <summary>
        /// 实例是否存在
        /// </summary>
        public static bool HasInstance => Instance != null;

        /// <summary>
        /// 是否已初始化
        /// </summary>
        public bool Initialized { get; private set; }

        /// <summary>
        /// Unity Awake
        /// </summary>
        protected virtual void Awake()
        {
            // 必须通过 Create() 创建
            if (!IsCreating)
            {
                Debug.LogError(
                    $"{typeof(T).Name} 必须通过 UGUGameSystemUtils.Create<{typeof(T).Name}>() 创建。");

                Destroy(gameObject);
                return;
            }

            // 防止重复实例
            if (Instance != null && Instance != this)
            {
                Debug.LogError(
                    $"{typeof(T).Name} 只能存在一个实例。");

                Destroy(gameObject);
                return;
            }

            Instance = (T) this;

            gameObject.name = typeof(T).Name;

            InitializeInternal();
        }

        /// <summary>
        /// Unity OnDestroy
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        /// <summary>
        /// 内部初始化
        /// </summary>
        private void InitializeInternal()
        {
            if (Initialized)
                return;

            Initialized = true;

            OnInitialize();
        }

        /// <summary>
        /// 系统初始化
        /// </summary>
        protected abstract void OnInitialize();
    }
}
