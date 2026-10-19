using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Rigidbody)]
    [ActionDescription("Rotates a Rigidbody by applying a delta rotation (in degrees) relative to its current rotation.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.MoveRotation.html")]
    public sealed class RigidbodyMoveRotate : BaseAction
    {
        public override bool CanUsePerSecond => true;
        
        [Tooltip("The Rigidbody to rotate.")]
        [SerializeField] 
        private RigidbodyVar _rigidbody;

        [Tooltip("Local rotation to apply each frame (degrees)." + Strings.PerSecondNote)]
        [SerializeField] 
        private Vector3Var _rotationDelta;

        public override bool CanExecute() => CheckParameters(_rigidbody, _rotationDelta);

        public override void Execute()
        {
            var rb = _rigidbody.Value;
            var delta = Quaternion.Euler(_rotationDelta.Value * PerSecond);

            rb.MoveRotation(rb.rotation * delta);
        }

        public override string GetSummary() => "Rotate {_rigidbody} by {_rotationDelta} {PerSecond}";
    }
}