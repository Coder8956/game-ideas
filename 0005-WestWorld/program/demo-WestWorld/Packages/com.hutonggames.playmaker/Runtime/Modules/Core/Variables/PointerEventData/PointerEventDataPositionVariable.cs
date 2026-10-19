using System;
using HutongGames.PlayMaker.Actions.EventSystems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(PointerEventDataVariable), typeof(Vector2), "position", false)]
    public class PointerEventDataPositionVariable :  BaseVariableProperty<PointerEventData, Vector2>
    {
        public override string PropertyName => "position";
        
#if UNITY_EDITOR
        public override string Description => "Current pointer position.";
#endif

        public override Vector2 Value
        {
            get => TargetAs<PointerEventDataVariable>()?.Value?.position ?? Vector2.zero;
            set {}
        }
    }
}
