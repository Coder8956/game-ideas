using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEditor;
using UnityEngine;

namespace UMiniFramework.Runtime
{
    /// <summary>
    /// 数据持久化
    /// </summary>
    public class UMOPersist : UMMonoSingletonBase<UMOPersist>
    {
        // ==================== 私有字段（运行时状态） ====================

        /// <summary>
        /// 文件名 -> 内容快照（排除时间戳字段），用于检测数据是否发生变化。
        /// 仅当快照发生变化时才更新 LastUpdateTime 并写盘。
        /// </summary>
        private readonly Dictionary<string, string> m_contentSnapshots = new Dictionary<string, string>();

        // ==================== 静态只读 ====================

        private static readonly JsonSerializerSettings SnapshotSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.None,
            ContractResolver = new ExcludeTimestampsResolver()
        };

        // ==================== 属性 ====================

        public string SaveRootDir { get; set; }

        /// <summary>
        /// 加密处理
        /// </summary>
        public Func<string, string> EncryptionHandler { get; set; }

        /// <summary>
        /// 解密处理
        /// </summary>
        public Func<string, string> DecryptionHandler { get; set; }

        // ==================== 生命周期 ====================

        protected override void OnInit()
        {
            // SaveRootDir = Application.persistentDataPath;
            SaveRootDir = Application.streamingAssetsPath;

            if (!Directory.Exists(SaveRootDir))
            {
                Directory.CreateDirectory(SaveRootDir);
            }
        }

        // ==================== 逻辑 / 公开接口 ====================

        private string GetDataFileFullPath(string filePath)
        {
            return Path.Combine(SaveRootDir, filePath).Replace('\\', '/');
        }

        private static string GetTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static void Delete(string path)
        {
            string fileFullPath = Instance.GetDataFileFullPath(path);
            Instance.m_contentSnapshots.Remove(path);
            if (File.Exists(fileFullPath))
            {
                File.Delete(fileFullPath);
#if UNITY_EDITOR
                File.Delete($"{fileFullPath}.meta");
                AssetDatabase.Refresh();
#endif
            }
        }

        public static void DeleteAll()
        {
            Instance.m_contentSnapshots.Clear();
            if (Directory.Exists(Instance.SaveRootDir))
            {
                Directory.Delete(Instance.SaveRootDir, true);
            }
            Directory.CreateDirectory(Instance.SaveRootDir);
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }

        public static void Save<T>(string path, T data) where T : UMPersistDataBase
        {
            if (data == null)
            {
                Debug.LogWarning($"[UMOPersist] Save<{typeof(T).Name}>({path}) data is null, skipped.");
                return;
            }

            string fileFullPath = Instance.GetDataFileFullPath(path);
            string fileDir = Path.GetDirectoryName(fileFullPath);
            if (!Directory.Exists(fileDir))
            {
                Directory.CreateDirectory(fileDir);
            }

            // 仅在数据内容发生变化时更新 LastUpdateTime 并写盘
            string currentSnapshot = GetContentSnapshot(data);
            var snapshots = Instance.m_contentSnapshots;
            if (currentSnapshot != null
                && snapshots.TryGetValue(path, out var prevSnapshot)
                && prevSnapshot == currentSnapshot)
            {
                return;
            }

            data.LastUpdateTime = GetTime();
            string jsonStr = JsonConvert.SerializeObject(data, Formatting.Indented);

            if (Instance.IsValidEncrypDecryp())
            {
                jsonStr = Instance.EncryptionHandler.Invoke(jsonStr);
            }

            File.WriteAllText(fileFullPath, jsonStr);

            // 仅缓存有效快照；计算失败时不缓存，使下次 Save 回退为始终写入
            if (currentSnapshot != null)
            {
                snapshots[path] = currentSnapshot;
            }
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }

        public static T Read<T>(string path, T defaultVal = null) where T : UMPersistDataBase
        {
            T data = null;
            string fileFullPath = Instance.GetDataFileFullPath(path);
            if (File.Exists(fileFullPath))
            {
                try
                {
                    string jsonContent = File.ReadAllText(fileFullPath);
                    if (Instance.IsValidEncrypDecryp())
                    {
                        jsonContent = Instance.DecryptionHandler.Invoke(jsonContent);
                    }

                    data = JsonConvert.DeserializeObject<T>(jsonContent);

                    // 缓存内容快照，使“读后未改再存”也能跳过写盘
                    if (data != null)
                    {
                        Instance.m_contentSnapshots[path] = GetContentSnapshot(data);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError($"[UMOPersist] Read<{typeof(T).Name}>({path}) failed: {e}");
                }
            }

            if (data == null)
            {
                data = defaultVal ?? (T)Activator.CreateInstance(typeof(T));
                data.CreateTime = GetTime();
                data.LastUpdateTime = data.CreateTime;
            }

            return data;
        }

        private bool IsValidEncrypDecryp()
        {
            bool valid = (EncryptionHandler != null && DecryptionHandler != null);
            if (!valid && (EncryptionHandler != null || DecryptionHandler != null))
            {
                Debug.LogWarning("[UMOPersist] EncryptionHandler/DecryptionHandler 未成对设置，加解密将被跳过。");
            }
            return valid;
        }

        /// <summary>
        /// 计算排除时间戳字段后的内容快照，用于变更检测。
        /// 计算异常时返回 null，调用方据此回退为“始终写入”。
        /// </summary>
        private static string GetContentSnapshot<T>(T data) where T : UMPersistDataBase
        {
            try
            {
                return JsonConvert.SerializeObject(data, SnapshotSettings);
            }
            catch
            {
                return null;
            }
        }

        public static void PrintSaveRootDir()
        {
            Debug.Log($"[UMOPersist] SaveRootDir: {Instance.SaveRootDir}");
        }

        /// <summary>
        /// 序列化时排除时间戳字段，使快照只反映业务数据本身。
        /// </summary>
        private class ExcludeTimestampsResolver : DefaultContractResolver
        {
            private static readonly HashSet<string> Excluded = new HashSet<string>
            {
                "CreateTime", "LastUpdateTime"
            };

            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
                return props.Where(p => !Excluded.Contains(p.PropertyName)).ToList();
            }
        }
    }
}
