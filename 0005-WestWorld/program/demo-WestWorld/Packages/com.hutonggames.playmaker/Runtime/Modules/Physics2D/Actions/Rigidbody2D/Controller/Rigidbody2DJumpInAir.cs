using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.Rigidbody2DController)]
    [ConvertibleGroup("Rigidbody2DJump")]
    [ActionDescription("In-air jump action for a Rigidbody2D. Used for double jumps." +
                       "\nSet Jump using an input action like Input Get Button.")]
    public class Rigidbody2DJumpInAir : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdateEveryFrame;

        [Tooltip("The Rigidbody to control.")]
        [SerializeField] private Rigidbody2DVar _rigidbody;
        
        [Tooltip("Assign a variable that is true to try to jump. " +
                 "Use an input action like Input Get Button to set this.")]
        [SerializeField] 
        private BoolRef _jump;
        
        [Tooltip("The upward speed to apply when jumping.")]
        [SerializeField, DefaultValue(16f)] 
        private FloatVar _jumpSpeed;

        [OptionalField]
        [Tooltip("Assign a variable to track the number of jumps taken. " +
                 "Reset this variable to zero when grounded. Or reset it with a Power-up to keep jumping!")]
        [SerializeField, WriteOnly]
        private IntegerRef _jumpCount;
        
        [Tooltip("The maximum number of in-air jumps allowed. Set to 1 for a double jump, 2 for a triple jump, etc.")]
        [SerializeField, DefaultValue(1)]
        private IntegerVar _maxJumps;
        
        public override bool CanExecute() => CheckParameters(_rigidbody, _jump, _jumpSpeed);
        
        private bool _jumpButtonDownLastFrame;
        private int _jumpCountInternal;

        public override void OnStart()
        {
            _jumpButtonDownLastFrame = _jump.Value;
            _jumpCountInternal = 0;
        }
        
        public override void Execute()
        {
            var rigidbody = _rigidbody.Value;
            var jumpButtonPressed = !_jumpButtonDownLastFrame && _jump.Value;
            
            if (jumpButtonPressed && CanJump())
            {
#if UNITY_6000_0_OR_NEWER
                rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, _jumpSpeed.Value);
#else
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, _jumpSpeed.Value);
#endif
                IncrementJumpCount();
            }
            
            _jumpButtonDownLastFrame = _jump.Value;
        }
        
        private bool CanJump()
        {
            if (_jumpCount.IsAssigned)
            {
                return _jumpCount.Value < _maxJumps.Value;
            }
            return _jumpCountInternal < _maxJumps.Value;
        }

        private void IncrementJumpCount()
        {
            if (_jumpCount.IsAssigned)
            {
                _jumpCount.Value++;
                _jumpCountInternal = _jumpCount.Value;
            }
            else
            {
                _jumpCountInternal++;
            }
            
            if (_jumpCountInternal == _maxJumps.Value)
            {
                Finish();
            }
        }

        public override string GetSummary() => "Jump {_rigidbody} Speed: {_jumpSpeed} Max Jumps: {_maxJumps}";
    }
}
