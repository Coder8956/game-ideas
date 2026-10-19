// (c) Copyright HutongGames, LLC 2022. All rights reserved.

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [Obsolete("Use InputGetAnyKeyDown instead." )]
    [PublicAPI]
    [ActionCategory(Category.InputButton)]
    [ConvertibleGroup(ConvertibleGroup.InputButton)]
    [Tooltip("Sends an Event when any key or mouse button is pressed." 
             + Strings.SupportsBothInputSystems)]
    public class InputAnyKeyDownEvent : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [Tooltip("Event to send if the button is pressed.")]
        public EventRef Event;
        
        [Tooltip("Optional: Record the press into a BufferedInput. E.g, for a jump buffer or 'coyote' time.")]
        [SerializeField, OptionalField, WriteOnly]
        private BufferedInputRef _bufferedInput;
        
        public override bool CanExecute()
        {
            return CheckParameters(Event);
        }

        private int _lastTriggeredFrame;
        
        public override void Execute()
        {
            // Input.anyKeyDown returns true during the whole frame.
            // This can cause infinite loops if we return to this state expecting anyKeyDown to be false.
            
            // To work around this, we keep track of the last frame we sent an event.
            if (InputShim.AnyKeyDown() && _lastTriggeredFrame != Time.frameCount)
            {
                _lastTriggeredFrame = Time.frameCount;
                SendEvent(Event);
                
                _bufferedInput.Record();
            }
        }
        
        public override string GetSummary() => "On Any Key Down {Event}";
    }
}