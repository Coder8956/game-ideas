#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Save all binding overrides on an InputAction as JSON.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionSaveBindingOverridesAsJson : BaseAction
    {
        [Tooltip("The InputAction.")]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        [Tooltip("Store the binding override JSON.")]
        [SerializeField, WriteOnly]
        private StringRef _json;

        public override bool CanExecute() => CheckParameters(_json);

        public override void Execute()
        {
            var action = InputActionBindingOverrideHelper.ResolveAction(_inputAction);
            if (action == null)
            {
                Debug.LogWarning("InputActionSaveBindingOverridesAsJson: No InputAction assigned.", Owner);
                _json.Value = string.Empty;
                return;
            }

            _json.Value = action.SaveBindingOverridesAsJson();
        }

        public override string GetSummary() => "Save {_inputAction} binding overrides -> {_json}";
    }
}

#endif
