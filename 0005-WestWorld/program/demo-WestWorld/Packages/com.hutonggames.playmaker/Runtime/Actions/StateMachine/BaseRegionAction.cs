using System;
using HutongGames.PlayMaker.FSM;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public abstract class BaseRegionAction : BaseAction
    {
        [Tooltip("The Region to enable or disable.")]
        [SerializeReference]
        protected RegionNode _region;

        public override bool CanExecute() => _region != null;

        public override string ErrorCheck()
        {
            if (_region == null)
            {
                return "Missing target Region.";
            }

            return State != null && _region.Fsm != State.Fsm
                ? "Target Region must belong to the same FSM."
                : null;
        }
    }
}
