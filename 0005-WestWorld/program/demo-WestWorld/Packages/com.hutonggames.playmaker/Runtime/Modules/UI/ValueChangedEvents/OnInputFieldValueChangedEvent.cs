using HutongGames.PlayMaker.UGUIEvents;
using JetBrains.Annotations;
using TMPro;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [UsedImplicitly]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    public class OnInputFieldValueChangedEvent 
        : BaseValueChangedEvent<TMP_InputField, string, StringVariable, OnInputFieldValueChangedEvent>
    {

        public override BaseEventDataGetter GetEventDataGetter() =>
            new InputFieldEventDataGetter();

        protected override void RegisterValueChangedCallback(TMP_InputField component)
        {
            component.onValueChanged.AddListener(OnValueChanged);
        }

        protected override void UnregisterValueChangedCallback(TMP_InputField component)
        {
            component.onValueChanged.RemoveListener(OnValueChanged);
        }

        protected override void SetValue(string value)
        {
            ((StringVariable)Data).Value = value;
        }
    }
}