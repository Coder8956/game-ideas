using System;
using UnityEngine;

namespace UGU.Runtime
{
    /// <summary>
    /// 所有 Wrapper 的非泛型基类, 用于 PropertyDrawer 统一绘制
    /// </summary>
    [Serializable]
    public abstract class UGUWrapperBase
    {
    }

    /// <summary>
    /// UGUProperty 单属性包装基类
    ///
    /// 适用于仅需管理一个 UGUProperty&lt;T&gt; 的场景.
    /// 子类通过 Init() 传入初始值, 按需重写各方法.
    /// 值处理器在 Init() 时传入, 仅初始化时设置一次, 不允许外部访问修改.
    /// 大多数情况下可直接使用 <see cref="UGUPropertyWrapper{T}"/>.
    ///
    /// 容器场景请使用:
    /// - <see cref="UGUDictPropertyWrapper{TKey, T}"/> — 字典容器
    /// - <see cref="UGUListPropertyWrapper{T}"/>       — 列表容器
    /// </summary>
    [Serializable]
    public abstract class UGUPropertyWrapperBase<T> : UGUWrapperBase
    {
        /// <summary>
        /// 序列化值 — Unity 可序列化 (T 在子类中为具体类型)
        /// </summary>
        [SerializeField] private T m_value;

        /// <summary>
        /// 底层属性 (运行时, 不可被 Unity 序列化)
        /// </summary>
        [SerializeField] private UGUProperty<T> m_property;

        protected UGUProperty<T> Property
        {
            get => m_property;
            set => m_property = value;
        }

        /// <summary>
        /// 值处理器 — 仅在 Init 时设置, 不允许外部访问修改
        /// </summary>
        protected Func<T, T> ValueProcessor { get; set; }

        /// <summary>
        /// 初始化 — 以初始值创建底层 UGUProperty, 应用值处理器
        /// </summary>
        /// <param name="initialValue">初始值</param>
        /// <param name="valueProcessor">值处理器 (如 Clamp >= 0), 可选</param>
        public virtual void Init(T initialValue, Func<T, T> valueProcessor = null)
        {
            ValueProcessor = valueProcessor;
            m_value = initialValue;
            Property = new UGUProperty<T>(initialValue);
            Property.ValueProcessor = ValueProcessor;
        }

        /// <summary>
        /// 读 — 获取当前值
        /// </summary>
        public virtual T Read()
        {
            if (Property != null) return Property.Value;
            return m_value;
        }

        /// <summary>
        /// 改 — 修改值
        /// </summary>
        public virtual void Modify(T value)
        {
            m_value = value;
            if (Property != null) Property.Value = value;
        }

        /// <summary>
        /// 增量修改 — 在当前值基础上增减
        /// 子类可重写以自定义增量逻辑
        /// </summary>
        public virtual void IncModify(T delta)
        {
            try
            {
                decimal current = Convert.ToDecimal(Read());
                decimal d = Convert.ToDecimal(delta);
                Modify((T)Convert.ChangeType(current + d, typeof(T)));
            }
            catch (Exception)
            {
                Debug.LogWarning($"[UGUProperty] IncModify 不支持类型 {typeof(T).Name}");
            }
        }

        /// <summary>
        /// 监听 — 订阅值变化
        /// </summary>
        /// <param name="subscriber">回调, 参数为最新值</param>
        /// <param name="immediateUpdate">是否立即用当前值触发一次回调</param>
        public virtual void Subscribe(Action<T> subscriber, bool immediateUpdate = true)
        {
            if (Property == null) return;
            Property.Subscribe(subscriber, immediateUpdate);
        }

        /// <summary>
        /// 移除监听 — 取消订阅
        /// </summary>
        public virtual void Unsubscribe(Action<T> subscriber)
        {
            if (Property == null) return;
            Property.Unsubscribe(subscriber);
        }

        /// <summary>
        /// 监听变化 — 订阅新旧值变化
        /// 适合逻辑处理 (如比较变化前后的差值)
        /// </summary>
        /// <param name="subscriber">回调, 参数为 (旧值, 新值)</param>
        /// <param name="immediateUpdate">是否立即用当前值触发一次回调</param>
        public virtual void SubscribeChanged(Action<T, T> subscriber, bool immediateUpdate = true)
        {
            if (Property == null) return;
            Property.SubscribeChanged(subscriber, immediateUpdate);
        }

        /// <summary>
        /// 移除变化监听 — 取消订阅新旧值变化
        /// </summary>
        public virtual void UnsubscribeChanged(Action<T, T> subscriber)
        {
            if (Property == null) return;
            Property.UnsubscribeChanged(subscriber);
        }

        /// <summary>
        /// 静默修改 — 修改值但不触发通知
        /// 仍会经过 ValueProcessor 处理
        /// </summary>
        public virtual void SetValueWithoutNotify(T value)
        {
            m_value = value;
            if (Property != null) Property.SetValueWithoutNotify(value);
        }

        /// <summary>
        /// 清除全部监听
        /// </summary>
        public virtual void Clear()
        {
            if (Property == null) return;
            Property.Clear();
        }
    }

    /// <summary>
    /// 单属性包装默认实现 — 可直接实例化使用
    /// </summary>
    [Serializable]
    public class UGUPropertyWrapper<T> : UGUPropertyWrapperBase<T>
    {
    }
}