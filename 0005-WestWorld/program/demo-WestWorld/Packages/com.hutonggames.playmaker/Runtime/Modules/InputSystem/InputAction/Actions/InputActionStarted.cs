#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Event that is triggered when the action has been started.")]
    [HelpURL(HelpUrls.InputAction + "#UnityEngine_InputSystem_InputAction_started")]
    public sealed class InputActionStarted : BaseOnEventAction
    {
        [Tooltip("The InputAction to listen to." + Strings.InputActionEnabledNote)]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        [Tooltip("Send Event when the action has been started.")]
        [SerializeField]
        private EventRef _started;

        private InputAction _runtimeAction;

        public override bool CanExecute() => CheckParameters(_inputAction);

        public override void OnStart()
        {
            _runtimeAction = _inputAction.Value.action;
            if (_runtimeAction == null) return;

            // Assume action/map is enabled elsewhere
            _runtimeAction.started += OnInputActionStarted;
        }

        public override void OnStop()
        {
            if (_runtimeAction == null) return;
            
            _runtimeAction.started -= OnInputActionStarted;
            _runtimeAction = null;
        }

        private void OnInputActionStarted(InputAction.CallbackContext ctx)
        {
            SendEvent(_started);
        }

        public override string GetSummary() => "If {_inputAction} started {_started}";
    }
}

#endif
