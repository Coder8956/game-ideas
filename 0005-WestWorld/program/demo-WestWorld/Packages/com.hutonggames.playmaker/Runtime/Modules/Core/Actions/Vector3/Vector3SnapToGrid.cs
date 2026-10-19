// (c) Copyright HutongGames, LLC 2020. All rights reserved.

using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Vector3)]
    [ActionDescription("Snap Vector3 coordinates to grid points. " +
                       "Set grid size to 0 to disable snapping on an axis.")]
    public class Vector3SnapToGrid : BaseAction
    {
        [Tooltip("Vector3 Variable to snap.")]
        [SerializeField]
        private Vector3Ref _vector3;

        [Tooltip("X Grid Size.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _xGridSize;

        [Tooltip("Y Grid Size.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _yGridSize;
        
        [Tooltip("Z Grid Size.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _zGridSize;

        public override bool CanExecute() => CheckParameters(_vector3, _xGridSize, _yGridSize, _zGridSize);

        public override void Execute()
        {
            var v3 = _vector3.Value;
            v3.Set(Snap.ToGrid(v3.x, _xGridSize.Value), 
                   Snap.ToGrid(v3.y, _yGridSize.Value), 
                   Snap.ToGrid(v3.z, _zGridSize.Value));
            _vector3.Value = v3;
        }

        public override string GetSummary() => 
            "Snap {_vector3} to grid: {_xGridSize} {_yGridSize} {_zGridSize}";
    }
}