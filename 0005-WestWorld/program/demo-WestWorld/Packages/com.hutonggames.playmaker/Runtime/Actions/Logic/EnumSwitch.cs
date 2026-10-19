using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.LogicFlow)]
    [ActionDescription("Send events based on the value of an Enum variable.")]
    public class EnumSwitch : BaseAction
    {
        [Tooltip("The Enum to check.")]
        [SerializeField] private EnumRef _enum;
        
        [MatchType(nameof(_enum))]
        [Tooltip("Send events based on the Enum's value.")]
        [SerializeField] private EnumEventSwitch _switch;
        
        public override void Execute()
        {
            if (!RuntimeCheck(_enum)) return;

            var evt = _switch.Evaluate(_enum.Value);
            if (evt != null)
            {
                SendEvent(evt);
            }
        }
        
        public override string GetSummary() => "{_enum} Switch: " + _switch?.GetSummary();
    }
}