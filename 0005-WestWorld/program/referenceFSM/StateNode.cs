namespace Framework.StateMachine
{
    /// <summary>
    /// 所有状态的通用接口
    /// </summary>
    public class StateNode
    {
        public int StateId
        {
            protected set;
            get;
        }

        public StateNode(int id)
        {
            StateId = id;
        }

        public virtual void Enter(object data) { }

        public virtual void FixedUpdate(float dt) { }

        public virtual void Update(float dt) { }

        public virtual void LateUpdate(float dt) { }

        public virtual void Exit() { }

        public virtual bool CheckCanInterrupt()
        {
            return true;
        }

        /// <summary>该状态是否允许移动驱动根节点/角色的位置（物理或动画锁定移动的状态返回 false）</summary>
        public virtual bool AllowMovement => true;

        /// <summary>该状态是否允许朝向插值（朝向由动画或布娃娃物理固定的状态返回 false）</summary>
        public virtual bool AllowFacing => true;

        /// <summary>该状态是否处于"空中"语义（跳跃/下落/击飞/起身在离地判定上都不视为落地，避免误触发 FallDelay 切 Fall）</summary>
        public virtual bool IsInAirState => false;

    }
}
