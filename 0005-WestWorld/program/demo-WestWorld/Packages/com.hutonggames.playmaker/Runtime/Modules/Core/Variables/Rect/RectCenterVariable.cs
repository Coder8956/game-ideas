using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RectVariable), typeof(Vector2), "center")]
    public class RectCenterVariable : BaseVariableProperty<RectTransform, Vector2>
    {
        public override string PropertyName => "center";
        
#if UNITY_EDITOR
        public override string Description => "The Rect center.";
#endif

        private RectVariable RectVariable => TargetAs<RectVariable>();
        public override Vector2 Value
        {
            get => RectVariable.Value.center;
            set
            {
                var rect = RectVariable.Value;
                rect.center = value;
                RectVariable.Value = rect;
            }
        }
    }
}
