using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Defines a position using a target GameObject and an offset.
    /// The offset can be in local or world space.
    /// </summary>
    [Serializable]
    [DisplayOrder(4)]
    [Tooltip("Use the position of a GameObject with an offset.")]
    public class GameObjectOffsetPositionBlock : BasePositionBlock
    {
        [Tooltip("GameObject position.")]
        public GameObjectVar GameObject;
        
        [Tooltip("Offset from the GameObject position.")]
        public Vector3Var Offset;
        
        [LocalSpace, HideLabel]
        [Tooltip("Coordinates for the Offset")]
        public Space InSpace;

        public override bool IsValid => GameObject.Value != null && Offset.HasValue();
        
        public override Vector3 GetWorldPosition() => InSpace == Space.Self 
                ? GameObject.Value.transform.TransformPoint(Offset.Value)
                : GameObject.Value.transform.position + Offset.Value;

        public override void SetWorldPosition(Vector3 position) => Offset.Value = InSpace == Space.Self 
                ? GameObject.Value.transform.InverseTransformPoint(position) 
                : position - GameObject.Value.transform.position;

        public override string GetSummary() => "{GameObject} Offset:{Offset}";
    }
}