using HutongGames.PlayMaker.UGUIEvents;
using JetBrains.Annotations;
using UnityEngine.UI;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [UsedImplicitly]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    public class OnScrollbarValueChangedEvent
        : BaseValueChangedEvent<Scrollbar, float, FloatVariable, OnScrollbarValueChangedEvent>
    {
        public override BaseEventDataGetter GetEventDataGetter() =>
            new ScrollbarEventDataGetter();

        protected override void RegisterValueChangedCallback(Scrollbar component)
        {
            component.onValueChanged.AddListener(OnValueChanged);
        }

        protected override void UnregisterValueChangedCallback(Scrollbar component)
        {
            component.onValueChanged.RemoveListener(OnValueChanged);
        }

        protected override void SetValue(float value)
        {
            ((FloatVariable)Data).Value = value;
        }
    }
}