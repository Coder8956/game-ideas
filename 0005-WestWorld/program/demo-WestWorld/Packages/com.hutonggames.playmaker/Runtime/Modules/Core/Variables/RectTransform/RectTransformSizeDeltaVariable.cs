using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RectTransformVariable), typeof(Vector2), "sizeDelta")]
    public class RectTransformSizeDeltaVariable : BaseVariableProperty<RectTransform, Vector2>
    {
        public override string PropertyName => "sizeDelta";
        
#if UNITY_EDITOR
        public override string Description => "The RectTransform's size delta.";
#endif

        private RectTransformVariable RectTransformVariable => TargetAs<RectTransformVariable>();
        public override Vector2 Value
        {
            get => RectTransformVariable?.Value ? RectTransformVariable.Value.sizeDelta : Vector2.zero;
            set
            {
                if (RectTransformVariable?.Value) RectTransformVariable.Value.sizeDelta = value;
            }
        }
    }
}
