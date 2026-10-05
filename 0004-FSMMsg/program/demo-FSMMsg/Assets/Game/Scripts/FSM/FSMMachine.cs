using System;
using System.Collections.Generic;

namespace UGU.Runtime.FSM
{
    /// <summary>
    /// 通用有限状态机（FSM）核心，纯 C# 实现、不依赖 UnityEngine，便于复用与单元测试。
    /// <para>特性：</para>
    /// <para>1. 状态 ID 使用任意枚举（注册、转移、切换传同一枚举值），编译期类型安全；</para>
    /// <para>2. 转移以委托条件驱动，每帧按注册顺序求值，命中即切换；</para>
    /// <para>3. 支持任意状态转移（AnyTransition），用于“受击/眩晕/死亡”等全局打断逻辑；</para>
    /// <para>4. 暴露 <see cref="StateChanged"/> 事件，切换时可收到 (fromId, toId) 通知。</para>
    /// 典型用法：new FSMMachine(context) → AddState × N → AddTransition / AddAnyTransition
    /// → Start(初始状态) → 每帧调用 Update(deltaTime)。
    /// </summary>
    public sealed class FSMMachine
    {
        /// <summary>上下文对象（通常为持有本状态机的 MonoBehaviour）；状态内通过 <see cref="FSMState.Context"/> 访问。</summary>
        public object Context { get; }

        /// <summary>当前状态实例；未启动或已停止时为 null。</summary>
        public FSMState CurrentState { get; private set; }

        /// <summary>当前状态 ID；未启动或已停止时为 null。</summary>
        public Enum CurrentStateId { get; private set; }

        /// <summary>是否已启动（Start 之后、Stop 之前）。</summary>
        public bool IsRunning { get; private set; }

        /// <summary>状态切换事件：参数为 (fromId, toId)；状态机首次进入时 fromId 为 null。</summary>
        public event Action<Enum, Enum> StateChanged;

        private readonly Dictionary<Enum, FSMState> m_states = new Dictionary<Enum, FSMState>();
        private readonly Dictionary<Enum, List<FSMTransition>> m_transitions = new Dictionary<Enum, List<FSMTransition>>();
        private readonly List<FSMTransition> m_anyTransitions = new List<FSMTransition>();

        public FSMMachine(object context = null)
        {
            Context = context;
        }

        /// <summary>
        /// 注册一个状态。同一状态实例只能属于一个状态机；重复注册同一 ID 会覆盖旧状态。
        /// </summary>
        public void AddState(Enum id, FSMState state)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (state == null) throw new ArgumentNullException(nameof(state));
            if (state.Machine != null && state.Machine != this)
                throw new InvalidOperationException($"状态实例 {state.GetType().Name} 已属于另一个状态机，不能重复注册。");

            m_states[id] = state;
            state.Machine = this;
        }

        /// <summary>
        /// 注册一条从 fromState 出发的转移：条件满足时切换到 toState。
        /// 同一源状态下按注册顺序求值，先命中先切换。
        /// </summary>
        public void AddTransition(Enum fromState, Enum toState, Func<bool> condition)
        {
            if (fromState == null) throw new ArgumentNullException(nameof(fromState));
            if (toState == null) throw new ArgumentNullException(nameof(toState));

            if (!m_transitions.TryGetValue(fromState, out var list))
            {
                list = new List<FSMTransition>();
                m_transitions[fromState] = list;
            }

            list.Add(new FSMTransition(toState, condition));
        }

        /// <summary>
        /// 注册一条任意状态转移：任意状态下条件满足即切换，且优先于普通转移求值。
        /// 适合“受击、眩晕、死亡、暂停”等需要全局打断的状态。
        /// </summary>
        public void AddAnyTransition(Enum toState, Func<bool> condition)
        {
            if (toState == null) throw new ArgumentNullException(nameof(toState));
            m_anyTransitions.Add(new FSMTransition(toState, condition));
        }

        /// <summary>
        /// 以指定状态启动状态机；已启动时忽略。初始状态必须已注册，否则抛异常。
        /// </summary>
        public void Start(Enum initialState)
        {
            if (initialState == null) throw new ArgumentNullException(nameof(initialState));
            if (IsRunning) return;

            if (!m_states.ContainsKey(initialState))
                throw new InvalidOperationException($"状态 {initialState} 未注册，无法启动。请先调用 AddState。");

            IsRunning = true;
            EnterState(initialState, null);
        }

        /// <summary>
        /// 立即切换到指定状态。
        /// <para>目标未注册时抛异常；目标与当前相同且未指定 force 时忽略（可用 force: true 实现“重进当前状态”）。</para>
        /// </summary>
        public void ChangeState(Enum stateId, bool force = false)
        {
            if (stateId == null) throw new ArgumentNullException(nameof(stateId));
            if (!IsRunning) return;

            if (!force && CurrentStateId != null && CurrentStateId.Equals(stateId)) return;

            if (!m_states.TryGetValue(stateId, out var next))
                throw new InvalidOperationException($"状态 {stateId} 未注册，无法切换。请先调用 AddState。");

            var from = CurrentStateId;
            ExitCurrentState();
            EnterState(stateId, from);
        }

        /// <summary>逐帧驱动：先求值转移条件（满足则切换），再向当前状态派发 OnUpdate。</summary>
        public void Update(float deltaTime)
        {
            if (!IsRunning) return;

            EvaluateTransitions();
            CurrentState?.OnUpdate(deltaTime);
        }

        /// <summary>物理步长驱动，对应 MonoBehaviour.FixedUpdate。</summary>
        public void FixedUpdate(float fixedDeltaTime)
        {
            if (!IsRunning) return;
            CurrentState?.OnFixedUpdate(fixedDeltaTime);
        }

        /// <summary>渲染后驱动，对应 MonoBehaviour.LateUpdate。</summary>
        public void LateUpdate(float deltaTime)
        {
            if (!IsRunning) return;
            CurrentState?.OnLateUpdate(deltaTime);
        }

        /// <summary>停止状态机并退出当前状态；停止后可再次 Start。</summary>
        public void Stop()
        {
            if (!IsRunning) return;

            IsRunning = false;
            ExitCurrentState();
        }

        /// <summary>按 ID 获取已注册的状态实例；未注册返回 null。</summary>
        public FSMState GetState(Enum id)
        {
            return id != null && m_states.TryGetValue(id, out var state) ? state : null;
        }

        /// <summary>当前是否处于指定状态。</summary>
        public bool IsInState(Enum id) => IsRunning && CurrentStateId != null && CurrentStateId.Equals(id);

        private void EvaluateTransitions()
        {
            // 1. 任意状态转移优先于普通转移
            foreach (var transition in m_anyTransitions)
            {
                if (transition.Evaluate())
                {
                    ChangeState(transition.ToState);
                    return;
                }
            }

            // 2. 当前状态自身的转移，按注册顺序
            if (CurrentStateId != null && m_transitions.TryGetValue(CurrentStateId, out var list))
            {
                foreach (var transition in list)
                {
                    if (transition.Evaluate())
                    {
                        ChangeState(transition.ToState);
                        return;
                    }
                }
            }
        }

        private void EnterState(Enum id, Enum from)
        {
            var state = m_states[id];
            CurrentState = state;
            CurrentStateId = id;
            state.OnEnter();
            StateChanged?.Invoke(from, id);
        }

        private void ExitCurrentState()
        {
            CurrentState?.OnExit();
            CurrentState = null;
            CurrentStateId = null;
        }
    }
}
