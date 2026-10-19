#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Find the first InputAction binding index that matches the supplied filters.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionFindBindingIndex : BaseAction
    {
        [Tooltip("The InputAction.")]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        [Tooltip("Only match bindings in this binding group/control scheme, for example Keyboard&Mouse or Gamepad.")]
        [SerializeField, OptionalField]
        private StringVar _bindingGroup;

        [Tooltip("Only match bindings with this name. Composite part bindings use names like Up, Down, Left, Right, Positive, or Negative.")]
        [SerializeField, OptionalField]
        private StringVar _bindingName;

        [Tooltip("Only match the binding with this binding id.")]
        [SerializeField, OptionalField]
        private StringVar _bindingId;

        [Tooltip("Only match this binding path or effective path, for example <Keyboard>/space.")]
        [SerializeField, OptionalField]
        private StringVar _bindingPath;

        [Tooltip("Include composite root bindings in the search.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _includeCompositeBindings;

        [Tooltip("Include composite part bindings in the search.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _includeCompositeParts;

        [Tooltip("Store the first matching binding index, or -1 if no binding matched.")]
        [SerializeField, WriteOnly]
        private IntegerRef _result;

        [Tooltip("Store whether a binding was found.")]
        [SerializeField, WriteOnly, OptionalField]
        private BoolRef _found;

        public override bool CanExecute() => CheckParameters(_result);

        public override void Execute()
        {
            var action = InputActionBindingOverrideHelper.ResolveAction(_inputAction);
            var index = FindBindingIndex(action);

            _result.Value = index;
            if (_found != null)
            {
                _found.Value = index >= 0;
            }
        }

        private int FindBindingIndex(UnityEngine.InputSystem.InputAction action)
        {
            if (action == null) return -1;

            var bindingGroup = _bindingGroup.Value;
            var bindingName = _bindingName.Value;
            var bindingId = _bindingId.Value;
            var bindingPath = _bindingPath.Value;

            for (var i = 0; i < action.bindings.Count; i++)
            {
                var binding = action.bindings[i];

                if (binding.isComposite && !_includeCompositeBindings.Value) continue;
                if (binding.isPartOfComposite && !_includeCompositeParts.Value) continue;

                if (!string.IsNullOrEmpty(bindingGroup) && !InputBinding.MaskByGroup(bindingGroup).Matches(binding)) continue;
                if (!InputActionBindingOverrideHelper.MatchesText(binding.name, bindingName)) continue;
                if (!InputActionBindingOverrideHelper.MatchesText(binding.id.ToString(), bindingId)) continue;

                if (!string.IsNullOrEmpty(bindingPath) &&
                    !InputActionBindingOverrideHelper.MatchesText(binding.path, bindingPath) &&
                    !InputActionBindingOverrideHelper.MatchesText(binding.effectivePath, bindingPath))
                {
                    continue;
                }

                return i;
            }

            return -1;
        }

        public override string GetSummary() => "Find binding index in {_inputAction} -> {_result}";
    }
}

#endif
