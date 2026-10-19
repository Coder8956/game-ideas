using System;
using UnityEngine;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [Serializable]
    public class InputFieldEventDataGetter : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("The current text value of the input field.")]
        public StringRef InputFieldValue = new();
        
        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent.Data is not StringVariable stringVariable ) return;

            InputFieldValue.Value = stringVariable.Value;
        }

        public string GetSummary() => "Get InputField Value -> {InputFieldValue}";
    }
}