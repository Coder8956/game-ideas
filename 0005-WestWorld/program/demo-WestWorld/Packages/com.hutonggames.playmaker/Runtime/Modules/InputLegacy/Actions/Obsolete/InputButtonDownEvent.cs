using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [Obsolete("Use InputGetButtonDown instead.")]
    [PublicAPI]
    [ActionCategory(Category.InputButton)]
    [ConvertibleGroup(ConvertibleGroup.InputButton)]
    [Tooltip("Sends an Event when a Button is pressed." + Strings.LimitedButtonSupport)]
    public class InputButtonDownEvent : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [DefaultValue("Fire1")]
        [Tooltip("The name of the Button. Defined in the Unity Input Manager.")]
        public StringVar Button;

        [Tooltip("Event to send if the button is pressed.")]
        public EventRef Event;
        
        [Tooltip("Optional: Record the press into a BufferedInput. E.g, for a jump buffer or 'coyote' time.")]
        [SerializeField, OptionalField, WriteOnly]
        private BufferedInputRef _bufferedInput;
        
        public override bool CanExecute() => Button.HasValue();

        private int _lastTriggeredFrame;
        
        public override void Execute()
        {
            // Input.GetButtonDown returns true during the whole frame.
            // This can cause infinite loops if ButtonDownEvent and ButtonUpEvent are called in the same frame.
            // This can happen during a long frame, e.g., when play mode starts in the editor!
            
            // To work around this, we keep track of the last frame we sent an event.
            if (InputShim.GetButtonDown(Button.Value) && _lastTriggeredFrame != Time.frameCount)
            {
                _lastTriggeredFrame = Time.frameCount;
                SendEvent(Event);

                _bufferedInput.Record();
            }
        }
        
        public override string GetSummary() => "On {Button} Button Down {Event}" +
                                               (_bufferedInput.IsNone ?  "" : " (Buffered: {_bufferedInput})");
    }
}