#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Remove the binding override from a specific InputAction binding.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionRemoveBindingOverride : BaseAction
    {
        [Tooltip("The InputAction.")]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        [Tooltip("Index of the binding whose override should be removed.")]
        [SerializeField]
        private IntegerVar _bindingIndex;

        public override bool CanExecute() => CheckParameters(_bindingIndex);

        public override void Execute()
        {
            var action = InputActionBindingOverrideHelper.ResolveAction(_inputAction);
            var bindingIndex = _bindingIndex.Value;
            if (!InputActionBindingOverrideHelper.HasValidBindingIndex(action, bindingIndex, Owner, nameof(InputActionRemoveBindingOverride)))
            {
                return;
            }

            action.RemoveBindingOverride(bindingIndex);
        }

        public override string GetSummary() => "Remove binding override from {_inputAction} binding {_bindingIndex}";
    }
}

#endif
