using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.TilemapMinimap)]
    [Tooltip("Clear the stored follow position on a TilemapMinimap so it recenters when no follow target is active.")]
    [HelpURL("guides/ui-widgets/target-managers")]
    public sealed class TilemapMinimapRecenter : BaseAction
    {
        [Tooltip("The TilemapMinimap widget to recenter.")]
        [SerializeField]
        private TilemapMinimapVar _minimap;

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
