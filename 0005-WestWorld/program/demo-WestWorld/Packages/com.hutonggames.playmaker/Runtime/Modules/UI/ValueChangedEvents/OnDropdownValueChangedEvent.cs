using HutongGames.PlayMaker.UGUIEvents;
using JetBrains.Annotations;
using TMPro;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [UsedImplicitly]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    public class OnDropdownValueChangedEvent
        : BaseValueChangedEvent<TMP_Dropdown, int, IntegerVariable, OnDropdownValueChangedEvent>
    {
        public override BaseEventDataGetter GetEventDataGetter() =>
            new DropdownEventDataGetter();

        protected override void RegisterValueChangedCallback(TMP_Dropdown component)
        {
            component.onValueChanged.AddListener(OnValueChanged);
        }

        protected override void UnregisterValueChangedCallback(TMP_Dropdown component)
        {
            component.onValueChanged.RemoveListener(OnValueChanged);
        }

        protected override void SetValue(int value)
        {
            ((IntegerVariable)Data).Value = value;
        }
    }
}