using System;
using HutongGames.PlayMaker.Actions.EventSystems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [Serializable]
    public class PointerEventDataGetter : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("The PointerEventData sent with the event.")]
        public PointerEventDataRef PointerEventData = new();
        
        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent is not IHasInputEventData inputEvent)
            {
                Debug.LogWarning($"{baseEvent.Name} Event does not implement IHasInputEventData!");
                return;
            }

            PointerEventData.Value = inputEvent.EventData as PointerEventData;
        }

        public string GetSummary() => "Get InputEventData -> {InputEventData}";
    }
}