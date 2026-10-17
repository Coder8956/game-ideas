using UnityEngine;

namespace UMiniFramework.Runtime
{
    public static class UMLauncher
    {
        // ==================== 静态字段 ====================

        private static GameObject Root;

        // ==================== 属性 ====================

        /// <summary>
        /// 是否已经启动
        /// </summary>
        public static bool IsWorked { get; private set; }

        // ==================== 公开接口 ====================

        /// <summary>
        /// 执行启动框架（全局仅执行一次）
        /// </summary>
        public static void Work()
        {
            if (IsWorked)
                return;

            IsWorked = true;

            Root = new GameObject("UMiniModules");
            GameObject.DontDestroyOnLoad(Root);
            Root.transform.position = Vector3.zero;

            // 创建框架模块
            UMOAudio.Create(Root);
            UMOConfig.Create(Root);
            UMOEvent.Create(Root);
            UMOGlobalVal.Create(Root);
            UMOPersist.Create(Root);
            UMORes.Create(Root);
            UMOScene.Create(Root);
            UMOUI.Create(Root);
        }
    }
}
