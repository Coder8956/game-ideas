using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Touch)]
    [ActionDescription("Sends an event when the selected touch phase is detected.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Input-touches.html")]
    [MovedFrom(true, null, null, "TouchEvent")]
    public sealed class InputTouchEvent : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        [OptionalField]
        [Tooltip("An optional Finger Id to filter by. For example, if you detected a Touch Began and stored the FingerId, you could look for the Ended event for that Finger Id.")]
        [SerializeField]
        private IntegerVar _fingerId;

        [Tooltip("The phase you're interested in detecting (Began, Moved, Stationary, Ended, Cancelled).")]
        [SerializeField]
        private TouchPhaseVar _touchPhase;

        [Tooltip("The event to send when the Touch Phase is detected.")]
        [SerializeField]
        private EventRef _sendEvent;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("Store the Finger Id associated with the touch event for later use.")]
        [SerializeField, WriteOnly]
        private IntegerRef _storeFingerId;

        public override bool CanExecute() => CheckParameters(_touchPhase, _sendEvent);

        public override void Execute()
        {
            var touches = Input.touches;

            for (int i = 0; i < touches.Length; i++)
            {
                var touch = touches[i];

                if (_fingerId.IsAssigned && touch.fingerId != _fingerId.Value)
                    continue;

                if (touch.phase != _touchPhase.Value)
                    continue;

                if (_storeFingerId.IsAssigned)
                    _storeFingerId.Value = touch.fingerId;

                SendEvent(_sendEvent);
            }
        }

        public override string GetSummary() =>
            "On {_touchPhase}" +
            (_fingerId.IsAssigned ? " finger {_fingerId}" : string.Empty) +
            " {_sendEvent}";
    }
}
