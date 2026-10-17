using System;

namespace UGU.Runtime
{
    /// <summary>
    /// 应用/系统工具
    /// </summary>
    public static class UGUAppUtils
    {
        /// <summary>
        /// 退出应用
        /// </summary>
        public static void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        /// <summary>
        /// 获取当前时间的 Unix 时间戳（秒）
        /// </summary>
        /// <returns>Unix 时间戳（秒）</returns>
        public static long UnixTimestampSeconds()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
    }
}
