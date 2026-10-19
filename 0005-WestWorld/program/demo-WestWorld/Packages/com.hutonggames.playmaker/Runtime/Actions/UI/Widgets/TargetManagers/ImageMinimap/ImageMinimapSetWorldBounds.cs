using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.ImageMinimap)]
    [Tooltip("Set the world-space bounds used by an ImageMinimap widget.")]
    [HelpURL("guides/ui-widgets/target-managers")]
    public sealed class ImageMinimapSetWorldBounds : BaseAction
    {
        [Tooltip("The ImageMinimap widget to update.")]
        [SerializeField]
        private ImageMinimapVar _minimap;

        [Tooltip("Lower-left world-space point mapped to the minimap image.")]
        [SerializeField]
        private Vector2Var _worldMin;

        [Tooltip("Upper-right world-space point mapped to the minimap image.")]
        [SerializeField]
        private Vector2Var _worldMax;

        public override bool CanExecute() => CheckParameters(_minimap, _worldMin, _worldMax);

        public override void Execute()
        {
            var minimap = _minimap.Value;
            if (minimap == null)
                return;

            minimap.WorldMin = _worldMin.Value;
            minimap.WorldMax = _worldMax.Value;
        }

        public override string GetSummary() => "Set {_minimap} world bounds from {_worldMin} to {_worldMax}";
    }
}
