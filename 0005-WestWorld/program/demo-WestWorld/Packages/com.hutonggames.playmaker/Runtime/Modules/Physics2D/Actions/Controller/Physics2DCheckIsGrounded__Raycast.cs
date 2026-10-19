using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.Physics2DController)]
    [ConvertibleGroup("Physics2DCheckIsGrounded")]
    [ActionDescription("Checks grounded state using a raycast. " +
                       "If the raycast hits the ground, is grounded is true.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.Raycast.html")]
    public class Physics2DCheckIsGrounded__Raycast : BaseCheckIsGroundedAction
    {
        [Tooltip("The transform to raycast from. " +
                 "Normally this is a child of the GameObject placed near the feet. ")]
        [SerializeField] 
        private TransformVar _origin;

        [Tooltip("The distance to raycast.")]
        [SerializeField, DefaultValue(0.2f)] 
        private FloatVar _distance;
        
        [Tooltip("The layer mask and other filters to use when checking for overlap. " +
                 "This defines what is considered 'ground.'")]
        [SerializeField] 
        private ContactFilter2DVar _filter;

        private readonly RaycastHit2D[] _results = new RaycastHit2D[1];
        
        protected override bool Test()
        {
            var isGrounded = Physics2D.Raycast(
                _origin.Value.position, -Vector2.up, _filter.Value, _results, _distance.Value) > 0;
            _storeRigidbody2D.Value = isGrounded ? _results[0].rigidbody : null;
            UpdateCoyoteTime(isGrounded);
            return isGrounded || IsCoyoteTime();
        }

        protected override string TrueSummary => "{_origin} is Grounded";
        protected override string FalseSummary => "{_origin} is not Grounded";
    }
}