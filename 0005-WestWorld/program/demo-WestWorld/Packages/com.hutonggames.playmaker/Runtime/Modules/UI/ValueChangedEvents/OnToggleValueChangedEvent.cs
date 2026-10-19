using HutongGames.PlayMaker.UGUIEvents;
using JetBrains.Annotations;
using UnityEngine.UI;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [UsedImplicitly]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    public class OnToggleValueChangedEvent
        : BaseValueChangedEvent<Toggle, bool, BoolVariable, OnToggleValueChangedEvent>
    {
        public override BaseEventDataGetter GetEventDataGetter() =>
            new ToggleEventDataGetter();

        protected override void RegisterValueChangedCallback(Toggle component)
        {
            component.onValueChanged.AddListener(OnValueChanged);
        }

        protected override void UnregisterValueChangedCallback(Toggle component)
        {
            component.onValueChanged.RemoveListener(OnValueChanged);
        }

        protected override void SetValue(bool value)
        {
            ((BoolVariable)Data).Value = value;
        }
    }
}