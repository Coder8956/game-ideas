using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.CharacterController)]
    [ConvertibleGroup("CharacterControllerMove")]
    [ActionDescription("Calls Move on a CharacterController for grounded movement. " +
                       "The X and Z motion come from the move vector. " +
                       "When Y motion is not upward, a configurable downward velocity keeps the controller grounded on slopes while preserving upward platform motion.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController.Move.html")]
    public sealed class CharacterControllerMoveOnGround : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [Tooltip("The CharacterController to move.")]
        [SerializeField, OwnerDefaultValue]
        private CharacterControllerVar _characterController;

        [Tooltip("Moves the GameObject in the given direction. The X and Z values are used. " +
                 "Positive Y values are preserved for upward platform motion; otherwise Downward Velocity is applied." + Strings.PerSecondNote)]
        [SerializeField]
        private Vector3Var _motion;

        [Tooltip("Scale the horizontal motion by this value.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _multiplier;

        [Tooltip("Move in local space instead of world space.")]
        [SerializeField]
        private BoolVar _localSpace;

        [Tooltip("Downward velocity used while grounded to keep the CharacterController pressed to the ground.")]
        [SerializeField, DefaultValue(-2f)]
        private FloatVar _downwardVelocity;

        [OptionalField]
        [Tooltip("Indicates the direction of a collision: None, Sides, Above, and Below.")]
        [SerializeField, WriteOnly]
        private CollisionFlagsRef _collisionFlags;

        public override bool CanUsePerSecond => true;

        public override bool CanExecute() =>
            CheckParameters(_characterController, _motion, _multiplier, _downwardVelocity);

        public override void Execute()
        {
            var controller = _characterController.Value;
            if (!controller)
            {
                return;
            }

            var move = _motion.Value * (_multiplier.Value * PerSecond);
            if (move.y <= 0f)
            {
                move.y = Mathf.Min(move.y, -Mathf.Abs(_downwardVelocity.Value) * PerSecond);
            }

            if (_localSpace.Value)
            {
                move = controller.transform.TransformDirection(move);
            }

            var collisionFlags = controller.Move(move);
            if (_collisionFlags != null)
            {
                _collisionFlags.Value = collisionFlags;
            }
        }

        public override string GetSummary() =>
            "Move {_characterController} on ground by {_motion}"
            + (Mathf.Approximately(_multiplier.Value, 1f) ? string.Empty : " x {_multiplier}")
            + " and Y: {_downwardVelocity} {_collisionFlags:output}";
    }
}
