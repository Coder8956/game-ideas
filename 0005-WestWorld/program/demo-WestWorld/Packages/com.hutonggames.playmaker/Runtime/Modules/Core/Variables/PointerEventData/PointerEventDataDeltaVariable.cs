using System;
using HutongGames.PlayMaker.Actions.EventSystems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(PointerEventDataVariable), typeof(Vector2), "delta", false)]
    public class PointerEventDataDeltaVariable :  BaseVariableProperty<PointerEventData, Vector2>
    {
        public override string PropertyName => "delta";
        
#if UNITY_EDITOR
        public override string Description => "Delta since last update.";
#endif

        public override Vector2 Value
        {
            get => TargetAs<PointerEventDataVariable>()?.Value?.delta ?? Vector2.zero;
            set {}
        }
    }
}
