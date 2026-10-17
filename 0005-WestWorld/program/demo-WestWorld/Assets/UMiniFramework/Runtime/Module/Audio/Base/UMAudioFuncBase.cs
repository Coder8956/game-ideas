using UnityEngine;

namespace UMiniFramework.Runtime
{
    /// <summary>
    /// 音频功能基类，提供音频剪辑加载能力
    /// </summary>
    public abstract class UMAudioFuncBase : MonoBehaviour
    {
        // ==================== 逻辑 ====================

        protected void LoadClipInACI(UMACInfo aci)
        {
            aci.LoadClip();
        }
    }
}
