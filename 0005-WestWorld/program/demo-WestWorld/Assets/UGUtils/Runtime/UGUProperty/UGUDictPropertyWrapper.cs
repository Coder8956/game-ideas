using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGU.Runtime
{
    /// <summary>
    /// UGUProperty 字典容器包装基类
    ///
    /// 适用于以 key 索引多个 UGUProperty&lt;T&gt; 的场景
    /// (如 DPPlayerDataSys.m_REDic).
    ///
    /// 子类通过 Init() 初始化 Dict, 重写 OnValueChanged() 即可获得持久化回调.
    /// 值处理器在 Init() 时传入, 仅初始化时设置一次, 不允许外部访问修改.
    /// 大多数情况下可直接使用 <see cref="UGUDictPropertyWrapper{TKey, T}"/>.
    /// </summary>
    [Serializable]
    public abstract class UGUDictPropertyWrapperBase<TKey, T> : UGUWrapperBase
    {
        /// <summary>
        /// 底层字典容器 — Dictionary 不可被 Unity 序列化, 运行时通过反射读取
        /// </summary>
        protected Dictionary<TKey, UGUProperty<T>> Dict { get; set; }

        /// <summary>
        /// 值处理器 — 仅在 Init 时设置, 不允许外部访问修改
        /// </summary>
        protected Func<T, T> ValueProcessor { get; set; }

        /// <summary>
        /// 初始化 — 传入原始字典, 逐条读值创建内部 UGUProperty, 应用值处理器
        /// </summary>
        /// <param name="dict">原始字典</param>
        /// <param name="valueProcessor">值处理器 (如 Clamp >= 0), 可选</param>
        public virtual void Init(Dictionary<TKey, T> dict, Func<T, T> valueProcessor = null)
        {
            ValueProcessor = valueProcessor;
            Dict = new Dictionary<TKey, UGUProperty<T>>();
            foreach (var KV in dict)
            {
                var prop = new UGUProperty<T>(KV.Value);
                prop.ValueProcessor = ValueProcessor;
                Dict[KV.Key] = prop;
            }
        }

        /// <summary>
        /// 值变化时的持久化回调
        /// 子类重写以将变更写回存档 (如 Data.REDic[key] = newValue)
        /// </summary>
        protected virtual void OnValueChanged(TKey key, T newValue)
        {
        }

        /// <summary>
        /// 注册条目 — 创建 UGUProperty, 应用 ValueProcessor, 加入 Dict
        /// </summary>
        public virtual void Register(TKey key, T initVal)
        {
            var prop = new UGUProperty<T>(initVal);
            prop.ValueProcessor = ValueProcessor;
            prop.Subscribe((newVal) => OnValueChanged(key, newVal), false);
            Dict[key] = prop;
        }

        /// <summary>
        /// 注销条目 — 清除监听并从 Dict 移除
        /// </summary>
        public virtual void Unregister(TKey key)
        {
            if (Dict.TryGetValue(key, out var prop))
            {
                prop.Clear();
                Dict.Remove(key);
            }
        }

        /// <summary>
        /// 是否包含指定 key
        /// </summary>
        public virtual bool Contains(TKey key)
        {
            return Dict.ContainsKey(key);
        }

        /// <summary>
        /// 读 — 获取指定 key 的当前值
        /// key 不存在时返回 default 并 LogWarning
        /// </summary>
        public virtual T Read(TKey key)
        {
            if (!Dict.TryGetValue(key, out var prop))
            {
                Debug.LogWarning(
                    $"{GetType().Name}: Read — unknown key '{key}'");
                return default;
            }

            return prop.Value;
        }

        /// <summary>
        /// 改 — 修改指定 key 的值
        /// key 不存在时 LogWarning
        /// </summary>
        public virtual void Modify(TKey key, T value)
        {
            if (!Dict.TryGetValue(key, out var prop))
            {
                Debug.LogWarning(
                    $"{GetType().Name}: Modify — unknown key '{key}'");
                return;
            }

            prop.Value = value;
        }

        /// <summary>
        /// 增量修改 — 在指定 key 的当前值基础上增减
        /// key 不存在时 LogWarning
        /// 子类可重写以自定义增量逻辑
        /// </summary>
        public virtual void IncModify(TKey key, T delta)
        {
            if (!Contains(key))
            {
                Debug.LogWarning(
                    $"{GetType().Name}: IncModify — unknown key '{key}'");
                return;
            }

            decimal current = Convert.ToDecimal(Read(key));
            decimal d = Convert.ToDecimal(delta);
            Modify(key, (T)Convert.ChangeType(current + d, typeof(T)));
        }

        /// <summary>
        /// 监听 — 订阅指定 key 的值变化
        /// key 不存在时 LogWarning
        /// </summary>
        public virtual void Subscribe(TKey key, Action<T> subscriber, bool immediateUpdate = true)
        {
            if (!Dict.TryGetValue(key, out var prop))
            {
                Debug.LogWarning(
                    $"{GetType().Name}: Subscribe — unknown key '{key}'");
                return;
            }

            prop.Subscribe(subscriber, immediateUpdate);
        }

        /// <summary>
        /// 移除监听 — 取消订阅指定 key
        /// key 不存在时静默返回 (适配 OnDestroy 清理场景)
        /// </summary>
        public virtual void Unsubscribe(TKey key, Action<T> subscriber)
        {
            if (Dict == null) return;

            if (!Dict.TryGetValue(key, out var prop))
            {
                return;
            }

            prop.Unsubscribe(subscriber);
        }

        /// <summary>
        /// 监听变化 — 订阅指定 key 的新旧值变化
        /// key 不存在时 LogWarning
        /// </summary>
        public virtual void SubscribeChanged(TKey key, Action<T, T> subscriber, bool immediateUpdate = true)
        {
            if (!Dict.TryGetValue(key, out var prop))
            {
                Debug.LogWarning(
                    $"{GetType().Name}: SubscribeChanged — unknown key '{key}'");
                return;
            }

            prop.SubscribeChanged(subscriber, immediateUpdate);
        }

        /// <summary>
        /// 移除变化监听 — 取消订阅指定 key 的新旧值变化
        /// key 不存在时静默返回
        /// </summary>
        public virtual void UnsubscribeChanged(TKey key, Action<T, T> subscriber)
        {
            if (Dict == null) return;

            if (!Dict.TryGetValue(key, out var prop))
            {
                return;
            }

            prop.UnsubscribeChanged(subscriber);
        }

        /// <summary>
        /// 静默修改 — 修改值但不触发通知
        /// key 不存在时 LogWarning
        /// </summary>
        public virtual void SetValueWithoutNotify(TKey key, T value)
        {
            if (!Dict.TryGetValue(key, out var prop))
            {
                Debug.LogWarning(
                    $"{GetType().Name}: SetValueWithoutNotify — unknown key '{key}'");
                return;
            }

            prop.SetValueWithoutNotify(value);
        }

        /// <summary>
        /// 清除指定 key 的全部监听
        /// </summary>
        public virtual void Clear(TKey key)
        {
            if (Dict.TryGetValue(key, out var prop))
            {
                prop.Clear();
            }
        }

        /// <summary>
        /// 清除所有条目的全部监听并清空 Dict
        /// </summary>
        public virtual void ClearAll()
        {
            if (Dict == null) return;

            foreach (var KV in Dict)
            {
                KV.Value.Clear();
            }

            Dict.Clear();
        }
    }

    /// <summary>
    /// 字典容器包装默认实现 — 可直接实例化使用
    /// </summary>
    [Serializable]
    public class UGUDictPropertyWrapper<TKey, T> : UGUDictPropertyWrapperBase<TKey, T>
    {
    }
}