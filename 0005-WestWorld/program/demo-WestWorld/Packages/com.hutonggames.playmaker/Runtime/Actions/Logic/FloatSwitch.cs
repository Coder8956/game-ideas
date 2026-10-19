using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicFlow)]
    [ActionDescription("Send events based on the value of a Float variable.")]
    public class FloatSwitch : BaseAction
    {
        [Tooltip("The Float to check.")]
        public FloatRef Float;

        [Tooltip("The check to perform on each item. The first item that passes the check is picked.")]
        public NumericComparisonOperation Check;
        
        [Tooltip("Send events based on the Float's value.")]
        public FloatEventSwitch Switch;
        
        public override void Execute()
        {
            if (!RuntimeCheck(Float)) return;

            var evt = Switch.Evaluate(Float.Value, Check);
            if (evt != null)
            {
                SendEvent(evt);
            }
        }
        
        public override string GetSummary() => "{Float} {Check} Switch: " + Switch?.GetSummary();
    }
}