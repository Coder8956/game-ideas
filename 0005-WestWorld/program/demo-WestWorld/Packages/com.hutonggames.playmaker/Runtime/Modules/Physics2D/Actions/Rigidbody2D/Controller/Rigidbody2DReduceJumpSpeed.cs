using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.Rigidbody2DController)]
    [ActionDescription("Reduce a Rigidbody2D's vertical speed if the jump button is released early." +
                       "This tweak allows higher jumps if the player holds the jump button down.")]
    public class Rigidbody2DReduceJumpSpeed : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdateEveryFrame;

        [Tooltip("The Rigidbody to control.")]
        [SerializeField] private Rigidbody2DVar _rigidbody;

        [Tooltip("Set to true while the jump button is pressed. Generally set by an input action like InputGetButton.")]
        [SerializeField] 
        private BoolRef _isJumping;

        [Tooltip("The amount of speed to lose when releasing the jump button while the rigidbody is still going up. " +
                 "This is a multiplier, so 0.5 loses 50% of the speed.")]
        [SerializeField, DefaultValue(0.5f)]
        private FloatVar _multiplier;
        
        public override bool CanExecute() => CheckParameters(_rigidbody, _isJumping);

        public override void OnStart()
        {
            // Jump key is not pressed so it can't be released early
            // so there is nothing for this action to do.
            if (!_isJumping.Value)
            {
                Finish();
            }
        }

        public override void Execute()
        {
            if (_isJumping.Value) return;
            
            ApplyLowerJump();
            Finish();
        }
        
        private void ApplyLowerJump()
        {
            var rigidbody = _rigidbody.Value;
#if UNITY_6000_0_OR_NEWER
            if (rigidbody.linearVelocity.y > 0)
            {
                var velocity = rigidbody.linearVelocity;
                velocity.y *= _multiplier.Value;
                rigidbody.linearVelocity = velocity;
            }
#else
            if (rigidbody.velocity.y > 0)
            {
                var velocity = rigidbody.velocity;
                velocity.y *= _multiplier.Value;
                rigidbody.velocity = velocity;
            }
#endif
        }
        
        public override string GetSummary() => "Reduce {_rigidbody} jump speed by {_multiplier} when {_isJumping} is false";
    }
}