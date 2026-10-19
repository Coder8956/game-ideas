using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(ColorVariable), typeof(Color), "gamma", false)]
    public class ColorGammaVariable : BaseVariableProperty<Color, Color>
    {
        public override string PropertyName => "gamma";
        
#if UNITY_EDITOR
        public override string Description => "The gamma value of a Color variable.";
#endif

        public override Color Value
        {
            get => (TargetAs<ColorVariable>()?.Value ?? default).gamma;
            set { }
        }
    }
}
