#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.Root)]
    [ActionDescription("Send event when any button is pressed.")]
    [HelpURL("actions/input-system-actions/input-system-events/")]
    public class InputSystemOnAnyButtonPressEvent : BaseOnEventAction
    {
        [Tooltip("Event to send when any button is pressed.")]
        [SerializeField]
        private EventRef _event;
        
        private IDisposable _eventListener;
        
        public override void OnStart()
        {
            _eventListener = InputSystem.onAnyButtonPress.Call(OnAnyButton);
        }

        public override void OnStop()
        {
            _eventListener?.Dispose();
        }

        private void OnAnyButton(InputControl control)
        {
            SendEvent(_event);
        }
    }
}

#endif