using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(ColorVariable), typeof(float), "a")]
    public class ColorAVariable : BaseVariableProperty<Color, float>
    {
        public override string PropertyName => "a";
        
#if UNITY_EDITOR
        public override string Description => "The alpha value of a Color variable.";
#endif

        private ColorVariable ColorVariable => TargetAs<ColorVariable>();
        public override float Value
        {
            get => ColorVariable?.Value.a ?? 0;
            set
            {
                if (ColorVariable == null) return;
                var color = ColorVariable.Value;
                color.a = value;
                ColorVariable.Value = color;
            }
        }
    }
}
