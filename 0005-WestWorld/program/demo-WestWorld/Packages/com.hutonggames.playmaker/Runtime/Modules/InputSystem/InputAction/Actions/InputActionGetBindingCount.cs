#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Get the number of bindings on an InputAction.")]
    [HelpURL(HelpUrls.InputAction + "#UnityEngine_InputSystem_InputAction_bindings")]
    public sealed class InputActionGetBindingCount : BaseAction
    {
        [Tooltip("The InputAction.")]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        [Tooltip("Store the binding count.")]
        [SerializeField, WriteOnly]
        private IntegerRef _result;

        public override bool CanExecute() => CheckParameters(_result);

        public override void Execute()
        {
            var action = InputActionBindingOverrideHelper.ResolveAction(_inputAction);
            _result.Value = action != null ? action.bindings.Count : 0;
        }

        public override string GetSummary() => "Get {_inputAction} binding count -> {_result}";
    }
}

#endif
