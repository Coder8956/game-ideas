using System;
using UnityEngine.Events;

namespace UMiniFramework.Runtime
{
    /// <summary>
    /// 事件侦听类型
    /// </summary>
    public enum UMListenType
    {
        /// <summary>
        /// 侦听一次
        /// </summary>
        Once,

        /// <summary>
        /// 持续侦听
        /// </summary>
        Persistent
    }

    public sealed class UMEventListener
    {
        // ==================== 公开只读字段 ====================

        public readonly string EventTag;
        public readonly UMListenType ListenType;

        // ==================== 私有字段 ====================

        private readonly UnityAction<UMEventContentBase> m_eventHandler;

        // ==================== 构造 ====================

        public UMEventListener(string eventTag, UnityAction<UMEventContentBase> eventHandler,
            UMListenType listenType = UMListenType.Persistent)
        {
            EventTag = eventTag;
            ListenType = listenType;
            m_eventHandler = eventHandler;
            if (m_eventHandler == null)
            {
                throw new ArgumentNullException(nameof(eventHandler), "The parameter cannot be null");
            }
        }

        // ==================== 公开接口 ====================

        internal void HandleEvent(UMEventContentBase content)
        {
            m_eventHandler.Invoke(content);
        }
    }
}
