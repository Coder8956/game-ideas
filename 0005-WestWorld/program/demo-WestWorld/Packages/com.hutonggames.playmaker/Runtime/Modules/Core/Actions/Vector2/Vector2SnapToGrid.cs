// (c) Copyright HutongGames, LLC 2020. All rights reserved.

using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Vector2)]
    [ActionDescription("Snap Vector2 coordinates to grid points. " +
                       "Set grid size to 0 to disable snapping on an axis.")]
    public class Vector2SnapToGrid : BaseAction
    {
        [Tooltip("Vector2 Variable to snap.")]
        [SerializeField]
        private Vector2Ref _vector2;

        [Tooltip("X Grid Size.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _xGridSize;

        [Tooltip("Y Grid Size.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _yGridSize;

        public override bool CanExecute() => CheckParameters(_vector2, _xGridSize, _yGridSize);

        public override void Execute()
        {
            var v2 = _vector2.Value;
            v2.Set(Snap.ToGrid(v2.x, _xGridSize.Value), 
                   Snap.ToGrid(v2.y, _yGridSize.Value));
            _vector2.Value = v2;
        }
        
        public override string GetSummary() => "Snap {_vector2} to grid: {_xGridSize} {_yGridSize}";
    }
}