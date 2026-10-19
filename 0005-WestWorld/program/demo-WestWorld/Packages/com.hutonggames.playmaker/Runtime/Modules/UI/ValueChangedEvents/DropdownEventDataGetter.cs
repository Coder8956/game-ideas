using System;
using UnityEngine;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [Serializable]
    public class DropdownEventDataGetter : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("The selected index value of the dropdown." +
                 "\n0 = first option, 1 = second option, etc.")]
        public IntegerRef SelectedValue = new();
        
        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent.Data is not IntegerVariable integerVariable ) return;

            SelectedValue.Value = integerVariable.Value;
        }

        public string GetSummary() => "Get Selected Value -> {SelectedValue}";
    }
}