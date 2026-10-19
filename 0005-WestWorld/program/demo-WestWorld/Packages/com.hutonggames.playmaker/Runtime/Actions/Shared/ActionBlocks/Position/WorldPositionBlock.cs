using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Defines a world position.
    /// </summary>
    [Serializable]
    [DisplayOrder(0)]
    [Tooltip("Use a world position.")]
    public class WorldPositionBlock : BasePositionBlock
    {
        [Tooltip("World Position")]
        public Vector3Var Position;

        public override Vector3 GetWorldPosition() => Position.Value;

        public override void SetWorldPosition(Vector3 position) => Position.Value = position;

        public override string GetSummary() => "{Position}";
    }
}