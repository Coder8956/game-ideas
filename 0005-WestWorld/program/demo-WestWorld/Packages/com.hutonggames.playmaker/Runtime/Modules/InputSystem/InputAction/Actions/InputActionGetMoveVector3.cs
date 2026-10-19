#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Gets a world direction Vector3 from a Vector2 InputAction. " +
                       "Works like Input Get Axis Vector3 for the old Input System.")]
    [HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_ReadValue__1")]
    public sealed class InputActionGetMoveVector3 : BaseAction
    {
        public enum AxisPlane
        {
            XZ,
            XY,
            YZ
        }

        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [Tooltip("The InputAction to read from." + Strings.InputActionEnabledNote)]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        [Tooltip("Clamp the input vector so that its magnitude is never greater than 1. " +
                 "<br/>E.g. so a diagonal input vector isn't larger than a horizontal or vertical input vector.")]
        [SerializeField]
        [DefaultValue(true)]
        private BoolVar _clampInput;

        [Tooltip("Normally move values are in the range -1 to 1. Use the multiplier to make this range bigger. " +
                 "<br/>E.g., A multiplier of 100 returns values from -100 to 100. Typically this represents the maximum movement speed.")]
        [SerializeField]
        [DefaultValue(1f)]
        private FloatVar _multiplier;

        [ActionHeader("Space")]

        [Tooltip("Sets the plane the input maps to. XZ is typically used for ground movement.")]
        [SerializeField]
        private AxisPlane _mapToPlane;

        [Tooltip("Optionally calculate the move vector relative to a GameObject, e.g. the camera for third person movement. " +
                 "The output is still a world-space direction; do not also enable Local Space on the action that uses this vector.")]
        [SerializeField, OptionalField]
        private GameObjectVar _relativeTo;

        [ActionHeader("Output")]

        [Tooltip("Store the move vector in a Vector3 variable.")]
        [SerializeField, WriteOnly, OptionalField]
        private Vector3Ref _storeVector;

        [Tooltip("Store the magnitude of the input in a float variable. This value is always between 0 and 1 when Clamp Input is enabled.")]
        [SerializeField, WriteOnly, OptionalField]
        private FloatRef _storeMagnitude;

        public override bool CanExecute() =>
            CheckParameters(_inputAction) &&
            (_storeVector?.IsAssigned == true || _storeMagnitude?.IsAssigned == true);

        public override void Execute()
        {
            var action = _inputAction.Value.action;
            var input = action is { enabled: true }
                ? action.ReadValue<Vector2>()
                : Vector2.zero;

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
            "Get {_inputAction} move vector on {_mapToPlane} " +
            (_multiplier.IsNotDefault(1f) ? " x {_multiplier}" : "") +
            " {_storeVector:output} {_storeMagnitude:output}";
    }
}

#endif
