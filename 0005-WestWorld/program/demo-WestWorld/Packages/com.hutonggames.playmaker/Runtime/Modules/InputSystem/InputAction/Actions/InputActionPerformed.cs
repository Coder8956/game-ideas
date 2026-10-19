#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputAction)]
    [ActionDescription("Event that is triggered when the action has been fully performed.")]
    [HelpURL(HelpUrls.InputAction + "#UnityEngine_InputSystem_InputAction_performed")]
    public sealed class InputActionPerformed : BaseOnEventAction
    {
        [Tooltip("The InputAction to listen to." + Strings.InputActionEnabledNote)]
        [SerializeField]
        private InputActionReferenceVar _inputAction;

        [Tooltip("Send event when the action has been fully performed.")]
        [SerializeField]
        private EventRef _performed;

        private InputAction _runtimeAction;

        public override bool CanExecute() => CheckParameters(_inputAction);

        public override void OnStart()
        {
            _runtimeAction = _inputAction.Value.action;
            if (_runtimeAction == null) return;

            // Assume the action (or its map) is enabled elsewhere
            _runtimeAction.performed += OnPerformed;
        }

        public override void OnStop()
        {
            if (_runtimeAction != null)
            {
                _runtimeAction.performed -= OnPerformed;
                _runtimeAction = null;
            }
        }

        private void OnPerformed(InputAction.CallbackContext ctx)
        {
            SendEvent(_performed);
        }

        public override string GetSummary() =>
            "If {_inputAction} performed {_performed}";
    }
}

#endif
