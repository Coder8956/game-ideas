using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.CharacterController)]
    [ConvertibleGroup("CharacterControllerGrounded")]
    [ActionDescription("Checks the CharacterController's isGrounded property. " +
                       "Note: isGrounded can be unreliable, especially on slopes and steps. " +
                       "If it's not working as expected, consider using Check Is Falling instead " +
                       "because it performs some extra checks. " +
                       "<br/>This check pairs best with CharacterControllerMoveInAir for controllable airborne states.")]
    public sealed class CharacterControllerCheckIsGrounded : BaseTrueFalseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [Tooltip("The CharacterController to check.")] [SerializeField, OwnerDefaultValue]
        private CharacterControllerVar _characterController;

        [Tooltip("Use this to add a small grace period to the check. " +
                 "This can also help fix 'flickering' of the isGrounded property which can be finicky.")]
        [SerializeField, DefaultValue(0.1f)]
        private FloatVar _coyoteTime;

        private float _coyoteTimeCounter;
        private bool _wasGroundedLastFrame;

        public override bool CanExecute() => CheckParameters(_characterController) && base.CanExecute();

        public override void OnStart()
        {
            _coyoteTimeCounter = 0f;
            _wasGroundedLastFrame = false;
        }

        protected override bool Test()
        {
            var controller = _characterController.Value;
            if (!controller) return false;

            bool isGroundedNow = controller.isGrounded;

            // Reset coyote time when touching ground
            if (isGroundedNow)
            {
                _coyoteTimeCounter = 0f;
                _wasGroundedLastFrame = true;
                return true;
            }

            // Start coyote time only when we just left the ground
            if (_wasGroundedLastFrame)
            {
                _coyoteTimeCounter = 0f;
                _wasGroundedLastFrame = false;
            }

            // Increment counter only during coyote time window
            if (_coyoteTimeCounter < _coyoteTime.Value)
            {
                _coyoteTimeCounter += Time.deltaTime;
            }

            return _coyoteTimeCounter < _coyoteTime.Value;
        }

        protected override string TrueSummary => "{_characterController} is grounded";
        protected override string FalseSummary => "{_characterController} is not grounded";
    }
}
