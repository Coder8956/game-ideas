using System;
using UnityEngine;

namespace UGU.Runtime.FSM
{
    /// <summary>
    /// FSM 的 MonoBehaviour 驱动器：把 Unity 的 Update / FixedUpdate / LateUpdate 生命周期转发给状态机。
    /// <para>子类在 Start（或 Awake）中调用 <see cref="Machine"/> 注册状态与转移，再调用 <see cref="StartMachine"/> 启动。</para>
    /// 状态机以本组件自身作为 Context，状态内通过 <see cref="FSMState.Context"/> 即可访问持有者。
    /// 注意：子类若重写 Update / FixedUpdate / LateUpdate，请记得调用 base 的对应方法。
    /// </summary>
    public abstract class FSMMachineBehaviour : MonoBehaviour
    {
        private FSMMachine m_machine;

        /// <summary>本组件持有的状态机；首次访问时惰性创建，Context 为本组件。</summary>
        public FSMMachine Machine => m_machine ??= new FSMMachine(this);

        /// <summary>以指定状态启动状态机；重复调用会被状态机忽略。</summary>
        protected void StartMachine(Enum initialState) => Machine.Start(initialState);

        protected virtual void Update() => Machine.Update(Time.deltaTime);

        protected virtual void FixedUpdate() => Machine.FixedUpdate(Time.fixedDeltaTime);

        protected virtual void LateUpdate() => Machine.LateUpdate(Time.deltaTime);

        protected virtual void OnDestroy()
        {
            m_machine?.Stop();
            m_machine = null;
        }
    }
}
