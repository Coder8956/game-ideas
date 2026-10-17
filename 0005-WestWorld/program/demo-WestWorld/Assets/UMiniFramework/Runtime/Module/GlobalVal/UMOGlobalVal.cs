using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMiniFramework.Runtime
{
    /// <summary>
    /// 全局变量管理器
    /// 提供运行时键值对的存取：
    /// 1. 持有私有 Dictionary&lt;string, object&gt; 字典
    /// 2. 通过静态 API 对外暴露增删改查方法
    /// 3. 通过 Inspector 可查看字典内容
    /// </summary>
    public class UMOGlobalVal : UMMonoSingletonBase<UMOGlobalVal>
    {
        // ==================== 私有字段（运行时状态） ====================

        private Dictionary<string, object> m_globalValDic;

        // ==================== 生命周期 ====================

        protected override void OnInit()
        {
            m_globalValDic = new Dictionary<string, object>();
        }

        // ==================== 公开接口 ====================

        /// <summary>
        /// 设置全局变量（已存在则覆盖）
        /// </summary>
        public static void Set(string key, object value)
        {
            if (string.IsNullOrEmpty(key))
            {
                Debug.LogWarning("[UMOGlobalVal] Key 不能为空。");
                return;
            }

            Instance.m_globalValDic[key] = value;
        }

        /// <summary>
        /// 获取全局变量
        /// </summary>
        public static T Get<T>(string key)
        {
            if (!Instance.m_globalValDic.TryGetValue(key, out var value))
            {
                Debug.LogWarning($"[UMOGlobalVal] 未找到 Key: {key}");
                return default;
            }

            if (value is T typedValue)
                return typedValue;

            Debug.LogWarning($"[UMOGlobalVal] Key '{key}' 的值类型不匹配，期望 {typeof(T).Name}，实际 {value?.GetType().Name}。");
            return default;
        }

        /// <summary>
        /// 获取全局变量（无装箱，返回 object）
        /// </summary>
        public static object Get(string key)
        {
            if (!Instance.m_globalValDic.TryGetValue(key, out var value))
            {
                Debug.LogWarning($"[UMOGlobalVal] 未找到 Key: {key}");
                return null;
            }

            return value;
        }

        /// <summary>
        /// 尝试获取全局变量
        /// </summary>
        public static bool TryGet<T>(string key, out T value)
        {
            if (Instance.m_globalValDic.TryGetValue(key, out var rawValue) && rawValue is T typedValue)
            {
                value = typedValue;
                return true;
            }

            value = default;
            return false;
        }

        /// <summary>
        /// 移除全局变量
        /// </summary>
        public static bool Remove(string key)
        {
            return Instance.m_globalValDic.Remove(key);
        }

        /// <summary>
        /// 是否存在指定 Key
        /// </summary>
        public static bool Contains(string key)
        {
            return Instance.m_globalValDic.ContainsKey(key);
        }

        /// <summary>
        /// 清空所有全局变量
        /// </summary>
        public static void Clear()
        {
            Instance.m_globalValDic.Clear();
        }
    }
}
