#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Get the next part binding in an InputAction composite binding and send loop/finished events.")]
    [HelpURL(HelpUrls.InputAction + "#UnityEngine_InputSystem_InputAction_bindings")]
    public sealed class InputActionGetNextCompositePartBinding : BaseAction
    {
        [Tooltip("The InputAction.")]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        [Tooltip("Index of the composite root binding. If -1, the first composite binding is used.")]
        [SerializeField, DefaultValue(-1)]
        private IntegerVar _compositeBindingIndex;

        [Tooltip("Current composite part binding index. Starts at -1 and stores the next part binding index each time the action runs.")]
        [SerializeField]
        private IntegerRef _bindingIndex;

        [Tooltip("Store whether a next composite part binding was found.")]
        [SerializeField, WriteOnly, OptionalField]
        private BoolRef _found;

        [Tooltip("Store the composite root binding index that was used.")]
        [SerializeField, WriteOnly, OptionalField]
        private IntegerRef _rootBindingIndex;

        [Tooltip("Store the name of the next composite part, for example Up, Down, Left, or Right.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _partName;

        [Tooltip("Store whether the next part is the last part in the composite.")]
        [SerializeField, WriteOnly, OptionalField]
        private BoolRef _isLastPart;

        [ActionHeader("Events")]

        [Tooltip("Event sent after finding the next composite part binding.")]
        [SerializeField, OptionalField]
        private EventRef _loopEvent;

        [Tooltip("Event sent when there are no more composite part bindings.")]
        [SerializeField, OptionalField]
        private EventRef _finishedEvent;

        public override bool CanExecute() => CheckParameters(_inputAction, _bindingIndex);

        public override void Execute()
        {
            ClearOutputs();

            var action = InputActionBindingOverrideHelper.ResolveAction(_inputAction);
            if (action == null)
            {
                Debug.LogWarning("InputActionGetNextCompositePartBinding: No InputAction assigned.", Owner);
                FinishLoop();
                return;
            }

            var rootIndex = ResolveCompositeRootIndex(action);
            if (rootIndex < 0)
            {
                Debug.LogWarning("InputActionGetNextCompositePartBinding: No composite binding found.", Owner);
                FinishLoop();
                return;
            }

            if (!InputActionBindingOverrideHelper.HasValidBindingIndex(action, rootIndex, Owner, nameof(InputActionGetNextCompositePartBinding)))
            {
                FinishLoop();
                return;
            }

            if (!action.bindings[rootIndex].isComposite)
            {
                Debug.LogWarning($"InputActionGetNextCompositePartBinding: Binding index {rootIndex} is not a composite root.", Owner);
                FinishLoop();
                return;
            }

            if (_rootBindingIndex.IsAssigned)
            {
                _rootBindingIndex.Value = rootIndex;
            }

            var startIndex = rootIndex + 1;
            if (_bindingIndex.Value >= rootIndex)
            {
                startIndex = _bindingIndex.Value + 1;
            }

            if (startIndex < action.bindings.Count && action.bindings[startIndex].isPartOfComposite)
            {
                var binding = action.bindings[startIndex];
                _bindingIndex.Value = startIndex;
                if (_found.IsAssigned) _found.Value = true;
                if (_partName.IsAssigned) _partName.Value = binding.name;
                if (_isLastPart.IsAssigned) _isLastPart.Value = IsLastCompositePart(action, startIndex);
                SendEvent(_loopEvent);
                return;
            }

            FinishLoop();
        }

        private int ResolveCompositeRootIndex(UnityEngine.InputSystem.InputAction action)
        {
            var rootIndex = _compositeBindingIndex.Value;
            if (rootIndex >= 0)
            {
                return rootIndex;
            }

            for (var i = 0; i < action.bindings.Count; i++)
            {
                if (action.bindings[i].isComposite)
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool IsLastCompositePart(UnityEngine.InputSystem.InputAction action, int bindingIndex)
        {
            var nextIndex = bindingIndex + 1;
            return nextIndex >= action.bindings.Count || !action.bindings[nextIndex].isPartOfComposite;
        }

        private void ClearOutputs()
        {
            if (_found.IsAssigned) _found.Value = false;
            if (_rootBindingIndex.IsAssigned) _rootBindingIndex.Value = -1;
            if (_partName.IsAssigned) _partName.Value = string.Empty;
            if (_isLastPart.IsAssigned) _isLastPart.Value = false;
        }

        private void FinishLoop()
        {
            _bindingIndex.Value = -1;
            SendEvent(_finishedEvent);
        }

        public override string GetSummary() => "Get next composite part in {_inputAction} -> {_bindingIndex}";
    }
}

#endif
