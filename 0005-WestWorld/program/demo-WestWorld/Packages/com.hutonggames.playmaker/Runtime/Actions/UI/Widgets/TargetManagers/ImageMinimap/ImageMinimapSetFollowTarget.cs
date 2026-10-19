using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.ImageMinimap)]
    [Tooltip("Set the Follow Target on an ImageMinimap widget.")]
    [HelpURL("guides/ui-widgets/target-managers")]
    public sealed class ImageMinimapSetFollowTarget : BaseAction
    {
        [Tooltip("The ImageMinimap widget to update.")]
        [SerializeField]
        private ImageMinimapVar _minimap;

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
