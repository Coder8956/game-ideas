using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.TilemapMinimap)]
    [Tooltip("Set the Origin on a TilemapMinimap widget.")]
    [HelpURL("guides/ui-widgets/target-managers")]
    public sealed class TilemapMinimapSetOrigin : BaseAction
    {
        [Tooltip("The TilemapMinimap widget to update.")]
        [SerializeField]
        private TilemapMinimapVar _minimap;

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
