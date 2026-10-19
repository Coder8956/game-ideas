using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [Obsolete("Use InputGetKeyUp instead." )]
    [PublicAPI]
    [ActionCategory(Category.Keyboard)]
    [ConvertibleGroup(ConvertibleGroup.InputButton)]
    [Tooltip("Sends an Event when a Key is released." + Strings.SupportsBothInputSystems)]
    public class InputKeyUpEvent : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [Tooltip("The key to detect.")]
        [SerializeField]
        private KeyCodeVar _key;

        [Tooltip("Event to send if the button is released.")]
        [SerializeField]
        private EventRef _event;
        
        public override bool CanExecute() => base.CanExecute() && CheckParameters(_key, _event);

        private int _lastTriggeredFrame;
        
        public override void Execute()
        {
            // Input.GetKeyDown returns true during the whole frame.
            // This can cause infinite loops if ButtonDownEvent and ButtonUpEvent are called in the same frame.
            // NOTE: This can also happen during a long frame, e.g., when play mode starts in the editor!
            
            // To work around this, we keep track of the last frame we sent an event.
            if (InputShim.GetKeyUp(_key.Value) && _lastTriggeredFrame != Time.frameCount)
            {
                _lastTriggeredFrame = Time.frameCount;
                SendEvent(_event);
            }
        }
        
        public override string GetSummary() => "On {_key} key up {_event}";
    }
}