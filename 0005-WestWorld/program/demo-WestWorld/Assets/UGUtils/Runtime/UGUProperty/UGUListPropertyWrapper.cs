using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGU.Runtime
{
    /// <summary>
    /// UGUProperty 列表容器包装基类
    ///
    /// 适用于以 index 索引多个 UGUProperty&lt;T&gt; 的场景.
    ///
    /// 子类通过 Init() 初始化 List, 重写 OnValueChanged() 即可获得持久化回调.
    /// 值处理器在 Init() 时传入, 仅初始化时设置一次, 不允许外部访问修改.
    /// 大多数情况下可直接使用 <see cref="UGUListPropertyWrapper{T}"/>.
    /// </summary>
    [Serializable]
    public abstract class UGUListPropertyWrapperBase<T> : UGUWrapperBase
    {
        /// <summary>
        /// 序列化值列表 — Unity 可序列化 (T 在子类中为具体类型)
        /// </summary>
        [SerializeField] private List<T> m_values;

        /// <summary>
        /// 底层列表容器 (运行时, 不可被 Unity 序列化)
        /// </summary>
        [SerializeField] private List<UGUProperty<T>> m_list;

        protected List<UGUProperty<T>> List
        {
            get => m_list;
            set => m_list = value;
        }

        /// <summary>
        /// 值处理器 — 仅在 Init 时设置, 不允许外部访问修改
        /// </summary>
        protected Func<T, T> ValueProcessor { get; set; }

        /// <summary>
        /// 初始化 — 传入原始列表, 逐条读值创建内部 UGUProperty, 应用值处理器
        /// </summary>
        /// <param name="list">原始列表</param>
        /// <param name="valueProcessor">值处理器 (如 Clamp >= 0), 可选</param>
        public virtual void Init(List<T> list, Func<T, T> valueProcessor = null)
        {
            ValueProcessor = valueProcessor;
            m_values = new List<T>(list);
            List = new List<UGUProperty<T>>();
            foreach (var val in list)
            {
                var prop = new UGUProperty<T>(val);
                prop.ValueProcessor = ValueProcessor;
                List.Add(prop);
            }
        }

        /// <summary>
        /// 值变化时的持久化回调
        /// 子类重写以将变更写回存档
        /// </summary>
        protected virtual void OnValueChanged(int index, T newValue)
        {
        }

        /// <summary>
        /// 注册条目 — 创建 UGUProperty, 应用 ValueProcessor, 订阅持久化, 追加到 List
        /// </summary>
        /// <returns>新条目的索引</returns>
        public virtual int Register(T initVal)
        {
            if (m_values == null) m_values = new List<T>();
            m_values.Add(initVal);

            if (List == null) List = new List<UGUProperty<T>>();
            var prop = new UGUProperty<T>(initVal);
            prop.ValueProcessor = ValueProcessor;
            int index = List.Count;
            prop.Subscribe((newVal) => OnValueChanged(index, newVal), false);
            List.Add(prop);
            return index;
        }

        /// <summary>
        /// 注销条目 — 清除监听并从 List 移除
        /// 注意: 移除后后续元素索引会前移
        /// </summary>
        public virtual void Unregister(int index)
        {
            if (index < 0 || index >= Count)
            {
                Debug.LogWarning(
                    $"{GetType().Name}: Unregister — index out of range {index}");
                return;
            }

            if (List != null)
            {
                List[index].Clear();
                List.RemoveAt(index);
            }

            if (m_values != null && index < m_values.Count)
                m_values.RemoveAt(index);
        }

        /// <summary>
        /// 条目数量
        /// </summary>
        public virtual int Count => List != null ? List.Count : (m_values?.Count ?? 0);

        /// <summary>
        /// 读 — 获取指定 index 的当前值
        /// 越界时返回 default 并 LogWarning
        /// </summary>
        public virtual T Read(int index)
        {
            if (List != null)
            {
                if (!TryGet(index, out var prop))
                    return default;
                return prop.Value;
            }

            if (m_values != null && index >= 0 && index < m_values.Count)
                return m_values[index];

            return default;
        }

        /// <summary>
        /// 改 — 修改指定 index 的值
        /// 越界时 LogWarning
        /// </summary>
        public virtual void Modify(int index, T value)
        {
            if (List != null && TryGet(index, out var prop))
            {
                prop.Value = value;
                if (m_values != null && index < m_values.Count)
                    m_values[index] = prop.Value;
            }
            else if (m_values != null && index >= 0 && index < m_values.Count)
            {
                m_values[index] = value;
            }
        }

        /// <summary>
        /// 增量修改 — 在指定 index 的当前值基础上增减
        /// 子类可重写以自定义增量逻辑
        /// </summary>
        public virtual void IncModify(int index, T delta)
        {
            decimal current = Convert.ToDecimal(Read(index));
            decimal d = Convert.ToDecimal(delta);
            Modify(index, (T)Convert.ChangeType(current + d, typeof(T)));
        }

        /// <summary>
        /// 监听 — 订阅指定 index 的值变化
        /// 越界时 LogWarning
        /// </summary>
        public virtual void Subscribe(int index, Action<T> subscriber, bool immediateUpdate = true)
        {
            if (!TryGet(index, out var prop))
            {
                return;
            }

            prop.Subscribe(subscriber, immediateUpdate);
        }

        /// <summary>
        /// 移除监听 — 取消订阅指定 index
        /// 越界时静默返回 (适配 OnDestroy 清理场景)
        /// </summary>
        public virtual void Unsubscribe(int index, Action<T> subscriber)
        {
            if (List == null) return;

            if (index < 0 || index >= List.Count)
            {
                return;
            }

            List[index].Unsubscribe(subscriber);
        }

        /// <summary>
        /// 监听变化 — 订阅指定 index 的新旧值变化
        /// 越界时 LogWarning
        /// </summary>
        public virtual void SubscribeChanged(int index, Action<T, T> subscriber, bool immediateUpdate = true)
        {
            if (!TryGet(index, out var prop))
            {
                return;
            }

            prop.SubscribeChanged(subscriber, immediateUpdate);
        }

        /// <summary>
        /// 移除变化监听 — 取消订阅指定 index 的新旧值变化
        /// 越界时静默返回
        /// </summary>
        public virtual void UnsubscribeChanged(int index, Action<T, T> subscriber)
        {
            if (List == null) return;

            if (index < 0 || index >= List.Count)
            {
                return;
            }

            List[index].UnsubscribeChanged(subscriber);
        }

        /// <summary>
        /// 静默修改 — 修改值但不触发通知
        /// 越界时 LogWarning
        /// </summary>
        public virtual void SetValueWithoutNotify(int index, T value)
        {
            if (List != null && TryGet(index, out var prop))
            {
                prop.SetValueWithoutNotify(value);
                if (m_values != null && index < m_values.Count)
                    m_values[index] = prop.Value;
            }
            else if (m_values != null && index >= 0 && index < m_values.Count)
            {
                m_values[index] = value;
            }
        }

        /// <summary>
        /// 清除指定 index 的全部监听
        /// </summary>
        public virtual void Clear(int index)
        {
            if (List != null && index >= 0 && index < List.Count)
            {
                List[index].Clear();
            }
        }

        /// <summary>
        /// 清除所有条目的全部监听并清空 List
        /// </summary>
        public virtual void ClearAll()
        {
            if (List != null)
            {
                foreach (var prop in List)
                {
                    prop.Clear();
                }

                List.Clear();
            }

            m_values?.Clear();
        }

        /// <summary>
        /// 尝试获取指定 index 的 UGUProperty
        /// 越界时 LogWarning 并返回 false
        /// </summary>
        protected bool TryGet(int index, out UGUProperty<T> prop)
        {
            if (List != null && index >= 0 && index < List.Count)
            {
                prop = List[index];
                return true;
            }

            Debug.LogWarning(
                $"{GetType().Name}: index out of range {index}");
            prop = null;
            return false;
        }
    }

    /// <summary>
    /// 列表容器包装默认实现 — 可直接实例化使用
    /// </summary>
    [Serializable]
    public class UGUListPropertyWrapper<T> : UGUListPropertyWrapperBase<T>
    {
    }
}