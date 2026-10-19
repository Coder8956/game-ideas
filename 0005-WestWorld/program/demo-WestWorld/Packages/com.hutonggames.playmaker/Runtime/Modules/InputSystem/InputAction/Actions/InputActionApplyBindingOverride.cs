#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Apply a non-destructive binding override to an InputAction binding.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionApplyBindingOverride : BaseAction
    {
        [Tooltip("The InputAction.")]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        [Tooltip("Index of the binding to override. Use InputActionFindBindingIndex or InputActionGetBindingCount to inspect binding indices. If -1, the first non-composite binding is used.")]
        [SerializeField, DefaultValue(-1)]
        private IntegerVar _bindingIndex;

        [Tooltip("The control path to apply as the binding override, for example <Keyboard>/space or <Gamepad>/buttonSouth.")]
        [SerializeField]
        private StringVar _overridePath;

        public override bool CanExecute() => CheckParameters(_overridePath);

        public override void Execute()
        {
            var action = InputActionBindingOverrideHelper.ResolveAction(_inputAction);
            var bindingIndex = _bindingIndex.Value;
            if (bindingIndex < 0)
            {
                bindingIndex = InputActionBindingOverrideHelper.GetFirstRebindableBindingIndex(action);
            }

            if (!InputActionBindingOverrideHelper.HasValidBindingIndex(action, bindingIndex, Owner, nameof(InputActionApplyBindingOverride)))
            {
                return;
            }

            action.ApplyBindingOverride(bindingIndex, _overridePath.Value);
        }

        public override string GetSummary() => "Apply binding override {_overridePath} to {_inputAction} binding {_bindingIndex}";
    }
}

#endif
