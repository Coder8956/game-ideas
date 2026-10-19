#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Get detailed information about an InputAction binding.")]
    [HelpURL(HelpUrls.InputAction + "#UnityEngine_InputSystem_InputAction_bindings")]
    public sealed class InputActionGetBindingInfo : BaseAction
    {
        [Tooltip("The InputAction.")]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        [Tooltip("Index of the binding to inspect.")]
        [SerializeField]
        private IntegerVar _bindingIndex;

        [Tooltip("Use longer display names instead of short labels.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _dontUseShortDisplayNames;

        [Tooltip("Ignore binding overrides when generating the display string.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _ignoreBindingOverrides;

        [ActionHeader("Output")]

        [Tooltip("Store whether the binding index was found.")]
        [SerializeField, WriteOnly, OptionalField]
        private BoolRef _found;

        [Tooltip("Store the binding name. Composite part bindings use names like Up, Down, Left, Right, Positive, or Negative.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _name;

        [Tooltip("Store the binding id.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _id;

        [Tooltip("Store the original binding path.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _path;

        [Tooltip("Store the binding path after applying overrides.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _effectivePath;

        [Tooltip("Store the binding override path.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _overridePath;

        [Tooltip("Store the binding groups/control schemes.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _groups;

        [Tooltip("Store binding interactions.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _interactions;

        [Tooltip("Store binding processors.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _processors;

        [Tooltip("Store the human-readable binding display string.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _displayString;

        [Tooltip("Store the device layout name for icon lookup.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _deviceLayoutName;

        [Tooltip("Store the control path for icon lookup.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _controlPath;

        [Tooltip("Store whether this binding is a composite root.")]
        [SerializeField, WriteOnly, OptionalField]
        private BoolRef _isComposite;

        [Tooltip("Store whether this binding is part of a composite.")]
        [SerializeField, WriteOnly, OptionalField]
        private BoolRef _isPartOfComposite;

        [Tooltip("Store whether this binding has an override path.")]
        [SerializeField, WriteOnly, OptionalField]
        private BoolRef _hasOverride;

        public override bool CanExecute() => CheckParameters(_inputAction, _bindingIndex);

        public override void Execute()
        {
            ClearOutputs(found: false);

            var action = InputActionBindingOverrideHelper.ResolveAction(_inputAction);
            var bindingIndex = _bindingIndex.Value;

            if (!InputActionBindingOverrideHelper.HasValidBindingIndex(action, bindingIndex, Owner, nameof(InputActionGetBindingInfo)))
            {
                return;
            }

            var binding = action.bindings[bindingIndex];

            if (_found.IsAssigned) _found.Value = true;
            if (_name.IsAssigned) _name.Value = binding.name;
            if (_id.IsAssigned) _id.Value = binding.id.ToString();
            if (_path.IsAssigned) _path.Value = binding.path;
            if (_effectivePath.IsAssigned) _effectivePath.Value = binding.effectivePath;
            if (_overridePath.IsAssigned) _overridePath.Value = binding.overridePath;
            if (_groups.IsAssigned) _groups.Value = binding.groups;
            if (_interactions.IsAssigned) _interactions.Value = binding.interactions;
            if (_processors.IsAssigned) _processors.Value = binding.processors;
            if (_isComposite.IsAssigned) _isComposite.Value = binding.isComposite;
            if (_isPartOfComposite.IsAssigned) _isPartOfComposite.Value = binding.isPartOfComposite;
            if (_hasOverride.IsAssigned) _hasOverride.Value = !string.IsNullOrEmpty(binding.overridePath);

            if (_displayString.IsAssigned || _deviceLayoutName.IsAssigned || _controlPath.IsAssigned)
            {
                var options = InputActionBindingOverrideHelper.GetDisplayStringOptions(
                    _dontUseShortDisplayNames.Value,
                    _ignoreBindingOverrides.Value);

                var displayString = action.GetBindingDisplayString(
                    bindingIndex,
                    out var deviceLayoutName,
                    out var controlPath,
                    options);

                if (_displayString.IsAssigned) _displayString.Value = displayString;
                if (_deviceLayoutName.IsAssigned) _deviceLayoutName.Value = deviceLayoutName;
                if (_controlPath.IsAssigned) _controlPath.Value = controlPath;
            }
        }

        private void ClearOutputs(bool found)
        {
            if (_found.IsAssigned) _found.Value = found;
            if (_name.IsAssigned) _name.Value = string.Empty;
            if (_id.IsAssigned) _id.Value = string.Empty;
            if (_path.IsAssigned) _path.Value = string.Empty;
            if (_effectivePath.IsAssigned) _effectivePath.Value = string.Empty;
            if (_overridePath.IsAssigned) _overridePath.Value = string.Empty;
            if (_groups.IsAssigned) _groups.Value = string.Empty;
            if (_interactions.IsAssigned) _interactions.Value = string.Empty;
            if (_processors.IsAssigned) _processors.Value = string.Empty;
            if (_displayString.IsAssigned) _displayString.Value = string.Empty;
            if (_deviceLayoutName.IsAssigned) _deviceLayoutName.Value = string.Empty;
            if (_controlPath.IsAssigned) _controlPath.Value = string.Empty;
            if (_isComposite.IsAssigned) _isComposite.Value = false;
            if (_isPartOfComposite.IsAssigned) _isPartOfComposite.Value = false;
            if (_hasOverride.IsAssigned) _hasOverride.Value = false;
        }

        public override string GetSummary()
        {
            var summary = "Get {_inputAction} binding {_bindingIndex} info";

            if (_found.IsAssigned) summary += " {_found:output}";
            if (_name.IsAssigned) summary += " {_name:output}";
            if (_id.IsAssigned) summary += " {_id:output}";
            if (_path.IsAssigned) summary += " {_path:output}";
            if (_effectivePath.IsAssigned) summary += " {_effectivePath:output}";
            if (_overridePath.IsAssigned) summary += " {_overridePath:output}";
            if (_groups.IsAssigned) summary += " {_groups:output}";
            if (_interactions.IsAssigned) summary += " {_interactions:output}";
            if (_processors.IsAssigned) summary += " {_processors:output}";
            if (_displayString.IsAssigned) summary += " {_displayString:output}";
            if (_deviceLayoutName.IsAssigned) summary += " {_deviceLayoutName:output}";
            if (_controlPath.IsAssigned) summary += " {_controlPath:output}";
            if (_isComposite.IsAssigned) summary += " {_isComposite:output}";
            if (_isPartOfComposite.IsAssigned) summary += " {_isPartOfComposite:output}";
            if (_hasOverride.IsAssigned) summary += " {_hasOverride:output}";
            
            return summary;
        }
    }
}

#endif
