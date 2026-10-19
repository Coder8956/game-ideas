using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Detects AnimationEvents sent to the FSM Component from an AnimationClip. " +
                       "In the Animation window, use `FsmComponent > OnAnimationEvent` method as the event Function. " +
                       "This action lets you get the parameters sent with the event and send an FSM event. " +
                       "Use this to synchronize animations and FSMs.")]
    public class OnAnimationEvent : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;

        [Tooltip("Store the float parameter sent with the AnimationEvent.")]
        [OptionalField, SerializeField, WriteOnly]
        private FloatRef _storeFloat;
        
        [Tooltip("Store the integer parameter sent with the AnimationEvent.")]
        [OptionalField, SerializeField, WriteOnly]
        private IntegerRef _storeInteger;
        
        [Tooltip("Store the string parameter sent with the AnimationEvent.")]
        [OptionalField, SerializeField, WriteOnly]
        private StringRef _storeString;
        
        [Tooltip("Store the Object parameter sent with the AnimationEvent.")]
        [OptionalField, SerializeField, WriteOnly]
        private ObjectRef _storeObject;
        
        [Tooltip("Event to send when we get the AnimationEvent.")]
        [OptionalField, SerializeField, DefaultName("AnimationEvent")]
        private EventRef _sendEvent;

        public override void OnStart()
        {
            Fsm.AnimationEvent += ProcessAnimationEvent;
        }

        private void ProcessAnimationEvent(AnimationEvent animationEvent)
        {
            _storeFloat.Value = animationEvent.floatParameter;
            _storeInteger.Value = animationEvent.intParameter;
            _storeString.Value = animationEvent.stringParameter;
            _storeObject.Value = animationEvent.objectReferenceParameter;
            
            if (_sendEvent.IsSet) SendEvent(_sendEvent);
        }
        
        public override void OnStop()
        {
            Fsm.AnimationEvent -= ProcessAnimationEvent;
        }
        
        public override string GetSummary()
        {
            var s = "On AnimationEvent";
            if (_storeFloat.IsAssigned) s += " -> {_storeFloat}";
            if (_storeInteger.IsAssigned) s += " -> {_storeInteger}";
            if (_storeString.IsAssigned) s += " -> {_storeString}";
            if (_storeObject.IsAssigned) s += " -> {_storeObject}";
            if (_sendEvent.IsSet) s += " {_sendEvent}";

            return s;
        }
    }
}