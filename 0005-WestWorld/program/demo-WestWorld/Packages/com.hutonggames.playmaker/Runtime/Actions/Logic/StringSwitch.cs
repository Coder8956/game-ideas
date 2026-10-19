using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicFlow)]
    [ActionDescription("Send events based on the value of a String variable.")]
    [MovedFrom(true, null, null,"StringValueSwitch")]
    public class StringSwitch : BaseAction
    {
        [Tooltip("The String to check.")]
        public StringRef String;

        [Tooltip("The check to perform on each item. The first item that passes the check is picked.")]
        public StringComparisonOperation Check;
        
        [Tooltip("Send events based on the String's value.")]
        public StringEventSwitch Switch;
        
        public override void Execute()
        {
            if (!RuntimeCheck(String)) return;

            var evt = Switch.Evaluate(String.Value, Check);
            if (evt != null)
            {
                SendEvent(evt);
            }
        }
        
        public override string GetSummary() => "{String} {Check} Switch: " + Switch?.GetSummary();
    }
}