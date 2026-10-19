using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.ImageMinimap)]
    [Tooltip("Set the Map Scale on an ImageMinimap widget.")]
    [HelpURL("guides/ui-widgets/target-managers")]
    public sealed class ImageMinimapSetMapScale : BaseAction
    {
        [Tooltip("The ImageMinimap widget to update.")]
        [SerializeField]
        private ImageMinimapVar _minimap;

        [Tooltip("Zoom level for the minimap. 1 shows the full map.")]
        [SerializeField]
        private FloatVar _mapScale;

        public override bool CanExecute() => CheckParameters(_minimap, _mapScale);

        public override void Execute()
        {
            var minimap = _minimap.Value;
            if (minimap == null)
                return;

            minimap.MapScale = _mapScale.Value;
        }

        public override string GetSummary() => "Set {_minimap} map scale to {_mapScale}";
    }
}
