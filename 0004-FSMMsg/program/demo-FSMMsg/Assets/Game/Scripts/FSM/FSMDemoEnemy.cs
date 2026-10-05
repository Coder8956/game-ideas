using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UGU.Runtime.FSM
{
    /// <summary>
    /// FSM 使用示例（演示用，可删除）。挂到任意物体上运行即可观察状态切换。
    /// <para>演示内容：</para>
    /// <para>1. 用私有枚举声明状态 ID，经 <see cref="FSMMachineBehaviour.Machine"/>.AddState 注册；</para>
    /// <para>2. AddTransition 以条件委托驱动普通转移（等待→巡逻→追击）；</para>
    /// <para>3. AddAnyTransition 实现全局打断（受击 → 眩晕，任意状态下生效）；</para>
    /// <para>4. 订阅 StateChanged 事件输出切换日志；</para>
    /// <para>5. 状态内通过 Context 访问持有者（本组件）。</para>
    /// 运行后在 Inspector 中给 Target 指定玩家物体，可观察 巡逻→追击；调用 Stun()（如在碰撞回调里）可观察任意状态被眩晕打断。
    /// </summary>
    public class FSMDemoEnemy : FSMMachineBehaviour
    {
        /// <summary>本示例的状态 ID 枚举</summary>
        private enum DemoState
        {
            /// <summary>原地等待</summary>
            Idle,

            /// <summary>在两点之间巡逻</summary>
            Patrol,

            /// <summary>追击目标</summary>
            Chase,

            /// <summary>受击眩晕</summary>
            Stunned,
        }

        [Header("巡逻")]
        [Tooltip("巡逻点 A")]
        [SerializeField]
        private Vector3 m_pointA = new Vector3(-5f, 0f, 0f);

        [Tooltip("巡逻点 B")]
        [SerializeField]
        private Vector3 m_pointB = new Vector3(5f, 0f, 0f);

        [Tooltip("移动速度（米/秒）")]
        [SerializeField]
        private float m_moveSpeed = 3f;

        [Header("追击")]
        [Tooltip("追击目标；留空不追击")]
        [SerializeField]
        private Transform m_target = null;

        [Tooltip("进入追击的触发距离（米）")]
        [SerializeField]
        private float m_chaseRange = 8f;

        [Tooltip("丢失目标、退出追击的距离（米）")]
        [SerializeField]
        private float m_loseRange = 12f;

        [Header("眩晕")]
        [Tooltip("眩晕持续时间（秒）")]
        [SerializeField]
        private float m_stunDuration = 2f;

        [Tooltip("待机等待时长范围（秒）")]
        [SerializeField]
        private Vector2 m_idleWaitRange = new Vector2(1f, 3f);

        private Transform m_transform;
        private bool m_goingToB;
        private Vector3 m_patrolTarget;
        private float m_timer;
        private bool m_isStunned;

        private void Start()
        {
            m_transform = transform;

            // 1. 注册状态
            Machine.AddState(DemoState.Idle, new IdleState(this));
            Machine.AddState(DemoState.Patrol, new PatrolState(this));
            Machine.AddState(DemoState.Chase, new ChaseState(this));
            Machine.AddState(DemoState.Stunned, new StunnedState(this));

            // 2. 注册转移：等待结束 → 巡逻；巡逻到位 → 等待；进入/丢失目标 → 追击/巡逻
            Machine.AddTransition(DemoState.Idle, DemoState.Patrol, () => m_timer <= 0f);
            Machine.AddTransition(DemoState.Patrol, DemoState.Idle, () => Vector3.Distance(m_transform.position, m_patrolTarget) < 0.2f);
            Machine.AddTransition(DemoState.Idle, DemoState.Chase, () => IsTargetInRange(m_chaseRange));
            Machine.AddTransition(DemoState.Patrol, DemoState.Chase, () => IsTargetInRange(m_chaseRange));
            Machine.AddTransition(DemoState.Chase, DemoState.Patrol, () => !IsTargetInRange(m_loseRange));
            Machine.AddTransition(DemoState.Stunned, DemoState.Idle, () => m_timer <= 0f);

            // 3. 任意状态转移：受击后全局打断进入眩晕
            Machine.AddAnyTransition(DemoState.Stunned, () => m_isStunned);

            // 4. 订阅切换事件，输出日志
            Machine.StateChanged += (from, to) => Debug.Log($"[FSM] {from?.ToString() ?? "无"} → {to}", this);

            // 5. 启动
            StartMachine(DemoState.Idle);
        }

        /// <summary>对外受击接口：任意状态下调用即进入眩晕（演示 AnyTransition 的全局打断）。</summary>
        public void Stun()
        {
            m_isStunned = true;
        }

        private bool IsTargetInRange(float range)
        {
            return m_target != null && Vector3.Distance(m_transform.position, m_target.position) <= range;
        }

        private Vector3 NextPatrolPoint()
        {
            m_goingToB = !m_goingToB;
            return m_goingToB ? m_pointB : m_pointA;
        }

        /// <summary>待机：随机等待一段时间，随后由转移条件放行到 Patrol。</summary>
        private sealed class IdleState : FSMState
        {
            private readonly FSMDemoEnemy m_owner;

            public IdleState(FSMDemoEnemy owner) => m_owner = owner;

            public override void OnEnter()
            {
                m_owner.m_timer = Random.Range(m_owner.m_idleWaitRange.x, m_owner.m_idleWaitRange.y);
            }

            public override void OnUpdate(float deltaTime) => m_owner.m_timer -= deltaTime;
        }

        /// <summary>巡逻：前往下一个巡逻点，到位后由转移条件放行到 Idle。</summary>
        private sealed class PatrolState : FSMState
        {
            private readonly FSMDemoEnemy m_owner;

            public PatrolState(FSMDemoEnemy owner) => m_owner = owner;

            public override void OnEnter()
            {
                m_owner.m_patrolTarget = m_owner.NextPatrolPoint();
            }

            public override void OnUpdate(float deltaTime)
            {
                m_owner.m_transform.position = Vector3.MoveTowards(
                    m_owner.m_transform.position, m_owner.m_patrolTarget, m_owner.m_moveSpeed * deltaTime);
            }
        }

        /// <summary>追击：朝目标移动，丢失目标后由转移条件放行回 Patrol。</summary>
        private sealed class ChaseState : FSMState
        {
            private readonly FSMDemoEnemy m_owner;

            public ChaseState(FSMDemoEnemy owner) => m_owner = owner;

            public override void OnUpdate(float deltaTime)
            {
                if (m_owner.m_target == null) return;

                m_owner.m_transform.position = Vector3.MoveTowards(
                    m_owner.m_transform.position, m_owner.m_target.position, m_owner.m_moveSpeed * deltaTime);
            }
        }

        /// <summary>眩晕：计时结束后由转移条件放行回 Idle。</summary>
        private sealed class StunnedState : FSMState
        {
            private readonly FSMDemoEnemy m_owner;

            public StunnedState(FSMDemoEnemy owner) => m_owner = owner;

            public override void OnEnter()
            {
                m_owner.m_isStunned = false;
                m_owner.m_timer = m_owner.m_stunDuration;
            }

            public override void OnUpdate(float deltaTime) => m_owner.m_timer -= deltaTime;
        }
    }
}
