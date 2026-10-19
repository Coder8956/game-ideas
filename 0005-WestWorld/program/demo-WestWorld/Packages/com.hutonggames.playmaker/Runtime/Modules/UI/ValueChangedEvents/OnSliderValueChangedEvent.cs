using HutongGames.PlayMaker.UGUIEvents;
using JetBrains.Annotations;
using UnityEngine.UI;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [UsedImplicitly]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    public class OnSliderValueChangedEvent
        : BaseValueChangedEvent<Slider, float, FloatVariable, OnSliderValueChangedEvent>
    {
        public override BaseEventDataGetter GetEventDataGetter() =>
            new SliderEventDataGetter();

        protected override void RegisterValueChangedCallback(Slider component)
        {
            component.onValueChanged.AddListener(OnValueChanged);
        }

        protected override void UnregisterValueChangedCallback(Slider component)
        {
            component.onValueChanged.RemoveListener(OnValueChanged);
        }

        protected override void SetValue(float value)
        {
            ((FloatVariable)Data).Value = value;
        }
    }
}