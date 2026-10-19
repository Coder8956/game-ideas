#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Remove binding overrides from a composite binding and all of its parts.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionRemoveCompositeBindingOverrides : BaseAction
    {
        [Tooltip("The InputAction.")]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        [Tooltip("Index of the composite root binding, or any part binding in the composite. If -1, the first composite binding is used.")]
        [SerializeField, DefaultValue(-1)]
        private IntegerVar _bindingIndex;

        public override bool CanExecute() => CheckParameters(_inputAction);

        public override void Execute()
        {
            var action = InputActionBindingOverrideHelper.ResolveAction(_inputAction);
            if (action == null)
            {
                Debug.LogWarning("InputActionRemoveCompositeBindingOverrides: No InputAction assigned.", Owner);
                return;
            }

            var rootIndex = ResolveCompositeRootIndex(action, _bindingIndex.Value);
            if (rootIndex < 0)
            {
                Debug.LogWarning("InputActionRemoveCompositeBindingOverrides: No composite binding found.", Owner);
                return;
            }

            action.RemoveBindingOverride(rootIndex);

            for (var i = rootIndex + 1; i < action.bindings.Count && action.bindings[i].isPartOfComposite; i++)
            {
                action.RemoveBindingOverride(i);
            }
        }

        private static int ResolveCompositeRootIndex(UnityEngine.InputSystem.InputAction action, int bindingIndex)
        {
            if (bindingIndex < 0)
            {
                for (var i = 0; i < action.bindings.Count; i++)
                {
                    if (action.bindings[i].isComposite)
                    {
                        return i;
                    }
                }

                return -1;
            }

            if (bindingIndex >= action.bindings.Count)
            {
                return -1;
            }

            if (action.bindings[bindingIndex].isComposite)
            {
                return bindingIndex;
            }

            if (!action.bindings[bindingIndex].isPartOfComposite)
            {
                return -1;
            }

            for (var i = bindingIndex - 1; i >= 0; i--)
            {
                if (action.bindings[i].isComposite)
                {
                    return i;
                }

                if (!action.bindings[i].isPartOfComposite)
                {
                    break;
                }
            }

            return -1;
        }

        public override string GetSummary() => "Remove composite binding overrides from {_inputAction} binding {_bindingIndex}";
    }
}

#endif
