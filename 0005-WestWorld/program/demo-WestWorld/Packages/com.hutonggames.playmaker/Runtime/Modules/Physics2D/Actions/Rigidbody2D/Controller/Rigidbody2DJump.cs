using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.Rigidbody2DController)]
    [ConvertibleGroup("Rigidbody2DJump")]
    [ActionDescription("Jump action for a Rigidbody2D." +
                       "\n\nSet IsGrounded using a Physics2D Check Is Grounded action." +
                       "\nSet Jump using an input action like Input Get Button." +
                       "\n\nThis action includes many parameters that you can tweak to make jumping feel just right." +
                       "For a simpler jump action, use Add Force or Set Velocity instead.")]
    public class Rigidbody2DJump : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdateEveryFrame;

        [Tooltip("The Rigidbody to control.")]
        [SerializeField] private Rigidbody2DVar _rigidbody;

        [Tooltip("Assign a variable that is true if the rigidbody is grounded. " +
                 "Use a Physics2D Check Is Grounded or similar action. " +
                 "Note: grounded actions often include a coyote time setting.")]
        [SerializeField] 
        private BoolRef _isGrounded;

        [Tooltip("Assign a variable that is true to try to jump. " +
                 "Use an input action like Input Get Button to set this.")]
        [SerializeField] 
        private BoolRef _jump;
        
        [Tooltip("The upward speed to apply when jumping.")]
        [SerializeField, DefaultValue(16f)] 
        private FloatVar _jumpSpeed;
        
        [OptionalField]
        [Tooltip("Event sent when the Rigidbody jumps.")]
        [SerializeField]
        private EventRef _jumpEvent;
        
        public override bool CanExecute() => CheckParameters(_rigidbody, _isGrounded, _jump, _jumpSpeed);
        
        private bool _jumpButtonDownLastFrame;

        public override void OnStart()
        {
            _jumpButtonDownLastFrame = _jump.Value;
        }
        
        public override void Execute()
        {
            var rigidbody = _rigidbody.Value;
            
            // The jump button must be released to jump again
            if (CanJump())
            {
#if UNITY_6000_0_OR_NEWER
                rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, _jumpSpeed.Value);
#else
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, _jumpSpeed.Value);
#endif
                SendEvent(_jumpEvent);
            }
            
            _jumpButtonDownLastFrame = _jump.Value;
        }
        
        private bool CanJump()
        {
            var jumpButtonPressed = !_jumpButtonDownLastFrame && _jump.Value;
            return _isGrounded.Value && jumpButtonPressed;
        }
        
        public override string GetSummary() => 
            "Jump {_rigidbody} Speed: {_jumpSpeed}" + ( _jumpEvent.IsSet ? " {_jumpEvent:}" : "");
    }
}