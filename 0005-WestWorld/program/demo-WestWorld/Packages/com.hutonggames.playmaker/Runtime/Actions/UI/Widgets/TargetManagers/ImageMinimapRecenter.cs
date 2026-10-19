using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.ImageMinimap)]
    [Tooltip("Clear the stored follow position on an ImageMinimap so it recenters when no follow target is active.")]
    [HelpURL("guides/ui-widgets/target-managers")]
    public sealed class ImageMinimapRecenter : BaseAction
    {
        [Tooltip("The ImageMinimap widget to recenter.")]
        [SerializeField]
        private ImageMinimapVar _minimap;

        public override bool CanExecute() => CheckParameters(_minimap);

        public override void Execute()
        {
            var minimap = _minimap.Value;
            if (minimap == null)
                return;

            minimap.Recenter();
        }

        public override string GetSummary() => "Recenter {_minimap}";
    }
}
