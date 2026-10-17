using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGU.Runtime
{
    /// <summary>
    /// UGUProperty 非泛型基类, 用于 PropertyDrawer 统一绘制
    /// </summary>
    [Serializable]
    public abstract class UGUPropertyBase
    {
    }

    /// <summary>
    /// 数据绑定属性
    ///
    /// 支持:
    /// 1. 数据存储
    /// 2. 数据修改过滤
    /// 3. 最新值监听
    /// 4. 新旧值变化监听
    /// </summary>
    [Serializable]
    public class UGUProperty<T> : UGUPropertyBase
    {
        static UGUProperty()
        {
            Type t = typeof(T);
            if (!t.IsPrimitive && t != typeof(string) && t != typeof(decimal))
            {
                throw new InvalidOperationException(
                    $"UGUProperty<T> requires T to be a C# primitive type, string, or decimal. Got: {t.Name}.");
            }
        }

        [SerializeField] private T m_value;

        // 只关心当前值
        [NonSerialized] private readonly List<Action<T>> m_valueSubscribers = new();

        // 关心变化前后
        [NonSerialized] private readonly List<Action<T, T>> m_changedSubscribers = new();

        /// <summary>
        /// 数据修改处理
        /// 例如:
        /// HP限制0~100
        /// </summary>
        public Func<T, T> ValueProcessor { get; set; }

        public UGUProperty()
        {
            m_value = default;
        }

        public UGUProperty(T value)
        {
            m_value = value;
        }

        public T Value
        {
            get { return m_value; }
            set
            {
                T newValue = value;
                // 数据处理
                if (ValueProcessor != null)
                {
                    newValue = ValueProcessor.Invoke(value);
                }

                // 数据未变化
                if (EqualityComparer<T>.Default.Equals(m_value, newValue))
                {
                    return;
                }

                T oldValue = m_value;
                m_value = newValue;
                Notify(oldValue, newValue);
            }
        }

        /// <summary>
        /// 监听最新值
        /// 适合:
        /// UI刷新
        /// </summary>
        public void Subscribe(Action<T> subscriber, bool immediateUpdate = true)
        {
            if (subscriber == null)
                return;

            if (m_valueSubscribers.Contains(subscriber))
                return;

            m_valueSubscribers.Add(subscriber);

            if (immediateUpdate)
            {
                // 立刻刷新
                subscriber.Invoke(m_value);
            }
        }

        /// <summary>
        /// 监听变化
        /// 适合:
        /// 逻辑处理
        /// </summary>
        public void SubscribeChanged(Action<T, T> subscriber, bool immediateUpdate = true)
        {
            if (subscriber == null)
                return;

            if (m_changedSubscribers.Contains(subscriber))
                return;

            m_changedSubscribers.Add(subscriber);

            if (immediateUpdate)
            {
                // 初次绑定
                subscriber.Invoke(m_value, m_value);
            }
        }

        /// <summary>
        /// 移除最新值监听
        /// </summary>
        public void Unsubscribe(Action<T> subscriber)
        {
            if (subscriber == null)
                return;

            m_valueSubscribers.Remove(subscriber);
        }

        /// <summary>
        /// 移除变化监听
        /// </summary>
        public void UnsubscribeChanged(Action<T, T> subscriber)
        {
            if (subscriber == null)
                return;

            m_changedSubscribers.Remove(subscriber);
        }

        private void Notify(T oldValue, T newValue)
        {
            // 最新值监听
            for (int i = m_valueSubscribers.Count - 1; i >= 0; i--)
            {
                m_valueSubscribers[i]?.Invoke(newValue);
            }

            // 新旧值监听
            for (int i = m_changedSubscribers.Count - 1; i >= 0; i--)
            {
                m_changedSubscribers[i]?.Invoke(oldValue, newValue);
            }
        }

        /// <summary>
        /// 清除全部监听
        /// </summary>
        public void Clear()
        {
            m_valueSubscribers.Clear();
            m_changedSubscribers.Clear();
        }

        /// <summary>
        /// 修改数据但不触发通知
        /// 仍会经过 ValueProcessor 处理
        /// </summary>
        public void SetValueWithoutNotify(T value)
        {
            T newValue = value;
            if (ValueProcessor != null)
            {
                newValue = ValueProcessor.Invoke(value);
            }
            m_value = newValue;
        }

        public override string ToString()
        {
            return m_value?.ToString();
        }
    }
}
