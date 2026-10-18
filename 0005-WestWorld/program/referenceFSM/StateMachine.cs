using System;
using System.Collections.Generic;

namespace Framework.StateMachine
{
    /// <summary>
    /// 通用状态机管理器
    /// </summary>
    public class StateMachine
    {
        // 状态字典，用于存储所有状态
        private readonly Dictionary<int, StateNode> _states = new Dictionary<int, StateNode>();

        // 当前激活的状态
        private StateNode _currentState;
        public StateNode CurrentState => _currentState;
        public int CurrentStateId => _currentState?.StateId ?? 0;

        
        /// 上一个激活的状态
        private StateNode _lastState;
        public StateNode LastState => _lastState;
        public int LastStateId => _lastState?.StateId ?? 0;

        // 注册状态
        public void RegisterState(StateNode state)
        {
            if (_states.ContainsKey(state.StateId))
            {
                throw new ArgumentException($"状态ID {state.StateId} 已存在");
            }
            _states[state.StateId] = state;
        }

        // 注销状态
        public void UnregisterState(int stateId)
        {
            if (!_states.ContainsKey(stateId))
            {
                throw new ArgumentException($"状态ID {stateId} 不存在");
            }
            _states.Remove(stateId);
        }

        // 获取状态
        public StateNode GetState(int stateId)
        {
            if (!_states.ContainsKey(stateId))
            {
                throw new ArgumentException($"状态ID {stateId} 不存在");
            }
            return _states[stateId];
        }

        // 获取状态
        public StateNode GetState<T>(int stateId) where T : StateNode
        {
            if (!_states.ContainsKey(stateId))
            {
                throw new ArgumentException($"状态ID {stateId} 不存在");
            }
            return _states[stateId] as T;
        }

        /// <summary>
        /// 切换到新状态
        /// </summary>
        /// <param name="newState">要切换的新状态</param>
        public void ChangeState(int newStateId, object data = null)
        {
            // 如果新状态不存在，抛出异常
            if (!_states.ContainsKey(newStateId))
            {
                throw new ArgumentException($"状态ID {newStateId} 不存在");
            }
            
            var newState = GetState(newStateId);
            // 如果当前有状态，先执行退出逻辑
            _currentState?.Exit();

            // 更新当前状态并执行进入逻辑
            _currentState = newState;
            _currentState.Enter(data);
        }

        public void Update(float dt)
        {
            _currentState?.Update(dt);
        }

        public void FixedUpdate(float dt)
        {
            _currentState?.FixedUpdate(dt);
        }

        public void LateUpdate(float dt)
        {
            _currentState?.LateUpdate(dt);
        }
    }
}
