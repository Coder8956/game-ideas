using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RectTransformVariable), typeof(Vector2), "anchoredPosition")]
    public class RectTransformAnchoredPositionVariable : BaseVariableProperty<RectTransform, Vector2>
    {
        public override string PropertyName => "anchoredPosition";
        
#if UNITY_EDITOR
        public override string Description => "The RectTransform's anchored position.";
#endif

        private RectTransformVariable RectTransformVariable => TargetAs<RectTransformVariable>();
        public override Vector2 Value
        {
            get => RectTransformVariable?.Value ? RectTransformVariable.Value.anchoredPosition : Vector2.zero;
            set
            {
                if (RectTransformVariable?.Value) RectTransformVariable.Value.anchoredPosition = value;
            }
        }
    }
}
