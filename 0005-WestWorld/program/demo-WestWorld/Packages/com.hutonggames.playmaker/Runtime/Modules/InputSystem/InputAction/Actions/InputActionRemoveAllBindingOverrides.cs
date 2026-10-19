#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Remove all binding overrides from an InputAction.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionRemoveAllBindingOverrides : BaseAction
    {
        [Tooltip("The InputAction.")]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        public override void Execute()
        {
            var action = InputActionBindingOverrideHelper.ResolveAction(_inputAction);
            if (action == null)
            {
                Debug.LogWarning("InputActionRemoveAllBindingOverrides: No InputAction assigned.", Owner);
                return;
            }

            action.RemoveAllBindingOverrides();
        }

        public override string GetSummary() => "Remove all binding overrides from {_inputAction}";
    }
}

#endif
