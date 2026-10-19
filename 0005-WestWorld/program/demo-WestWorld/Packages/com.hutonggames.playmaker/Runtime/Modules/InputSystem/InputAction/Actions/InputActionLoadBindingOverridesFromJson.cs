#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Load binding overrides from JSON onto an InputAction.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionLoadBindingOverridesFromJson : BaseAction
    {
        [Tooltip("The InputAction.")]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        [Tooltip("Binding override JSON produced by SaveBindingOverridesAsJson.")]
        [SerializeField]
        private StringVar _json;

        [Tooltip("Remove existing binding overrides before loading the JSON.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _removeExisting;

        public override bool CanExecute() => CheckParameters(_json);

        public override void Execute()
        {
            var action = InputActionBindingOverrideHelper.ResolveAction(_inputAction);
            if (action == null)
            {
                Debug.LogWarning("InputActionLoadBindingOverridesFromJson: No InputAction assigned.", Owner);
                return;
            }

            if (string.IsNullOrEmpty(_json.Value))
            {
                return;
            }

            action.LoadBindingOverridesFromJson(_json.Value, _removeExisting.Value);
        }

        public override string GetSummary() => "Load binding overrides onto {_inputAction}";
    }
}

#endif
