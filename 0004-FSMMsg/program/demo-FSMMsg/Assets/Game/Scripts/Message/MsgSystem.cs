using System;
using UnityEngine;

namespace UGU.Runtime.Message
{
    /// <summary>
    /// 消息系统的 MonoBehaviour 全局入口：提供全局单例 <see cref="Instance"/> 与核心分发器 <see cref="Dispatcher"/>。
    /// <para>特性：</para>
    /// <para>1. 惰性创建：首次访问 Instance 时自动在场景中创建本组件，无需手动挂载；</para>
    /// <para>2. 生命周期管理：Update 每帧派发延迟队列（PublishDeferred 的消息在此统一分发）；OnDestroy 时清空全部订阅并释放单例，避免跨场景残留回调；</para>
    /// <para>3. 静态便捷方法 Subscribe/Unsubscribe/Publish/PublishDeferred 直接转发给 Instance 的分发器；</para>
    /// <para>4. 支持"持有者订阅" Subscribe(owner, ...)：持有者（MonoBehaviour）被销毁后，回调自动跳过并在下次发布时自我清理，杜绝"回调已销毁组件"的报错。</para>
    /// 需要跨场景常驻时，请自行调用 DontDestroyOnLoad(Instance.gameObject)；不要在场景卸载阶段访问 Instance。
    /// </summary>
    public sealed class MsgSystem : MonoBehaviour
    {
        private static MsgSystem s_instance;

        /// <summary>全局单例；首次访问时自动创建。</summary>
        public static MsgSystem Instance
        {
            get
            {
                if (s_instance == null)
                {
                    var go = new GameObject("[MsgSystem]");
                    s_instance = go.AddComponent<MsgSystem>();
                }
                return s_instance;
            }
        }

        /// <summary>核心消息分发器；需要统计/清空等高级接口时直接使用它。</summary>
        public MsgDispatcher Dispatcher { get; } = new MsgDispatcher();

        // ====================== 静态便捷方法 ======================

        /// <summary>订阅字符串消息名。</summary>
        public static void Subscribe(string msg, Action<object> handler) => Instance.Dispatcher.Subscribe(msg, handler);

        /// <summary>订阅枚举消息名。</summary>
        public static void Subscribe(Enum msg, Action<object> handler) => Instance.Dispatcher.Subscribe(msg, handler);

        /// <summary>泛型订阅（强类型载荷，回调无需转型）。</summary>
        public static void Subscribe<T>(string msg, Action<T> handler) => Instance.Dispatcher.Subscribe(msg, handler);

        /// <summary>泛型订阅（枚举消息名）。</summary>
        public static void Subscribe<T>(Enum msg, Action<T> handler) => Instance.Dispatcher.Subscribe(msg, handler);

        /// <summary>退订字符串消息名。</summary>
        public static void Unsubscribe(string msg, Action<object> handler) => Instance.Dispatcher.Unsubscribe(msg, handler);

        /// <summary>退订枚举消息名。</summary>
        public static void Unsubscribe(Enum msg, Action<object> handler) => Instance.Dispatcher.Unsubscribe(msg, handler);

        /// <summary>退订泛型订阅。</summary>
        public static void Unsubscribe<T>(string msg, Action<T> handler) => Instance.Dispatcher.Unsubscribe(msg, handler);

        /// <summary>退订泛型订阅（枚举消息名）。</summary>
        public static void Unsubscribe<T>(Enum msg, Action<T> handler) => Instance.Dispatcher.Unsubscribe(msg, handler);

        /// <summary>立即发布消息，返回是否有回调被调用。</summary>
        public static bool Publish(string msg, object arg = null) => Instance.Dispatcher.Publish(msg, arg);

        /// <summary>立即发布枚举消息名。</summary>
        public static bool Publish(Enum msg, object arg = null) => Instance.Dispatcher.Publish(msg, arg);

        /// <summary>延迟发布：消息先入队，由 MsgSystem 在 Update 统一派发。</summary>
        public static void PublishDeferred(string msg, object arg = null) => Instance.Dispatcher.PublishDeferred(msg, arg);

        /// <summary>延迟发布（枚举消息名）。</summary>
        public static void PublishDeferred(Enum msg, object arg = null) => Instance.Dispatcher.PublishDeferred(msg, arg);

        // ====================== 持有者订阅 ======================

        /// <summary>
        /// 以组件为持有者的订阅：持有者被销毁后回调自动失效，并在下次发布时自我清理。
        /// <para>适合"长期全局消息 + 会销毁的监听组件"场景，避免已销毁组件被回调引发 MissingReferenceException。</para>
        /// 注意：持有者订阅无法单独手动退订（组件销毁即自动清理）；如需手动退订，请使用普通 Subscribe/Unsubscribe。
        /// 另注意：组件被禁用（非销毁）时回调仍会触发，请在 OnDisable 中手动退订或自行判断 enabled。
        /// </summary>
        public static void Subscribe(MonoBehaviour owner, string msg, Action<object> handler)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            var ownerRef = new WeakReference(owner);
            Action<object> wrapper = null;
            wrapper = arg =>
            {
                // Unity 的 == 对已销毁的组件返回 true：持有者存活才派发，否则自动退订
                var alive = ownerRef.Target as MonoBehaviour;
                if (alive == null)
                {
                    Instance.Dispatcher.Unsubscribe(msg, wrapper);
                    return;
                }
                handler(arg);
            };
            Instance.Dispatcher.Subscribe(msg, wrapper);
        }

        /// <summary>以组件为持有者的订阅（枚举消息名）。</summary>
        public static void Subscribe(MonoBehaviour owner, Enum msg, Action<object> handler)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg));
            Subscribe(owner, msg.ToString(), handler);
        }

        // ====================== Unity 生命周期 ======================

        /// <summary>每帧派发延迟队列中的消息。</summary>
        private void Update() => Dispatcher.DispatchQueued();

        /// <summary>组件销毁时清空全部订阅并释放单例引用。</summary>
        private void OnDestroy()
        {
            Dispatcher.Clear();
            if (s_instance == this) s_instance = null;
        }
    }
}
