using System;
using HutongGames.PlayMaker.FSM;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.StateMachine)]
    [ConvertibleGroup("EnableRegion")]
    [ActionDescription("Enable a Region. The Region can resume or restart at its start state.")]
    public class EnableRegion : BaseRegionAction
    {
        [Tooltip("How to start the Region when enabling it.\n\n" +
                 "<b>Resume</b>: Continue from the current active state if the Region was suspended. If there is no active state, start from the start state.\n" +
                 "\n<b>Restart</b>: Exit the current active state if needed, then start from the Region's start state.")]
        [SerializeField]
        private RegionEnableBehavior _enableBehavior = RegionEnableBehavior.Restart;

        public override void Execute() => _region.Enable(_enableBehavior);

        public override string GetSummary() => "Enable {_region} ({_enableBehavior})";
    }
}
