#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Gets a move Vector2 from an InputAction. " +
                       "Works like Input Get Axis Vector2 for the old Input System.")]
    [HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_ReadValue__1")]
    public sealed class InputActionGetMoveVector2 : BaseAction
    {
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

        [Header("Output")]

        [Tooltip("Store the move vector in a Vector2 variable.")]
        [SerializeField, WriteOnly, OptionalField]
        private Vector2Ref _storeVector;

        [Tooltip("Store the magnitude of the input in a float variable. This value is always between 0 and 1 when Clamp Input is enabled.")]
        [SerializeField, WriteOnly, OptionalField]
        private FloatRef _storeMagnitude;

        public override bool CanExecute() =>
            CheckParameters(_inputAction) &&
            (_storeVector?.IsAssigned == true || _storeMagnitude?.IsAssigned == true);

        public override void Execute()
        {
            var action = _inputAction.Value.action;
            var moveVector = action is { enabled: true }
                ? action.ReadValue<Vector2>()
                : Vector2.zero;

            if (_clampInput?.Value != false)
            {
                moveVector = Vector2.ClampMagnitude(moveVector, 1f);
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

        public override string GetSummary() =>
            "Get {_inputAction} move vector " +
            (_multiplier.IsNotDefault(1f) ? " x {_multiplier}" : "") +
            " {_storeVector:output} {_storeMagnitude:output}";
    }
}

#endif
