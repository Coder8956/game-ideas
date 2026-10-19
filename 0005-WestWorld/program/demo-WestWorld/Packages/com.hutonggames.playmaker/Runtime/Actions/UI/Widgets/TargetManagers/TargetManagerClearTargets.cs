using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.TargetManager)]
    [ConvertibleGroup("TargetManager")]
    [Tooltip("Clear all targets from a TargetManager component (e.g. OffscreenIndicator, TargetIndicator, Radar...)")]
    [HelpURL("guides/ui-widgets/target-managers/")]
    public sealed class TargetManagerClearTargets : BaseAction
    {
        [Tooltip("The TargetManager component.")]
        [SerializeField]
        private BaseTargetManagerVar _manager;

        public override bool CanExecute() => CheckParameters(_manager);

        public override void Execute()
        {
            var mgr = _manager.Value;
            if (mgr == null) return;

            mgr.ClearAllTargets();
        }

        public override string GetSummary() => "Clear all targets from {_manager}";
    }
}