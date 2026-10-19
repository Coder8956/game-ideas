using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckBool")]
    [ActionDescription("Check if a Bool variable is true.")]
    public class BoolIsTrue : BaseAction
    {
        [Tooltip("The Bool variable to check.")]
        public BoolRef Bool;
        
        [OptionalField]
        [Tooltip("Event to send if the Bool variable is true.")]
        public EventRef TrueEvent;
        
        [OptionalField]
        [Tooltip("Event to send if the Bool variable is false.")]
        public EventRef FalseEvent;
        
        public override bool CanExecute() => CheckParameters(Bool);

        public override void Execute() => SendEvent(Bool.Value ? TrueEvent : FalseEvent);

        public override string GetSummary()
        {
            if (TrueEvent.IsSet)
            {
                var summary = "If {Bool} {TrueEvent}";
                if (FalseEvent.IsSet) summary += " else {FalseEvent}";
                return summary;
            }

            if (FalseEvent.IsSet)
            {
                return "If {Bool} is false {FalseEvent}";
            }

            return "Check if {Bool} is true";
        }
    }
}
