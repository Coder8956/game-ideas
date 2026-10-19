using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    public interface IHasInputEventData
    {
        public BaseEventData EventData { get; set; }
    }
}