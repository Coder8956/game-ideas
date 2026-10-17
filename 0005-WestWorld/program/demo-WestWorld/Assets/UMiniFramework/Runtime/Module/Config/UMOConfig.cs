using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMiniFramework.Runtime
{
    public class UMOConfig : UMMonoSingletonBase<UMOConfig>
    {
        // ==================== 私有字段（运行时状态） ====================

        private UMLocalCfg m_local;

        private readonly Dictionary<Type, UMConfigTableBase> m_tableDic = new();

        // ==================== 静态字段 ====================

        private static Dictionary<Type, UMConfigTableBase> TableDic = null;

        // ==================== 属性 ====================

        /// <summary>
        /// 多语言功能对象（添加语言配置表时自动创建）
        /// </summary>
        public static UMLocalCfg Local => IsCreated ? Instance.m_local : null;

        // ==================== 生命周期 ====================

        protected override void OnInit()
        {
            TableDic = Instance.m_tableDic;
        }

        // ==================== 公开接口 ====================

        /// <summary>
        /// 获取配置表
        /// </summary>
        public static T GetTable<T>() where T : UMConfigTableBase
        {
            Type key = typeof(T);

            if (TableDic.TryGetValue(key, out UMConfigTableBase table))
            {
                return table as T;
            }

            Debug.LogWarning($"[UMOConfig] Config table not found : {key.Name}");
            return null;
        }


        /// <summary>
        /// 添加配置表
        /// </summary>
        public static bool AddTable<T>(T table) where T : UMConfigTableBase
        {
            if (table == null)
            {
                Debug.LogError("[UMOConfig] Add Config Table Failed : table is null");
                return false;
            }

            Type tableType = typeof(T);

            if (TableDic.ContainsKey(tableType))
            {
                Debug.LogWarning($"[UMOConfig] Config table already exists : {tableType.Name}");
                return false;
            }

            TextAsset asset = Resources.Load<TextAsset>(table.LoadPath);

            if (asset == null)
            {
                Debug.LogError(
                    $"[UMOConfig] Config file not found : {table.LoadPath}"
                );

                return false;
            }

            table.Init(asset.text);

            TableDic.Add(tableType, table);

            // 多语言配置表自动创建并初始化 UMLocalCfg
            if (table is IUMLangTable langTable)
            {
                if (Instance.m_local == null)
                {
                    var go = new GameObject("UMLocalCfg");
                    go.transform.SetParent(Instance.transform);
                    Instance.m_local = go.AddComponent<UMLocalCfg>();
                }

                var options = langTable.GetOptions();
                var localDic = new Dictionary<string, Dictionary<string, string>>(options.Count);
                for (int i = 0; i < options.Count; i++)
                {
                    localDic[options[i].type] = langTable.GetContent(options[i].type);
                }
                Instance.m_local.SetLocalData(options, localDic);
            }

            return true;
        }

        /// <summary>
        /// 移除配置表
        /// </summary>
        public static bool RemoveTable<T>() where T : UMConfigTableBase
        {
            return TableDic.Remove(typeof(T));
        }

        /// <summary>
        /// 清空所有配置
        /// </summary>
        public static void Clear()
        {
            TableDic.Clear();
        }
    }
}