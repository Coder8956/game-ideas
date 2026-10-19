using System;
using UnityEngine;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [Serializable]
    public class ScrollbarEventDataGetter : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("The current value of the scrollbar.")]
        public FloatRef ScrollbarValue = new();
        
        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent.Data is not FloatVariable floatVariable ) return;

            ScrollbarValue.Value = floatVariable.Value;
        }

        public string GetSummary() => "Get Scrollbar Value -> {ScrollbarValue}";
    }
}