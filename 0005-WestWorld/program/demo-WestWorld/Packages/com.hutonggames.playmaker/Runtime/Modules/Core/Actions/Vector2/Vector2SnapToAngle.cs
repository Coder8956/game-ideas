// (c) Copyright HutongGames, LLC 2020. All rights reserved.

using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Vector2)]
    [ActionDescription("Snap Vector2 coordinates to fixed angles.")]
    public class Vector2SnapToAngle : BaseAction
    {
        [Tooltip("Vector2 Variable to snap.")]
        [SerializeField]
        private Vector2Ref _vector2;

        [Tooltip("Angle to snap to in degrees.")]
        [SerializeField, DefaultValue(45f)]
        private FloatVar _snapAngle;

        public override bool CanExecute() => CheckParameters(_vector2, _snapAngle);

        public override void Execute()
        {
            var v2 = _vector2.Value;
            var angle = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
            var snappedAngle = Mathf.Round(angle / _snapAngle.Value) * _snapAngle.Value;
            var radian = snappedAngle * Mathf.Deg2Rad;
            v2.Set(Mathf.Cos(radian) * v2.magnitude, Mathf.Sin(radian) * v2.magnitude);
            _vector2.Value = v2;
        }
        
        public override string GetSummary() => "Snap {_vector2} to {_snapAngle} degree angles";
    }
}