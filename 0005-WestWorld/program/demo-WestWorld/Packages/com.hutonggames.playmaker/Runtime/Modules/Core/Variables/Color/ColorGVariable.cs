using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(ColorVariable), typeof(float), "g")]
    public class ColorGVariable : BaseVariableProperty<Color, float>
    {
        public override string PropertyName => "g";
        
#if UNITY_EDITOR
        public override string Description => "The green value of a Color variable.";
#endif

        private ColorVariable ColorVariable => TargetAs<ColorVariable>();
        public override float Value
        {
            get => ColorVariable?.Value.g ?? 0;
            set
            {
                if (ColorVariable == null) return;
                var color = ColorVariable.Value;
                color.g = value;
                ColorVariable.Value = color;
            }
        }
    }
}
