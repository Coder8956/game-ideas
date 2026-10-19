using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(ColorVariable), typeof(float), "r")]
    public class ColorRVariable : BaseVariableProperty<Color, float>
    {
        public override string PropertyName => "r";
        
#if UNITY_EDITOR
        public override string Description => "The red value of a Color variable.";
#endif

        private ColorVariable ColorVariable => TargetAs<ColorVariable>();
        public override float Value
        {
            get => ColorVariable?.Value.r ?? 0;
            set
            {
                if (ColorVariable == null) return;
                var color = ColorVariable.Value;
                color.r = value;
                ColorVariable.Value = color;
            }
        }
    }
}
