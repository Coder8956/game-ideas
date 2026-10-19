using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.TargetManager)]
    [ConvertibleGroup("TargetManager")]
    [Tooltip("Add a list of targets to a TargetManager component (e.g. OffscreenIndicator, TargetIndicator, Radar...)")]
    [HelpURL("guides/ui-widgets/target-managers")]
    public sealed class TargetManagerAddTargets : BaseAction
    {
        [Tooltip("The TargetManager component.")]
        [SerializeField]
        private BaseTargetManagerVar _manager;
        
        [Tooltip("GameObject targets to track.")]
        [SerializeField]
        private GameObjectListVar _targets;
        
        [Tooltip("Optional indicator prefab to spawn for this target. If empty, the manager's default prefab is used.")]
        [SerializeField, OptionalField]
        private GameObjectVar _indicatorPrefab;

        [Tooltip("Optional style id tag for user logic (filters, queries, etc.).")]
        [SerializeField, OptionalField]
        private IntegerVar _styleId;
        
        public override bool CanExecute() => CheckParameters(_manager, _targets);

        public override void Execute()
        {
            var mgr = _manager.Value;
            if (mgr == null) return;

            var targets = _targets.Value;
            if (targets == null) return;

            var prefab = _indicatorPrefab.IsNone ? null : _indicatorPrefab.Value;
            var style = _styleId.IsNone ? 0 : _styleId.Value;

            foreach (var go in targets)
            {
                if (go == null) continue;
                mgr.AddTarget(go.transform, prefab, style);
            }
        }

        public override string GetSummary() => "Add {_targets} to {_manager}";
    }
}