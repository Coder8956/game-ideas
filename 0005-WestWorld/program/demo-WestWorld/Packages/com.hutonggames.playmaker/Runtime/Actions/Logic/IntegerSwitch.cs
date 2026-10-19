using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicFlow)]
    [ActionDescription("Send events based on the value of an Integer variable.")]
    public class IntegerSwitch : BaseAction
    {
        [Tooltip("The Integer to check.")]
        public IntegerRef Integer;

        [Tooltip("The check to perform on each item. The first item that passes the check is picked.")]
        public NumericComparisonOperation Check;
        
        [Tooltip("Send events based on the Integer's value.")]
        public IntegerEventSwitch Switch;
        
        public override void Execute()
        {
            if (!RuntimeCheck(Integer)) return;

            var evt = Switch.Evaluate(Integer.Value, Check);
            if (evt != null)
            {
                SendEvent(evt);
            }
        }
        
        public override string GetSummary() => "{Integer} {Check} Switch: " + Switch?.GetSummary();
    }
}