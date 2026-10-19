using System;
using HutongGames.PlayMaker.Actions.EventSystems;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(PointerEventDataVariable), typeof(PointerEventData.InputButton), "button", false)]
    public class PointerEventDataButtonVariable :  BaseVariableProperty<PointerEventData, PointerEventData.InputButton>
    {
        public override string PropertyName => "button";
        
#if UNITY_EDITOR
        public override string Description => "The button.";
#endif

        public override PointerEventData.InputButton Value
        {
            get => TargetAs<PointerEventDataVariable>()?.Value?.button ?? PointerEventData.InputButton.Left;
            set {}

        }
    }
}
