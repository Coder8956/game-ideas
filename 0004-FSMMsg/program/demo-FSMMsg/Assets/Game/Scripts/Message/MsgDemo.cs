using UnityEngine;

namespace UGU.Runtime.Message
{
    /// <summary>
    /// 消息系统使用示例（演示用，可删除）。挂到任意物体上即可观察订阅/发布/延迟发布/持有者订阅的完整用法。
    /// <para>演示内容：</para>
    /// <para>1. 普通订阅：字符串消息名 + object 载荷，回调内自行转型；</para>
    /// <para>2. 泛型订阅 Subscribe&lt;T&gt;：回调直接收到强类型载荷，无需转型；</para>
    /// <para>3. 枚举消息名：与 FSM 的枚举风格保持一致；</para>
    /// <para>4. 延迟发布 PublishDeferred：消息先入队，由 MsgSystem 在 Update 统一派发；</para>
    /// <para>5. 持有者订阅：以本组件为持有者，组件销毁后回调自动失效。</para>
    /// 运行后在 Inspector 勾选"自动发布"或按空格键，即可在 Console 观察输出。
    /// 规范建议：订阅写在 OnEnable、退订写在 OnDisable（组件被禁用时也不残留回调）。
    /// </summary>
    public class MsgDemo : MonoBehaviour
    {
        /// <summary>示例消息枚举。</summary>
        private enum DemoMsg
        {
            /// <summary>延迟发布示例消息（每 30 帧一条）。</summary>
            OnDeferredTick,
        }

        [Header("演示开关")]
        [Tooltip("是否自动发布消息（每 30 帧一条）")]
        [SerializeField]
        private bool m_autoPublish = true;

        [Tooltip("手动发布消息的按键（空格）")]
        [SerializeField]
        private KeyCode m_publishKey = KeyCode.Space;

        /// <summary>累计帧数，作为消息载荷演示。</summary>
        private int m_frameCount;

        private void OnEnable()
        {
            // 1. 普通订阅（字符串消息名 + object 载荷）
            MsgSystem.Subscribe("OnTick", OnTickMessage);

            // 2. 泛型订阅（强类型载荷，无需转型）
            MsgSystem.Subscribe<int>("OnTick", OnTickCount);

            // 3. 枚举消息名
            MsgSystem.Subscribe(DemoMsg.OnDeferredTick, OnDeferredMessage);

            // 4. 持有者订阅：以本组件为持有者，组件销毁后由系统自动清理
            MsgSystem.Subscribe(this, "OnTick", OnOwnerTickMessage);
        }

        private void OnDisable()
        {
            // 与订阅一一对应的退订（持有者订阅无需手动退订）
            MsgSystem.Unsubscribe("OnTick", OnTickMessage);
            MsgSystem.Unsubscribe<int>("OnTick", OnTickCount);
            MsgSystem.Unsubscribe(DemoMsg.OnDeferredTick, OnDeferredMessage);
        }

        private void Update()
        {
            m_frameCount++;

            if (m_autoPublish && m_frameCount % 30 == 0 || Input.GetKeyDown(m_publishKey))
            {
                // 立即发布 + 延迟发布（延迟消息由 MsgSystem 在本帧 Update 末尾统一派发）
                MsgSystem.Publish("OnTick", m_frameCount);
                MsgSystem.PublishDeferred(DemoMsg.OnDeferredTick);
            }
        }

        /// <summary>普通订阅回调：object 载荷自行转型。</summary>
        private void OnTickMessage(object arg)
        {
            Debug.Log($"[MsgDemo] 普通订阅收到 OnTick：frame={arg}", this);
        }

        /// <summary>泛型订阅回调：直接拿到 int，无需转型。</summary>
        private void OnTickCount(int count)
        {
            Debug.Log($"[MsgDemo] 泛型订阅收到 OnTick：count={count}", this);
        }

        /// <summary>延迟消息回调（由 MsgSystem.Update 派发）。</summary>
        private void OnDeferredMessage(object arg)
        {
            Debug.Log("[MsgDemo] 延迟消息 OnDeferredTick 已派发", this);
        }

        /// <summary>持有者订阅回调。</summary>
        private void OnOwnerTickMessage(object arg)
        {
            Debug.Log($"[MsgDemo] 持有者订阅收到 OnTick：frame={arg}", this);
        }
    }
}
