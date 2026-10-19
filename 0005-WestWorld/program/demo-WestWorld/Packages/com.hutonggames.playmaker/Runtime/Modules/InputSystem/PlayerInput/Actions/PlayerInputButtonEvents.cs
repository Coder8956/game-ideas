#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.InputSystem.PlayerInput)]
    [ActionDescription("Sends events based on the pressed state of a button action in a PlayerInput component.")]
    [HelpURL(HelpUrls.InputAction + "#UnityEngine_InputSystem_InputAction_IsPressed")]
    public sealed class PlayerInputButtonEvents : PlayerInputReadValueBase
    {
        [ActionHeader("Output")]

        [OptionalField]
        [Tooltip("Store whether the button action is currently pressed.")]
        [SerializeField, WriteOnly]
        private BoolRef _isPressed;

        [OptionalField]
        [Tooltip("Event to send every frame while the button action is pressed.")]
        [SerializeField]
        private EventRef _pressedEvent;

        [OptionalField]
        [Tooltip("Event to send when the button action is pressed this frame.")]
        [SerializeField]
        private EventRef _pressedThisFrameEvent;

        [OptionalField]
        [Tooltip("Event to send when the button action is released this frame.")]
        [SerializeField]
        private EventRef _releasedThisFrameEvent;

        private bool HasOutputs =>
            _isPressed.IsAssigned ||
            _pressedEvent.IsSet ||
            _pressedThisFrameEvent.IsSet ||
            _releasedThisFrameEvent.IsSet;

        public override bool CanExecute() => base.CanExecute();

        public override void Execute()
        {
            var action = GetInputAction();
            if (action is not { enabled: true })
            {
                if (_isPressed.IsAssigned)
                {
                    _isPressed.Value = false;
                }

                return;
            }

            var isPressed = action.IsPressed();

            if (_isPressed.IsAssigned)
            {
                _isPressed.Value = isPressed;
            }

            if (isPressed && _pressedEvent.IsSet)
            {
                SendEvent(_pressedEvent);
            }

            if (action.WasPressedThisFrame() && _pressedThisFrameEvent.IsSet)
            {
                SendEvent(_pressedThisFrameEvent);
            }

            if (action.WasReleasedThisFrame() && _releasedThisFrameEvent.IsSet)
            {
                SendEvent(_releasedThisFrameEvent);
            }
        }

        public override string GetSummary() =>
            "Button events for {_playerInput} {_actionName} " +
            "{_pressedEvent:Pressed} " +
            "{_pressedThisFrameEvent:Pressed This Frame} " +
            "{_releasedThisFrameEvent:Released This Frame} " +
            "{_isPressed:output}";

        public override string ErrorCheck() => !HasOutputs
            ? "Action does not send any events or store the result!"
            : null;
    }
}

#endif
