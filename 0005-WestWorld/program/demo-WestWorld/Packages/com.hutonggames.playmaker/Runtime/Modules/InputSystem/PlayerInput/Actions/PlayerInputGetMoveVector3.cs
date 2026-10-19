#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.InputSystem.PlayerInput)]
    [ActionDescription("Gets a world direction Vector3 from a Vector2 action in a PlayerInput component. " +
                       "Works like Input Get Axis Vector3 for the old Input System.")]
    [HelpURL(HelpUrls.PlayerInput+"#UnityEngine_InputSystem_PlayerInput_actions")]
    public sealed class PlayerInputGetMoveVector3 : PlayerInputReadValueBase
    {
        public enum AxisPlane
        {
            XZ,
            XY,
            YZ
        }

        [Tooltip("Clamp the input vector so that its magnitude is never greater than 1. " +
                 "<br/>E.g. so a diagonal input vector isn't larger than a horizontal or vertical input vector.")]
        [SerializeField]
        [DefaultValue(true)]
        private BoolVar _clampInput;

        [FormerlySerializedAs("multiplier")]
        [Tooltip("Normally move values are in the range -1 to 1. Use the multiplier to make this range bigger. " +
                 "<br/>E.g., A multiplier of 100 returns values from -100 to 100. Typically this represents the maximum movement speed.")]
        [SerializeField]
        [DefaultValue(1f)]
        private FloatVar _multiplier;

        [ActionHeader("Space")]

        [FormerlySerializedAs("mapToPlane")]
        [Tooltip("Sets the plane the input maps to. XZ is typically used for ground movement.")]
        [SerializeField]
        private AxisPlane _mapToPlane;

        [FormerlySerializedAs("relativeTo")]
        [Tooltip("Optionally calculate the move vector relative to a GameObject, e.g. the camera for third person movement. " +
                 "The output is still a world-space direction; do not also enable Local Space on the action that uses this vector.")]
        [SerializeField, OptionalField]
        private GameObjectVar _relativeTo;

        [ActionHeader("Output")]

        [FormerlySerializedAs("storeMoveVector")]
        [Tooltip("Store the move vector in a Vector3 variable.")]
        [SerializeField, WriteOnly, OptionalField]
        private Vector3Ref _storeVector;

        [FormerlySerializedAs("storeMagnitude")]
        [Tooltip("Store the magnitude of the input in a float variable. This value is always between 0 and 1 when Clamp Input is enabled.")]
        [SerializeField, WriteOnly, OptionalField]
        private FloatRef _storeMagnitude;

        public override void Reset()
        {
            if (_actionName == null)
            {
                _actionName = new StringVar();
            }

            _actionName.Value = "Move";
        }

        public override bool CanExecute() =>
            (_storeVector?.IsAssigned == true || _storeMagnitude?.IsAssigned == true) && base.CanExecute();

        public override void Execute()
        {
            var action = GetInputAction();
            var input = action?.ReadValue<Vector2>() ?? Vector2.zero;
            var moveVector = GetMoveVector(input);

            if (_clampInput?.Value != false)
            {
                moveVector = Vector3.ClampMagnitude(moveVector, 1f);
            }

            if (_storeVector?.IsAssigned == true)
            {
                _storeVector.Value = moveVector * (_multiplier?.Value ?? 1f);
            }

            if (_storeMagnitude?.IsAssigned == true)
            {
                _storeMagnitude.Value = moveVector.magnitude;
            }
        }

        private Vector3 GetMoveVector(Vector2 input)
        {
            var forward = Vector3.zero;
            var right = Vector3.zero;
            var relativeTo = _relativeTo?.Value;

            if (relativeTo == null)
            {
                switch (_mapToPlane)
                {
                    case AxisPlane.XZ:
                        forward = Vector3.forward;
                        right = Vector3.right;
                        break;
                    case AxisPlane.XY:
                        forward = Vector3.up;
                        right = Vector3.right;
                        break;
                    case AxisPlane.YZ:
                        forward = Vector3.up;
                        right = Vector3.forward;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                var transform = relativeTo.transform;

                switch (_mapToPlane)
                {
                    case AxisPlane.XZ:
                        forward = transform.TransformDirection(Vector3.forward);
                        forward.y = 0;
                        forward = forward.normalized;
                        right = new Vector3(forward.z, 0, -forward.x);
                        break;
                    case AxisPlane.XY:
                    case AxisPlane.YZ:
                        forward = Vector3.up;
                        forward.z = 0;
                        forward = forward.normalized;
                        right = transform.TransformDirection(Vector3.right);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return input.x * right + input.y * forward;
        }

        public override string GetSummary() =>
            "Get {_playerInput} {_actionName} move vector on {_mapToPlane} " +
            (_multiplier.IsNotDefault(1f) ? " x {_multiplier}" : "") +
            " {_storeVector:output} {_storeMagnitude:output}";
    }
}

#endif
