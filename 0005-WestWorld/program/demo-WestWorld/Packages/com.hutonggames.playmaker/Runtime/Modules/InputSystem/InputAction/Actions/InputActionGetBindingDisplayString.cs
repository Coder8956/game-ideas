#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Get a human-readable display string for an InputAction binding.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionGetBindingDisplayString : BaseAction
    {
        [Tooltip("The InputAction.")]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        [Tooltip("Index of the binding to display. If -1, returns a display string for the action as a whole.")]
        [SerializeField, DefaultValue(-1)]
        private IntegerVar _bindingIndex;

        [Tooltip("Use longer display names instead of short labels.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _dontUseShortDisplayNames;

        [Tooltip("Ignore binding overrides when generating the display string.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _ignoreBindingOverrides;

        [Tooltip("Store the human-readable binding display string.")]
        [SerializeField, WriteOnly]
        private StringRef _displayString;

        [Tooltip("Store the device layout name for icon lookup. Only available when a specific binding index is used.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _deviceLayoutName;

        [Tooltip("Store the control path for icon lookup. Only available when a specific binding index is used.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _controlPath;

        public override bool CanExecute() => CheckParameters(_displayString);

        public override void Execute()
        {
            var action = InputActionBindingOverrideHelper.ResolveAction(_inputAction);
            if (action == null)
            {
                Debug.LogWarning("InputActionGetBindingDisplayString: No InputAction assigned.", Owner);
                _displayString.Value = string.Empty;
                _deviceLayoutName.Value = string.Empty;
                _controlPath.Value = string.Empty;
                return;
            }

            var options = InputActionBindingOverrideHelper.GetDisplayStringOptions(
                _dontUseShortDisplayNames.Value,
                _ignoreBindingOverrides.Value);

            var bindingIndex = _bindingIndex.Value;
            if (bindingIndex < 0)
            {
                _displayString.Value = action.GetBindingDisplayString(options);
                _deviceLayoutName.Value = string.Empty;
                _controlPath.Value = string.Empty;
                return;
            }

            if (!InputActionBindingOverrideHelper.HasValidBindingIndex(action, bindingIndex, Owner, nameof(InputActionGetBindingDisplayString)))
            {
                _displayString.Value = string.Empty;
                _deviceLayoutName.Value = string.Empty;
                _controlPath.Value = string.Empty;
                return;
            }

            _displayString.Value = action.GetBindingDisplayString(bindingIndex, out var deviceLayoutName, out var controlPath, options);
            _deviceLayoutName.Value = deviceLayoutName;
            _controlPath.Value = controlPath;
        }

        public override string GetSummary() => "Get {_inputAction} binding {_bindingIndex} display string -> {_displayString}";
    }
}

#endif
