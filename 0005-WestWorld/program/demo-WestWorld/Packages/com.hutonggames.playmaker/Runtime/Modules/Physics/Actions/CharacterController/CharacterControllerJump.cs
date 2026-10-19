using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.CharacterController)]
    [ActionDescription("Calculates the initial jump velocity for a CharacterController." +
                       "<br/>Feed the output into Move In Air, Fall, Glide, or another in-air action that owns movement while airborne.")]
    public class CharacterControllerJump : BaseAction
    {
        public override UpdateMode AllowedUpdateModes => UpdateMode.AllUpdates;
        
        [Tooltip("The CharacterController")]
        [SerializeField, OwnerDefaultValue]
        private CharacterControllerVar _characterController;

        [Tooltip("How high to jump.")]
        [SerializeField, DefaultValue(0.5f)]
        private FloatVar _jumpHeight;

        [OptionalField]
        [FormerlySerializedAs("_motion")]
        [Tooltip("Optional horizontal velocity to carry into the jump. " +
                 "X and Z are used. Y is ignored because jump height is calculated from Jump Height and Gravity Multiplier. " +
                 "<br/>If not set, the CharacterController velocity is used.")]
        [SerializeField]
        private Vector3Ref _horizontalVelocity;

        [Tooltip("Jump in local or word space.")]
        [SerializeField]
        private SpaceVar _space;
        
        [Tooltip("Multiplies the speed of the CharacterController at moment of jumping. " +
                 "Higher numbers will jump further horizontally, but does not effect the jump height.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _jumpSpeedMultiplier;

        [Tooltip("Gravity multiplier used to calculate jump height. " +
                 "This should match any multiplier used in Move In Air or Fall actions.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _gravityMultiplier;

        [OptionalField]
        [Tooltip("Optional jump velocity output. Feed this into the Motion input of in-air movement actions.")]
        [SerializeField]
        [WriteOnly]
        private Vector3Ref _jumpVelocity;

        [NonSerialized] private Transform _transform;

        public override bool CanExecute() => 
            CheckParameters(_characterController, _jumpHeight, _space, _jumpSpeedMultiplier, _gravityMultiplier);

        public override void OnStart()
        {
            var controller = _characterController.Value;
            _transform = controller.transform;

            // Prefer explicit motion passed from the previous state, then fall back to the current controller velocity.
            var horizontalMotion = _horizontalVelocity.IsNone ? controller.velocity : _horizontalVelocity.Value;
            horizontalMotion.y = 0f; // for consistent jump height

            if (_space.Value == Space.Self && _horizontalVelocity.IsNone)
            {
                horizontalMotion = _transform.InverseTransformDirection(horizontalMotion);
            }

            horizontalMotion *= _jumpSpeedMultiplier.Value;

            // Calculate the move required to reach the desired jump height

            var gravity = Physics.gravity.y * _gravityMultiplier.Value;
            var verticalMotion = gravity < 0f
                ? Mathf.Sqrt(_jumpHeight.Value * -3.0f * gravity)
                : Mathf.Max(_jumpHeight.Value / Mathf.Max(Time.deltaTime, 0.0001f), 0f);
            _jumpVelocity.Value = new Vector3(horizontalMotion.x, verticalMotion, horizontalMotion.z);
        }

        public override string GetSummary() => "{_characterController} jump to {_jumpHeight} {_jumpVelocity:output}";
    }
}
