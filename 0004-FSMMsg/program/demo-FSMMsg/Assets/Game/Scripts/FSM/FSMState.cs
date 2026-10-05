using System;

namespace UGU.Runtime.FSM
{
    /// <summary>
    /// 有限状态机（FSM）的状态基类。
    /// <para>子类通过重写生命周期回调实现状态行为；状态切换由 <see cref="FSMMachine"/> 统一驱动。</para>
    /// 状态实例不直接持有场景对象，通过 <see cref="Machine"/> 与 <see cref="Context"/> 访问状态机及其上下文。
    /// </summary>
    public abstract class FSMState
    {
        /// <summary>所属状态机；由 <see cref="FSMMachine.AddState"/> 注入，注册前为 null。</summary>
        public FSMMachine Machine { get; internal set; }

        /// <summary>状态机上下文（通常为持有状态机的 MonoBehaviour）；可为 null。</summary>
        protected object Context => Machine?.Context;

        /// <summary>进入该状态时调用一次（状态机启动或切换进入时）。</summary>
        public virtual void OnEnter() { }

        /// <summary>离开该状态时调用一次。</summary>
        public virtual void OnExit() { }

        /// <summary>逐帧驱动，仅当前状态被调用。</summary>
        public virtual void OnUpdate(float deltaTime) { }

        /// <summary>物理步长驱动，仅当前状态被调用。</summary>
        public virtual void OnFixedUpdate(float fixedDeltaTime) { }

        /// <summary>渲染后驱动，仅当前状态被调用。</summary>
        public virtual void OnLateUpdate(float deltaTime) { }

        /// <summary>
        /// 请求切换到指定状态；等价于 <see cref="FSMMachine.ChangeState"/>，
        /// 便于在状态内部直接跳转（例如计时结束、动画播完）。
        /// </summary>
        protected void ChangeState(Enum stateId) => Machine?.ChangeState(stateId);
    }
}
