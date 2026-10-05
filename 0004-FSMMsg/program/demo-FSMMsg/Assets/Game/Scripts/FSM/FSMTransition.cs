using System;

namespace UGU.Runtime.FSM
{
    /// <summary>
    /// 一条状态转移定义：当 <see cref="m_condition"/> 判定为 true 时切换到 <see cref="ToState"/>。
    /// <para>转移不记录源状态：普通转移由 <see cref="FSMMachine.AddTransition"/> 绑定“从哪个状态出发”，
    /// 任意状态转移由 <see cref="FSMMachine.AddAnyTransition"/> 添加、可在任意状态下触发。</para>
    /// </summary>
    public sealed class FSMTransition
    {
        /// <summary>转移目标状态 ID（枚举值）。</summary>
        public Enum ToState { get; }

        /// <summary>触发条件委托；为 null 时该转移永不触发。</summary>
        private readonly Func<bool> m_condition;

        /// <param name="toState">目标状态 ID，须与 <see cref="FSMMachine.AddState"/> 注册的枚举一致。</param>
        /// <param name="condition">触发条件；为 null 表示永不触发。</param>
        public FSMTransition(Enum toState, Func<bool> condition)
        {
            ToState = toState ?? throw new ArgumentNullException(nameof(toState));
            m_condition = condition;
        }

        /// <summary>求值触发条件。</summary>
        public bool Evaluate() => m_condition?.Invoke() ?? false;
    }
}
