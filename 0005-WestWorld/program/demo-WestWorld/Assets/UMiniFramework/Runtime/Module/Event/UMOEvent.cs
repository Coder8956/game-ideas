using System;
using System.Collections.Generic;

namespace UMiniFramework.Runtime
{
    public class UMOEvent : UMMonoSingletonBase<UMOEvent>
    {
        // ==================== 私有字段（运行时状态） ====================

        private Dictionary<string, List<UMEventListener>> m_eventDic;

        // ==================== 生命周期 ====================

        protected override void OnInit()
        {
            m_eventDic = new Dictionary<string, List<UMEventListener>>();
        }

        // ==================== 公开接口 ====================

        /// <summary>
        /// 添加事件标签
        /// </summary>
        public static void AddEvent(string eventTag)
        {
            if (Instance == null) return;
            if (Instance.m_eventDic.ContainsKey(eventTag)) return;
            Instance.m_eventDic.Add(eventTag, new List<UMEventListener>());
        }

        /// <summary>
        /// 添加事件侦听器
        /// </summary>
        public static void AddListener(UMEventListener listener)
        {
            if (listener == null)
            {
                throw new ArgumentNullException(nameof(listener), "The parameter cannot be null");
            }

            if (Instance == null) return;
            if (!Instance.m_eventDic.TryGetValue(listener.EventTag, out var listeners))
            {
                return;
            }

            if (listeners.Contains(listener))
            {
                return;
            }

            listeners.Add(listener);
        }

        /// <summary>
        /// 派发事件
        /// </summary>
        public static void Dispatch(string eventTag, UMEventContentBase content = null)
        {
            if (Instance == null) return;
            if (!Instance.m_eventDic.TryGetValue(eventTag, out var listeners))
            {
                return;
            }

            for (var i = listeners.Count - 1; i >= 0; i--)
            {
                UMEventListener listener = listeners[i];
                listener.HandleEvent(content);
                if (listener.ListenType == UMListenType.Once)
                {
                    listeners.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// 移除事件侦听器
        /// </summary>
        public static void RemoveListener(UMEventListener listener)
        {
            if (listener == null) return;
            if (Instance == null) return;
            if (Instance.m_eventDic.TryGetValue(listener.EventTag, out var listeners))
            {
                listeners.Remove(listener);
            }
        }

        /// <summary>
        /// 移除所有事件侦听器
        /// </summary>
        public static void RemoveAllListener()
        {
            if (Instance == null) return;
            foreach (var listeners in Instance.m_eventDic.Values)
            {
                listeners.Clear();
            }
        }

        /// <summary>
        /// 移除指定事件标签的所有侦听器
        /// </summary>
        public static void RemoveAllListenerByEventTag(string eventTag)
        {
            if (Instance == null) return;
            if (Instance.m_eventDic.TryGetValue(eventTag, out var listeners))
            {
                listeners.Clear();
            }
        }
    }
}