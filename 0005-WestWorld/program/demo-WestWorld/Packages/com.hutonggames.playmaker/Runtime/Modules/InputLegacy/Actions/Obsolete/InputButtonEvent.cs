using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [Obsolete("Use InputGetButton instead.")]
    [PublicAPI]
    [ActionCategory(Category.InputButton)]
    [ConvertibleGroup(ConvertibleGroup.InputButton)]
    [Tooltip("Sends an Event if a Button is down." + Strings.LimitedButtonSupport)]
    public class InputButtonEvent : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [DefaultValue("Fire1")]
        [Tooltip("The name of the Button. Defined in the Unity Input Manager.")]
        public StringVar Button;

        [Tooltip("Event to send if the button is down.")]
        public EventRef Event;
        
        public override bool CanExecute() => Button.HasValue();

        private int _lastTriggeredFrame;
        
        public override void Execute()
        {
#if !NEW_INPUT_SYSTEM_ONLY

            // Input.GetButton returns true during the whole frame.
            // This can cause infinite loops if ButtonDownEvent and ButtonUpEvent are called in the same frame.
            // This can happen during a long frame, e.g., when play mode starts in the editor!
            
            // To work around this, we keep track of the last frame we sent an event.
            if (InputShim.GetButton(Button.Value) 
                && _lastTriggeredFrame != Time.frameCount)
            {
                _lastTriggeredFrame = Time.frameCount;
                SendEvent(Event);
            }
#endif
        }
        
        public override string GetSummary() => "On {Button} Button {Event}";
    }
}