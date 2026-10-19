using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(ColorVariable), typeof(Color), "linear", false)]
    public class ColorLinearVariable : BaseVariableProperty<Color, Color>
    {
        public override string PropertyName => "linear";
        
#if UNITY_EDITOR
        public override string Description => "The linear value of a Color variable.";
#endif

        public override Color Value
        {
            get => (TargetAs<ColorVariable>()?.Value ?? default).linear;
            set { }
        }
    }
}
