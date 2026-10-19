using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.ImageMinimap)]
    [Tooltip("Set the Origin on an ImageMinimap widget.")]
    [HelpURL("guides/ui-widgets/target-managers")]
    public sealed class ImageMinimapSetOrigin : BaseAction
    {
        [Tooltip("The ImageMinimap widget to update.")]
        [SerializeField]
        private ImageMinimapVar _minimap;

        [Tooltip("GameObject used as the rotation source for the minimap. Leave empty to clear the origin.")]
        [SerializeField, OptionalField]
        private GameObjectVar _origin;

        public override bool CanExecute() => CheckParameters(_minimap);

        public override void Execute()
        {
            var minimap = _minimap.Value;
            if (minimap == null)
                return;

            minimap.Origin = _origin.IsNone || _origin.Value == null
                ? null
                : _origin.Value.transform;
        }

        public override string GetSummary() => "Set {_minimap} origin to {_origin}";
    }
}
