using System;
using UnityEngine;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [Serializable]
    public class SliderEventDataGetter : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("The current value of the slider.")]
        public FloatRef SliderValue = new();
        
        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent.Data is not FloatVariable floatVariable ) return;

            SliderValue.Value = floatVariable.Value;
        }

        public string GetSummary() => "Get Slider Value -> {SliderValue}";
    }
}