using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.TilemapMinimap)]
    [Tooltip("Refresh the rendered map texture on a TilemapMinimap widget.")]
    [HelpURL("guides/ui-widgets/target-managers")]
    public sealed class TilemapMinimapRefresh : BaseAction
    {
        [Tooltip("The TilemapMinimap widget to refresh.")]
        [SerializeField]
        private TilemapMinimapVar _minimap;

        public override bool CanExecute() => CheckParameters(_minimap);

        public override void Execute()
        {
            var minimap = _minimap.Value;
            if (minimap == null)
                return;

            minimap.RefreshMap();
        }

        public override string GetSummary() => "Refresh {_minimap}";
    }
}
