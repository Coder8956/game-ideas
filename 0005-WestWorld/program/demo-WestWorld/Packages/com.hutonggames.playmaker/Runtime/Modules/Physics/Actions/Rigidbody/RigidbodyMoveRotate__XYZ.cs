using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Rigidbody)]
    [ActionDescription("Rotates a Rigidbody by applying a delta rotation (in degrees) relative to its current rotation.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.MoveRotation.html")]
    public sealed class RigidbodyMoveRotate__XYZ : BaseAction
    {
        public override bool CanUsePerSecond => true;
        
        [Tooltip("The Rigidbody to rotate.")]
        [SerializeField] 
        private RigidbodyVar _rigidbody;

        [Tooltip("Degrees to rotate the GameObject around the X axis." + Strings.PerSecondNote)]
        [SerializeField]
        private FloatVar _xAngle;
		
        [Tooltip("Degrees to rotate the GameObject around the Y axis." + Strings.PerSecondNote)]
        [SerializeField]
        private FloatVar _yAngle;
		
        [Tooltip("Degrees to rotate the GameObject around the Z axis." + Strings.PerSecondNote)]
        [SerializeField]
        private FloatVar _zAngle;

        public override bool CanExecute() => CheckParameters(_rigidbody,  _xAngle, _yAngle, _zAngle);

        public override void Execute()
        {
            var rb = _rigidbody.Value;
            var rotationDelta = new Vector3(_xAngle.Value, _yAngle.Value, _zAngle.Value);
            var delta = Quaternion.Euler(rotationDelta * PerSecond);

            rb.MoveRotation(rb.rotation * delta);
        }

        public override string GetSummary() => "Rotate {_rigidbody} by {_xAngle}, {_yAngle}, {_zAngle} {PerSecond}";
    }
}