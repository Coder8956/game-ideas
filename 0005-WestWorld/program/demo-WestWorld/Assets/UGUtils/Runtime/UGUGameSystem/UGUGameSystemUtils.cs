using UnityEngine;

namespace UGU.Runtime
{
    /// <summary>
    /// 游戏系统创建工具
    /// </summary>
    public static class UGUGameSystemUtils
    {
        // ── 公共入口 ──────────────────────────────────────────────

        /// <summary>
        /// 创建系统
        /// </summary>
        public static T Create<T>(GameObject parent = null)
            where T : UGUBaseGameSystem<T>
        {
            if (UGUBaseGameSystem<T>.Instance != null)
                return UGUBaseGameSystem<T>.Instance;

            UGUBaseGameSystem<T>.IsCreating = true;

            var go = new GameObject(typeof(T).Name);

            Object.DontDestroyOnLoad(go);

            UGUBaseGameSystem<T>.Instance = go.AddComponent<T>();

            if (parent != null)
            {
                UGUBaseGameSystem<T>.Instance.transform.SetParent(parent.transform, false);
            }

            UGUBaseGameSystem<T>.IsCreating = false;

            return UGUBaseGameSystem<T>.Instance;
        }
    }
}
