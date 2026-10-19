using System;
using HutongGames.PlayMaker.FSM;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.StateMachine)]
    [ConvertibleGroup("EnableRegion")]
    [ActionDescription("Disable a Region. The Region can either suspend its active state or exit it.")]
    public class DisableRegion : BaseRegionAction
    {
        [Tooltip("How to stop the Region when disabling it.\n\n" +
                 "<b>Suspend</b>: Pause the Region in its current active state so it can continue from the same state when resumed.\n" +
                 "\n<b>Exit</b>: Exit the current active state and stop its running actions.")]
        [SerializeField]
        private RegionDisableBehavior _disableBehavior = RegionDisableBehavior.Exit;

        public override void Execute() => _region.Disable(_disableBehavior);

        public override string GetSummary() => "Disable {_region} ({_disableBehavior})";
    }
}
