#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.InputSystem.PlayerInput)]
    [ActionDescription("Reads a Vector2 look delta or stick action from a PlayerInput component and rotates separate horizontal and vertical transforms. " +
                       "Use a binding like <Mouse>/delta, <Pointer>/delta, or <Gamepad>/rightStick; do not bind this to pointer position.")]
    [HelpURL(HelpUrls.PlayerInput + "#UnityEngine_InputSystem_PlayerInput_actions")]
    public sealed class PlayerInputSimpleLook : PlayerInputReadValueBase
    {
        [OwnerDefaultValue]
        [SerializeField]
        [Tooltip(
            "The transform rotated horizontally around its local Y axis. " +
            "This is normally the player root.")]
        private TransformVar _horizontalTransform;

        [SerializeField]
        [Tooltip(
            "The transform rotated vertically around its local X axis. " +
            "This is normally a camera holder or look pivot.")]
        private TransformVar _verticalTransform;

        [SerializeField, DefaultValue(1f)]
        [Tooltip("Multiplier applied to horizontal input.")]
        private FloatVar _horizontalSensitivity;

        [SerializeField, DefaultValue(1f)]
        [Tooltip("Multiplier applied to vertical input.")]
        private FloatVar _verticalSensitivity;

        [SerializeField, DefaultValue(false)]
        [Tooltip("Invert horizontal look input.")]
        private BoolVar _invertHorizontal;

        [SerializeField]
        [Tooltip("Invert vertical look input.")]
        private BoolVar _invertVertical;

        [SerializeField, DefaultValue(-80f)]
        [Tooltip("The minimum vertical look angle.")]
        private FloatVar _minimumVerticalAngle;

        [SerializeField, DefaultValue(80f)]
        [Tooltip("The maximum vertical look angle.")]
        private FloatVar _maximumVerticalAngle;

        [NonSerialized]
        private float _verticalAngle;

        public override void Reset()
        {
            if (_actionName == null)
            {
                _actionName = new StringVar();
            }

            _actionName.Value = "Look";
        }

        public override bool CanExecute() =>
            base.CanExecute() &&
            CheckParameters(
                _horizontalTransform,
                _verticalTransform,
                _horizontalSensitivity,
                _verticalSensitivity,
                _minimumVerticalAngle,
                _maximumVerticalAngle);

        public override string ErrorCheck()
        {
            if (_horizontalTransform.Value != null &&
                _horizontalTransform.Value == _verticalTransform.Value)
            {
                return "@_verticalTransform:Horizontal Transform and Vertical Transform cannot be the same. Use separate yaw and pitch pivots.";
            }

            if (_minimumVerticalAngle.Value > _maximumVerticalAngle.Value)
            {
                return "@_minimumVerticalAngle:Minimum Vertical Angle must be less than or equal to Maximum Vertical Angle.";
            }

            return string.Empty;
        }

        public override void OnStart()
        {
            var verticalTransform = _verticalTransform.Value;
            if (verticalTransform == null)
            {
                return;
            }

            _verticalAngle = NormalizeAngle(
                verticalTransform.localEulerAngles.x);

            _verticalAngle = Mathf.Clamp(
                _verticalAngle,
                _minimumVerticalAngle.Value,
                _maximumVerticalAngle.Value);

            ApplyVerticalRotation(verticalTransform);
        }

        public override void Execute()
        {
            var action = GetInputAction();
            if (action is not { enabled: true })
            {
                return;
            }

            var horizontalTransform = _horizontalTransform.Value;
            var verticalTransform = _verticalTransform.Value;
            if (horizontalTransform == null || verticalTransform == null)
            {
                return;
            }

            var lookInput = action.ReadValue<Vector2>();

            var horizontalSign = _invertHorizontal.Value ? -1f : 1f;
            var verticalSign = _invertVertical.Value ? -1f : 1f;

            var horizontalInput =
                lookInput.x * _horizontalSensitivity.Value * horizontalSign;

            horizontalTransform.Rotate(
                0f,
                horizontalInput,
                0f,
                Space.Self);

            var verticalInput =
                -lookInput.y * _verticalSensitivity.Value * verticalSign;

            ApplyVerticalRotation(
                verticalTransform,
                verticalInput);
        }

        private void ApplyVerticalRotation(
            Transform verticalTransform,
            float rotationAmount)
        {
            _verticalAngle = Mathf.Clamp(
                _verticalAngle + rotationAmount,
                _minimumVerticalAngle.Value,
                _maximumVerticalAngle.Value);

            ApplyVerticalRotation(verticalTransform);
        }

        private void ApplyVerticalRotation(Transform verticalTransform)
        {
            verticalTransform.localRotation =
                Quaternion.Euler(_verticalAngle, 0f, 0f);
        }

        private static float NormalizeAngle(float angle)
        {
            angle %= 360f;

            if (angle > 180f)
            {
                angle -= 360f;
            }

            return angle;
        }

        public override string GetSummary() =>
            "Simple Look {_playerInput} {_actionName}: " +
            "{_horizontalTransform} {_verticalTransform} " +
            "Horizontal {_horizontalSensitivity} Vertical {_verticalSensitivity}";
    }
}

#endif
