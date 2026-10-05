using System;
using System.Collections.Generic;

namespace UGU.Runtime.Message
{
    /// <summary>
    /// 通用消息分发器（消息系统核心），纯 C# 实现、不依赖 UnityEngine，便于复用与单元测试。
    /// <para>特性：</para>
    /// <para>1. 字符串消息名路由，载荷为 object（可为 null）；订阅/退订/发布均可直接传枚举消息名（内部转字符串）；</para>
    /// <para>2. 支持泛型订阅 Subscribe&lt;T&gt;：回调直接收到强类型载荷，无需手动转型；</para>
    /// <para>3. 同一回调对同一消息重复订阅会被去重；退订按委托实例精确匹配（需传订阅时同一委托）；</para>
    /// <para>4. 发布时对回调列表做快照迭代：回调内再次订阅/退订不会引发异常；</para>
    /// <para>5. 支持延迟发布 PublishDeferred：消息先入队，由外部在安全时机调用 DispatchQueued 统一派发；</para>
    /// <para>6. 提供按消息清空、全局清空与订阅数统计，便于调试。</para>
    /// 典型用法：Subscribe("OnPlayerDead", handler) → Publish("OnPlayerDead", deadPlayer)。
    /// 注意：所有接口默认在主线程（游戏逻辑线程）调用；跨线程发布请自行加锁，或在安全时机用延迟队列转发。
    /// </summary>
    public sealed class MsgDispatcher
    {
        /// <summary>消息名 -> 订阅回调列表。</summary>
        private readonly Dictionary<string, List<Action<object>>> m_handlers = new Dictionary<string, List<Action<object>>>();

        /// <summary>泛型回调 -> 适配器回调 的映射：把强类型回调包装成 object 回调，同时支持按原回调精确退订。</summary>
        private readonly Dictionary<Delegate, Action<object>> m_typedAdapters = new Dictionary<Delegate, Action<object>>();

        /// <summary>延迟发布队列（PublishDeferred 暂存，DispatchQueued 统一派发）。</summary>
        private readonly List<QueuedMsg> m_deferred = new List<QueuedMsg>();

        /// <summary>全部消息的订阅回调总数（调试用）。</summary>
        public int TotalHandlerCount
        {
            get
            {
                int total = 0;
                foreach (var list in m_handlers.Values) total += list.Count;
                return total;
            }
        }

        /// <summary>延迟发布队列中暂存的消息数。</summary>
        public int QueuedCount => m_deferred.Count;

        // ====================== 订阅 ======================

        /// <summary>
        /// 订阅字符串消息名。同一回调对同一消息重复订阅会被去重（只触发一次）。
        /// </summary>
        public void Subscribe(string msg, Action<object> handler)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            if (!m_handlers.TryGetValue(msg, out var list))
            {
                list = new List<Action<object>>();
                m_handlers[msg] = list;
            }

            if (!list.Contains(handler)) list.Add(handler);
        }

        /// <summary>订阅枚举消息名（内部转为字符串，与 FSM 的枚举风格保持一致）。</summary>
        public void Subscribe(Enum msg, Action<object> handler)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            Subscribe(msg.ToString(), handler);
        }

        /// <summary>
        /// 泛型订阅：回调直接收到强类型载荷，无需手动转型。
        /// 注意：发布时的载荷类型必须与 T 一致；载荷为 null 或子类型时请使用普通订阅自行处理。
        /// </summary>
        public void Subscribe<T>(string msg, Action<T> handler)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            Subscribe(msg, GetOrCreateAdapter(handler));
        }

        /// <summary>泛型订阅（枚举消息名）。</summary>
        public void Subscribe<T>(Enum msg, Action<T> handler)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            Subscribe<T>(msg.ToString(), handler);
        }

        // ====================== 退订 ======================

        /// <summary>退订字符串消息名。需与订阅时传入同一委托实例；未订阅时静默忽略。</summary>
        public void Unsubscribe(string msg, Action<object> handler)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            if (!m_handlers.TryGetValue(msg, out var list)) return;
            list.Remove(handler);
            if (list.Count == 0) m_handlers.Remove(msg);
        }

        /// <summary>退订枚举消息名。</summary>
        public void Unsubscribe(Enum msg, Action<object> handler)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            Unsubscribe(msg.ToString(), handler);
        }

        /// <summary>退订泛型订阅（传与订阅时相同的委托实例）。</summary>
        public void Unsubscribe<T>(string msg, Action<T> handler)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            if (!m_typedAdapters.TryGetValue(handler, out var adapter)) return;
            Unsubscribe(msg, adapter);

            // 适配器若已不在任何消息的订阅列表中，则移除缓存，避免长时间持有用户回调（防内存泄漏）
            if (!IsAdapterInUse(adapter)) m_typedAdapters.Remove(handler);
        }

        /// <summary>退订泛型订阅（枚举消息名）。</summary>
        public void Unsubscribe<T>(Enum msg, Action<T> handler)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            Unsubscribe<T>(msg.ToString(), handler);
        }

        // ====================== 发布 ======================

        /// <summary>
        /// 立即发布消息并同步调用全部订阅回调。
        /// <para>返回是否有回调被调用（可用于判断"是否有人关心这条消息"）。</para>
        /// </summary>
        public bool Publish(string msg, object arg = null)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            if (!m_handlers.TryGetValue(msg, out var list) || list.Count == 0) return false;

            // 快照迭代：回调内再次订阅/退订不会修改正在遍历的列表，避免抛异常
            var snapshot = new List<Action<object>>(list);
            for (int i = 0; i < snapshot.Count; i++) snapshot[i](arg);
            return true;
        }

        /// <summary>立即发布枚举消息名。</summary>
        public bool Publish(Enum msg, object arg = null)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            return Publish(msg.ToString(), arg);
        }

        /// <summary>把消息放入延迟队列，不立即派发；由外部在安全时机调用 <see cref="DispatchQueued"/> 统一派发。</summary>
        public void PublishDeferred(string msg, object arg = null)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            m_deferred.Add(new QueuedMsg { Name = msg, Arg = arg });
        }

        /// <summary>把枚举消息名放入延迟队列。</summary>
        public void PublishDeferred(Enum msg, object arg = null)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            PublishDeferred(msg.ToString(), arg);
        }

        // ====================== 延迟队列派发 ======================

        /// <summary>
        /// 派发延迟队列中的全部消息。
        /// <para>派发过程中新入队的消息会留到下一次调用，避免"派发中继续派发"的无限递归。</para>
        /// </summary>
        public void DispatchQueued()
        {
            if (m_deferred.Count == 0) return;

            var snapshot = new List<QueuedMsg>(m_deferred);
            m_deferred.Clear();
            for (int i = 0; i < snapshot.Count; i++) Publish(snapshot[i].Name, snapshot[i].Arg);
        }

        // ====================== 清理与统计 ======================

        /// <summary>清空指定消息的全部订阅。</summary>
        public void Clear(string msg)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            m_handlers.Remove(msg);
        }

        /// <summary>清空全部消息的订阅与延迟队列（场景切换/系统销毁时调用）。</summary>
        public void Clear()
        {
            m_handlers.Clear();
            m_typedAdapters.Clear();
            m_deferred.Clear();
        }

        /// <summary>指定消息当前的回调数量。</summary>
        public int HandlerCount(string msg)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            return m_handlers.TryGetValue(msg, out var list) ? list.Count : 0;
        }

        /// <summary>指定消息是否已有订阅者。</summary>
        public bool HasSubscribers(string msg) => HandlerCount(msg) > 0;

        /// <summary>泛型回调 -> 适配器回调（不存在则创建并缓存）。</summary>
        private Action<object> GetOrCreateAdapter<T>(Action<T> handler)
        {
            if (m_typedAdapters.TryGetValue(handler, out var adapter)) return adapter;

            adapter = arg => handler((T)arg);
            m_typedAdapters[handler] = adapter;
            return adapter;
        }

        /// <summary>适配器回调是否仍被某个消息的订阅列表引用。</summary>
        private bool IsAdapterInUse(Action<object> adapter)
        {
            foreach (var list in m_handlers.Values)
            {
                if (list.Contains(adapter)) return true;
            }
            return false;
        }

        /// <summary>延迟队列中的一条消息。</summary>
        private struct QueuedMsg
        {
            public string Name;
            public object Arg;
        }
    }
}
