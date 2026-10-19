using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.ImageMinimap)]
    [Tooltip("Set whether an ImageMinimap rotates with its Origin.")]
    [HelpURL("guides/ui-widgets/target-managers")]
    public sealed class ImageMinimapSetRotateWithOrigin : BaseAction
    {
        [Tooltip("The ImageMinimap widget to update.")]
        [SerializeField]
        private ImageMinimapVar _minimap;

        [Tooltip("If true, rotate the minimap using the Origin transform.")]
        [SerializeField]
        private BoolVar _rotateWithOrigin;

        public override bool CanExecute() => CheckParameters(_minimap, _rotateWithOrigin);

        public override void Execute()
        {
            var minimap = _minimap.Value;
            if (minimap == null)
                return;

            minimap.RotateWithOrigin = _rotateWithOrigin.Value;
        }

        public override string GetSummary() => "Set {_minimap} rotate with origin to {_rotateWithOrigin}";
    }
}
