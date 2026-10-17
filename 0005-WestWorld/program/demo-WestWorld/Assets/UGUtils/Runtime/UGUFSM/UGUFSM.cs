using System.Collections.Generic;
using UnityEngine;

namespace UGU.Runtime
{
    public class UGUFSM : MonoBehaviour
    {
        [SerializeField] private string m_currentStateName;
        private Dictionary<string, UGUFSMStateBase> m_states;
        private UGUFSMStateBase m_currentState;

        private void Update()
        {
            if (m_currentState != null)
            {
                m_currentState.OnUpdate();
                m_currentState.CheckTransitions();
            }
        }

        private void FixedUpdate()
        {
            if (m_currentState != null)
            {
                m_currentState.OnFixedUpdate();
            }
        }

        public void Init()
        {
            m_states = new Dictionary<string, UGUFSMStateBase>();
        }

        public void AddState(string stateKey, UGUFSMStateBase state)
        {
            if (m_states == null)
            {
                Debug.LogError("[UGUFSM] AddState — m_states is null. Call Init() first.");
                return;
            }

            m_states.Add(stateKey, state);
        }

        public void ChangeState(string stateKey)
        {
            if (m_states == null)
            {
                Debug.LogError("[UGUFSM] ChangeState — m_states is null. Call Init() first.");
                return;
            }

            if (m_states.ContainsKey(stateKey))
            {
                if (m_currentState != null)
                {
                    m_currentState.OnExit();
                }

                m_currentState = m_states[stateKey];
                m_currentStateName = stateKey;
                m_currentState.OnEnter();
            }
            else
            {
                Debug.LogError($"状态 {stateKey} 不存在!");
            }
        }
    }
}
