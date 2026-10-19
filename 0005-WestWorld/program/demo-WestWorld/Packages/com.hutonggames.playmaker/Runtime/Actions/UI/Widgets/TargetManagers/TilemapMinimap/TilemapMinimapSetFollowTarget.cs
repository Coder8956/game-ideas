using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.TilemapMinimap)]
    [Tooltip("Set the Follow Target on a TilemapMinimap widget.")]
    [HelpURL("guides/ui-widgets/target-managers")]
    public sealed class TilemapMinimapSetFollowTarget : BaseAction
    {
        [Tooltip("The TilemapMinimap widget to update.")]
        [SerializeField]
        private TilemapMinimapVar _minimap;

        [Tooltip("GameObject to center the minimap view on. Leave empty to clear the follow target.")]
        [SerializeField, OptionalField]
        private GameObjectVar _followTarget;

        public override bool CanExecute() => CheckParameters(_minimap);

        public override void Execute()
        {
            var minimap = _minimap.Value;
            if (minimap == null)
                return;

            minimap.FollowTarget = _followTarget.IsNone || _followTarget.Value == null
                ? null
                : _followTarget.Value.transform;
        }

        public override string GetSummary() => "Set {_minimap} follow target to {_followTarget}";
    }
}
