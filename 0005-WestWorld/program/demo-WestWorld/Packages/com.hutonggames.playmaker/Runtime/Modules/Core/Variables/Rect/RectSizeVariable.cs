using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RectVariable), typeof(Vector2), "size")]
    public class RectSizeVariable : BaseVariableProperty<RectTransform, Vector2>
    {
        public override string PropertyName => "size";
        
#if UNITY_EDITOR
        public override string Description => "The Rect size.";
#endif

        private RectVariable RectVariable => TargetAs<RectVariable>();
        public override Vector2 Value
        {
            get => RectVariable.Value.size;
            set
            {
                var rect = RectVariable.Value;
                rect.size = value;
                RectVariable.Value = rect;
            }
        }
    }
}
