using System;
using UnityEngine;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [Serializable]
    public class ToggleEventDataGetter : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("The current value of the toggle.")]
        public BoolRef ToggleValue = new();
        
        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent.Data is not BoolVariable boolVariable ) return;

            ToggleValue.Value = boolVariable.Value;
        }

        public string GetSummary() => "Get Toggle Value -> {ToggleValue}";
    }
}