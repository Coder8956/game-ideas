using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(ColorVariable), typeof(float), "b")]
    public class ColorBVariable : BaseVariableProperty<Color, float>
    {
        public override string PropertyName => "b";
        
#if UNITY_EDITOR
        public override string Description => "The blue value of a Color variable.";
#endif

        private ColorVariable ColorVariable => TargetAs<ColorVariable>();
        public override float Value
        {
            get => ColorVariable?.Value.b ?? 0;
            set
            {
                if (ColorVariable == null) return;
                var color = ColorVariable.Value;
                color.b = value;
                ColorVariable.Value = color;
            }
        }
    }
}
