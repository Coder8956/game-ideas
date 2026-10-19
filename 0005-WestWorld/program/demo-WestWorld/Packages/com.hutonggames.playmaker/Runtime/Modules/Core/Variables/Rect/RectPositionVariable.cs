using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RectVariable), typeof(Vector2), "position")]
    public class RectPositionVariable : BaseVariableProperty<RectTransform, Vector2>
    {
        public override string PropertyName => "position";
        
#if UNITY_EDITOR
        public override string Description => "The Rect position.";
#endif

        private RectVariable RectVariable => TargetAs<RectVariable>();
        public override Vector2 Value
        {
            get => RectVariable.Value.position;
            set
            {
                var rect = RectVariable.Value;
                rect.position = value;
                RectVariable.Value = rect;
            }
        }
    }
}
