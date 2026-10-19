using System;
using HutongGames.PlayMaker.FSM;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.StateMachine)]
    [ConvertibleGroup("EnableRegion")]
    [ActionDescription("Enable or disable a Region with explicit start and stop behavior.")]
    public class SetRegionEnabled : BaseRegionAction
    {
        [BoolVarDropdown]
        [Tooltip("True: enable the Region. False: disable the Region.")]
        [SerializeField]
        private BoolVar _setEnabled;

        [Tooltip("How to stop the Region when disabling it.\n\n" +
                 "- Suspend: Pause the Region in its current active state so it can continue from the same state when resumed.\n" +
                 "- Exit: Exit the current active state and stop its running actions.")]
        [SerializeField]
        private RegionDisableBehavior _disableBehavior = RegionDisableBehavior.Exit;

        [Tooltip("How to start the Region when enabling it.\n\n" +
                 "- Resume: Continue from the current active state if the Region was suspended. If there is no active state, start from the start state.\n" +
                 "- Restart: Exit the current active state if needed, then start from the Region's start state.")]
        [SerializeField]
        private RegionEnableBehavior _enableBehavior = RegionEnableBehavior.Restart;

        public override bool CanExecute() => base.CanExecute() && CheckParameters(_setEnabled);

        public override void Execute()
        {
            if (_setEnabled.Value)
            {
                _region.Enable(_enableBehavior);
            }
            else
            {
                _region.Disable(_disableBehavior);
            }
        }

        public override string GetSummary() => "Set {_region} enabled to {_setEnabled}";
    }
}
