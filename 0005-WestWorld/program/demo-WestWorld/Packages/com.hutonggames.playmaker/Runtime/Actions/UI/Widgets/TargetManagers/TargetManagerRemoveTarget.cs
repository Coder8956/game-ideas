using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.TargetManager)]
    [ConvertibleGroup("TargetManager")]
    [Tooltip("Remove a target from an TargetManager component (e.g. OffscreenIndicator, TargetIndicator, Radar...)")]
    [HelpURL("guides/ui-widgets/target-managers/")]
    public sealed class TargetManagerRemoveTarget : BaseAction
    {
        [Tooltip("The TargetManager component.")]
        [SerializeField]
        private BaseTargetManagerVar _manager;

        [Tooltip("The GameObject to stop tracking.")]
        [SerializeField]
        private GameObjectVar _target;

        public override bool CanExecute() => CheckParameters(_manager, _target);

        public override void Execute()
        {
            var mgr = _manager.Value;
            if (mgr == null) return;

            var go = _target.Value;
            if (go == null) return;

            mgr.RemoveTarget(go.transform);
        }

        public override string GetSummary() => "Remove {_target} from {_manager}";
    }
}