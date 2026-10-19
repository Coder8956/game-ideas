#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Start an interactive rebinding operation for an InputAction binding.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionPerformInteractiveRebinding : BaseOnEventAction
    {
        [Tooltip("The InputAction to rebind.")]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        [Tooltip("Index of the binding to rebind. If -1, the first non-composite binding is used. For composites, use the part binding index, not the composite root.")]
        [SerializeField, DefaultValue(-1)]
        private IntegerVar _bindingIndex;

        [Tooltip("Only allow controls from this binding group/control scheme, for example Keyboard&Mouse or Gamepad.")]
        [SerializeField, OptionalField]
        private StringVar _bindingGroup;

        [Tooltip("Control path that cancels the rebind. Leave empty to use Unity's default behavior.")]
        [SerializeField, OptionalField]
        private StringVar _cancelPath;

        [ActionHeader("Events")]

        [Tooltip("Event to send when the rebind completes.")]
        [SerializeField, OptionalField]
        private EventRef _completedEvent;

        [Tooltip("Event to send when the rebind is canceled.")]
        [SerializeField, OptionalField]
        private EventRef _canceledEvent;

        [Tooltip("Event to send if the rebind could not be started.")]
        [SerializeField, OptionalField]
        private EventRef _failedEvent;

        private UnityEngine.InputSystem.InputAction _runtimeAction;
        private UnityEngine.InputSystem.InputActionMap _targetActionMap;
        private InputActionRebindingExtensions.RebindingOperation _operation;
        private bool _targetActionMapWasEnabled;
        private bool _standaloneActionWasEnabled;
        private bool _operationStopped;
        private int _runtimeBindingIndex;

        public override bool CanExecute() => CheckParameters(_inputAction);

        public override void OnStart()
        {
            _runtimeAction = InputActionBindingOverrideHelper.ResolveAction(_inputAction);
            if (_runtimeAction == null)
            {
                Debug.LogWarning("InputActionPerformInteractiveRebinding: No InputAction assigned.", Owner);
                SendEvent(_failedEvent);
                Finish();
                return;
            }

            _runtimeBindingIndex = _bindingIndex.Value;
            if (_runtimeBindingIndex < 0)
            {
                _runtimeBindingIndex = InputActionBindingOverrideHelper.GetFirstRebindableBindingIndex(_runtimeAction);
            }

            if (!InputActionBindingOverrideHelper.HasValidBindingIndex(_runtimeAction, _runtimeBindingIndex, Owner, nameof(InputActionPerformInteractiveRebinding)))
            {
                SendEvent(_failedEvent);
                Finish();
                return;
            }

            if (_runtimeAction.bindings[_runtimeBindingIndex].isComposite)
            {
                Debug.LogWarning("InputActionPerformInteractiveRebinding: Cannot rebind a composite root binding. Use a composite part binding index.", Owner);
                SendEvent(_failedEvent);
                Finish();
                return;
            }

            try
            {
                StartRebind();
            }
            catch (Exception e)
            {
                Debug.LogWarning($"InputActionPerformInteractiveRebinding: Could not start rebind. {e.Message}", Owner);
                CleanupOperation(cancelOperation: false);
                RestoreActionMaps();
                SendEvent(_failedEvent);
                Finish();
            }
        }

        public override void OnStop()
        {
            CleanupOperation(cancelOperation: !_operationStopped);
            RestoreActionMaps();
        }

        private void StartRebind()
        {
            _targetActionMap = _runtimeAction.actionMap;
            if (_targetActionMap != null)
            {
                _targetActionMapWasEnabled = _targetActionMap.enabled;
                _targetActionMap.Disable();
            }
            else if (_targetActionMap == null)
            {
                _standaloneActionWasEnabled = _runtimeAction.enabled;
                _runtimeAction.Disable();
            }

            _operation = _runtimeAction.PerformInteractiveRebinding(_runtimeBindingIndex);

            if (!string.IsNullOrEmpty(_bindingGroup.Value))
            {
                _operation.WithBindingGroup(_bindingGroup.Value);
            }

            if (!string.IsNullOrEmpty(_cancelPath.Value))
            {
                _operation.WithCancelingThrough(_cancelPath.Value);
            }

            _operation
                .OnComplete(OnRebindComplete)
                .OnCancel(OnRebindCanceled)
                .Start();
        }

        private void OnRebindComplete(InputActionRebindingExtensions.RebindingOperation operation)
        {
            _operationStopped = true;
            CleanupOperation(cancelOperation: false);
            RestoreActionMaps();

            SendEvent(_completedEvent);
            Finish();
        }

        private void OnRebindCanceled(InputActionRebindingExtensions.RebindingOperation operation)
        {
            _operationStopped = true;
            CleanupOperation(cancelOperation: false);
            RestoreActionMaps();

            SendEvent(_canceledEvent);
            Finish();
        }

        private void CleanupOperation(bool cancelOperation)
        {
            if (_operation == null)
            {
                return;
            }

            var operation = _operation;
            _operation = null;

            if (cancelOperation)
            {
                operation.Cancel();
            }

            operation.Dispose();
        }

        private void RestoreActionMaps()
        {
            if (_targetActionMap != null)
            {
                if (_targetActionMapWasEnabled)
                {
                    _targetActionMap.Enable();
                }

                _targetActionMap = null;
                _targetActionMapWasEnabled = false;
            }
            else if (_runtimeAction != null && _standaloneActionWasEnabled)
            {
                _runtimeAction.Enable();
            }

            _standaloneActionWasEnabled = false;
        }

        public override string GetSummary() => "Rebind {_inputAction} binding {_bindingIndex}";
    }
}

#endif
