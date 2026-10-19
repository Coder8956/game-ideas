using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(ColorVariable), typeof(float), "grayscale", false)]
    public class ColorGrayscaleVariable : BaseVariableProperty<Color, float>
    {
        public override string PropertyName => "grayscale";
        
#if UNITY_EDITOR
        public override string Description => "The grayscale value of a Color variable.";
#endif

        public override float Value
        {
            get => (TargetAs<ColorVariable>()?.Value ?? default).grayscale;
            set { }
        }
    }
}
