using UnityEngine;

namespace UMiniFramework.Runtime
{
    /// <summary>
    /// 音频信息
    /// </summary>
    public class UMACInfo
    {
        // ==================== 属性 ====================

        public readonly string ID;
        public readonly string Path;
        public readonly bool IsPreLoad;

        public AudioClip Clip { get; private set; }

        // ==================== 逻辑 ====================

        public UMACInfo(string id, string path, bool isPreLoad = false)
        {
            ID = id;
            Path = path;
            IsPreLoad = isPreLoad;
        }

        // ==================== 公开接口 ====================

        /// <summary>
        /// 加载音频剪辑
        /// </summary>
        internal void LoadClip()
        {
            Clip = Resources.Load<AudioClip>(Path);
        }
    }
}
