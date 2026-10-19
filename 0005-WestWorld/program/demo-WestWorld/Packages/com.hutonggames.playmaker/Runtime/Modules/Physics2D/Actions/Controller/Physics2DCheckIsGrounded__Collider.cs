using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.Physics2DController)]
    [ConvertibleGroup("Physics2DCheckIsGrounded")]
    [ActionDescription("Checks grounded state using a trigger collider. " +
                       "If the trigger overlaps the ground, is grounded is true." +
                       "\n\nOptionally use Coyote Time to still return true a short time after leaving the ground.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D.Overlap.html")]
    public class Physics2DCheckIsGrounded__Collider : BaseCheckIsGroundedAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdateEveryFrame;

        [Tooltip("The collider used to check for overlaps with the ground. " +
                 "Normally this is a child of the GameObject placed at the feet and set to trigger. " +
                 "You can use a box collider, circle collider, etc. depending on your game and character.")]
        [SerializeField] private Collider2DVar _collider;

        [Tooltip("The layer mask and other filters to use when checking for overlap. " +
                 "This defines what is considered 'ground.'")]
        [SerializeField] private ContactFilter2DVar _filter;
        
        private readonly Collider2D[] _results = new Collider2D[1];

        private Rigidbody2DKinematicVelocityHelper _kinematicVelocityHelper = new();

        protected override bool Test()
        {
#if UNITY_6000_0_OR_NEWER
            var velocity = _collider.Value.attachedRigidbody.linearVelocity.y;
            var overlap = _collider.Value.Overlap(_filter.Value, _results) > 0;
#else
            var velocity = _collider.Value.attachedRigidbody.velocity.y;
            var overlap = _collider.Value.OverlapCollider(_filter.Value, _results) > 0;
#endif
            var ground = overlap ? _results[0].attachedRigidbody : null;
            //var groundVelocity = _kinematicVelocityHelper.GetVelocity(ground);
            //if (velocity > 0) velocity -= groundVelocity.y;
            //if (velocity > 0) return false;
            
            _storeRigidbody2D.Value = ground;
            UpdateCoyoteTime(overlap);
            return overlap || IsCoyoteTime();
        }

        protected override string TrueSummary => "{_collider} is Grounded";
        protected override string FalseSummary => "{_collider} is not Grounded";
    }
}
