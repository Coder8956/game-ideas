using UnityEngine;

namespace UMiniFramework.Runtime
{
    public class UMOAudio : UMMonoSingletonBase<UMOAudio>
    {
        // ==================== 私有字段（运行时状态） ====================

        private const string BGM_GO_NAME = "BGM";
        private const string SFX_GO_NAME = "SFX";

        // ==================== 属性 ====================

        public static UMAudioBGM BGM { get; private set; }
        public static UMAudioSFX SFX { get; private set; }

        // ==================== 生命周期 ====================

        protected override void OnInit()
        {
            // 创建 BGM 对象
            BGM = CreateChild<UMAudioBGM>(BGM_GO_NAME);
            BGM.Init();

            // 创建 SFX 对象
            SFX = CreateChild<UMAudioSFX>(SFX_GO_NAME);
            SFX.Init();
        }

        // ==================== 逻辑 ====================

        private static T CreateChild<T>(string name) where T : Component
        {
            GameObject go = new GameObject(name);
            go.transform.SetParent(Instance.transform);
            return go.AddComponent<T>();
        }
    }
}