namespace UGU.Runtime
{
    /// <summary>
    /// 有限状态机状态基类（抽象类，不可直接实例化，只能被继承）。
    /// 状态生命周期由 UGUFSM 驱动；状态转换的条件检查在状态类内部执行。
    /// </summary>
    public abstract class UGUFSMStateBase
    {
        /// <summary>
        /// 所属状态机引用，用于在状态类内部触发状态转换。
        /// </summary>
        protected UGUFSM m_fsm;

        protected UGUFSMStateBase(UGUFSM fsm)
        {
            m_fsm = fsm;
        }

        // ── 生命周期 ──────────────────────────────────────────────

        /// <summary>
        /// 进入状态时调用，子类必须实现。
        /// </summary>
        public abstract void OnEnter();

        /// <summary>
        /// 退出状态时调用，子类必须实现。
        /// </summary>
        public abstract void OnExit();

        /// <summary>
        /// 每帧更新，子类按需重写。
        /// </summary>
        public virtual void OnUpdate()
        {
        }

        /// <summary>
        /// 物理帧更新，子类按需重写。
        /// </summary>
        public virtual void OnFixedUpdate()
        {
        }

        // ── 状态转换 ──────────────────────────────────────────────

        /// <summary>
        /// 状态转换条件检查：由状态机每帧调用。
        /// 子类在内部检查转换条件，条件满足时调用 ChangeState / RevertToPreviousState 完成切换。
        /// </summary>
        public virtual void CheckTransitions()
        {
        }

        /// <summary>
        /// 触发状态转换，供状态类在条件满足时调用。
        /// </summary>
        protected void ChangeState(string stateKey)
        {
            m_fsm.ChangeState(stateKey);
        }

        /// <summary>
        /// 退回上一状态，供"状态 blip"使用（插播行为结束后恢复被打断的状态）。
        /// </summary>
        protected void RevertToPreviousState()
        {
            m_fsm.RevertToPreviousState();
        }
    }
}
