using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Get the rotation of the Action's current target.
    /// Note: The parent action has to set the Target.
    /// </summary>
    [Serializable]
    [DisplayOrder(0)]
    public class RotationBlock : BaseRotationBlock
    {
        public override bool IsValid => Rotation.HasValue();

        [Tooltip("Rotation around x, y, and z.")]
        public QuaternionVar Rotation;

        public override Quaternion GetRotation() => Rotation.Value;

        public override void SetRotation(Quaternion rotation) => Rotation.Value = rotation;

        public override string GetSummary() => "{Rotation}";
    }
}