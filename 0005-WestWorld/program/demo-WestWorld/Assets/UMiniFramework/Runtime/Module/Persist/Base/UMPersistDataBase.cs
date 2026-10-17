using Newtonsoft.Json;

namespace UMiniFramework.Runtime
{
    /// <summary>
    /// 持久化数据基类。
    /// CreateTime 在 UMOPersist.CreateData 时设置一次；
    /// LastUpdateTime 由 UMOPersist 在数据内容发生变化时自动更新（未变化时保持不变）。
    /// </summary>
    public abstract class UMPersistDataBase
    {
        [JsonProperty] internal string CreateTime = "Invalid";

        // 由 UMOPersist.Save 在检测到内容变化时维护，调用方无需手动修改
        [JsonProperty] internal string LastUpdateTime = "Invalid";

        public string GetLastUpdateTime()
        {
            return LastUpdateTime;
        }

        public string GetCreateTime()
        {
            return CreateTime;
        }
    }
}