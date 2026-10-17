using System.Collections.Generic;
using UnityEngine;

namespace UGU.Runtime
{
    /// <summary>
    /// 通用有限状态机（FSM）驱动器，适用于 Unity。
    /// 参考 Buckland《Programming Game AI by Example》第 2 章 WestWorldWithWoman 设计：
    /// 状态机维护 当前状态 / 上一状态 / 全局状态 三个状态；
    /// 状态转换的条件检查在状态类（UGUFSMStateBase）内部执行，本类只负责驱动状态生命周期与执行切换。
    /// </summary>
    public class UGUFSM : MonoBehaviour
    {
        [SerializeField] private string m_currentStateName;
        [SerializeField] private string m_previousStateName;
        [SerializeField] private string m_globalStateName;

        private Dictionary<string, UGUFSMStateBase> m_states;
        private UGUFSMStateBase m_currentState;
        private UGUFSMStateBase m_previousState;
        private UGUFSMStateBase m_globalState;

        // ── 属性 ──────────────────────────────────────────────────

        public UGUFSMStateBase CurrentState => m_currentState;
        public UGUFSMStateBase GlobalState => m_globalState;
        public UGUFSMStateBase PreviousState => m_previousState;
        public string CurrentStateName => m_currentStateName;

        // ── 生命周期 ──────────────────────────────────────────────

        private void Update()
        {
            // 每帧先执行全局状态，再执行当前状态（全局状态优先"插播"）。
            if (m_globalState != null)
            {
                m_globalState.OnUpdate();
                m_globalState.CheckTransitions();
            }

            if (m_currentState != null)
            {
                m_currentState.OnUpdate();
                m_currentState.CheckTransitions();
            }
        }

        private void FixedUpdate()
        {
            if (m_globalState != null)
            {
                m_globalState.OnFixedUpdate();
            }

            if (m_currentState != null)
            {
                m_currentState.OnFixedUpdate();
            }
        }

        // ── 内部工具 ──────────────────────────────────────────────

        private bool TryGetState(string stateKey, out UGUFSMStateBase state)
        {
            state = null;

            if (m_states == null)
            {
                Debug.LogError("[UGUFSM] 状态容器为 null，请先调用 Init()。");
                return false;
            }

            if (!m_states.TryGetValue(stateKey, out state))
            {
                Debug.LogError($"[UGUFSM] 状态 {stateKey} 不存在！");
                return false;
            }

            return true;
        }

        // ── 公共接口 ──────────────────────────────────────────────

        /// <summary>
        /// 初始化状态机，创建状态容器。注册、切换状态前必须先调用。
        /// </summary>
        public void Init()
        {
            m_states = new Dictionary<string, UGUFSMStateBase>();
        }

        /// <summary>
        /// 注册状态。
        /// </summary>
        public void AddState(string stateKey, UGUFSMStateBase state)
        {
            if (m_states == null)
            {
                Debug.LogError("[UGUFSM] AddState 失败：m_states 为 null，请先调用 Init()。");
                return;
            }

            if (m_states.ContainsKey(stateKey))
            {
                Debug.LogWarning($"[UGUFSM] 状态 {stateKey} 已存在，将被覆盖。");
                m_states[stateKey] = state;
                return;
            }

            m_states.Add(stateKey, state);
        }

        /// <summary>
        /// 安装初始当前状态（仅替换指针，不触发 OnEnter；如需进入时执行 OnEnter 请改用 ChangeState）。
        /// </summary>
        public void SetCurrentState(string stateKey)
        {
            if (!TryGetState(stateKey, out m_currentState))
            {
                return;
            }

            m_currentStateName = stateKey;
        }

        /// <summary>
        /// 设置全局状态（须先注册）。
        /// 全局状态不属于任何具体状态，每帧先于当前状态执行 OnUpdate 与 CheckTransitions。
        /// </summary>
        public void SetGlobalState(string stateKey)
        {
            if (!TryGetState(stateKey, out m_globalState))
            {
                return;
            }

            m_globalStateName = stateKey;
        }

        /// <summary>
        /// 切换到指定状态：存档上一状态 -> 退出当前状态 -> 更新当前状态 -> 进入新状态。
        /// </summary>
        public void ChangeState(string stateKey)
        {
            if (!TryGetState(stateKey, out UGUFSMStateBase nextState))
            {
                return;
            }

            // ① 存档上一状态（供 RevertToPreviousState 退回使用）。
            m_previousState = m_currentState;
            m_previousStateName = m_currentStateName;

            // ② 旧状态收尾。
            if (m_currentState != null)
            {
                m_currentState.OnExit();
            }

            // ③ 指针换到新状态。
            m_currentState = nextState;
            m_currentStateName = stateKey;

            // ④ 新状态登场。
            m_currentState.OnEnter();
        }

        /// <summary>
        /// 退回上一状态（状态 blip）：切回最近一次 ChangeState 之前的那个状态。
        /// 典型用法：插播状态执行完毕后恢复被打断的原状态。
        /// </summary>
        public void RevertToPreviousState()
        {
            if (m_previousState == null)
            {
                Debug.LogError("[UGUFSM] RevertToPreviousState 失败：没有可退回的上一状态。");
                return;
            }

            ChangeState(m_previousStateName);
        }
    }
}
