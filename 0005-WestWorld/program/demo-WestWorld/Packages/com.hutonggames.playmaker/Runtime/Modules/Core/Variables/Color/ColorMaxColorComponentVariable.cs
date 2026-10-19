using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(ColorVariable), typeof(float), "maxColorComponent", false)]
    public class ColorMaxColorComponentVariable : BaseVariableProperty<Color, float>
    {
        public override string PropertyName => "maxColorComponent";
        
#if UNITY_EDITOR
        public override string Description => "The maximum color component of a Color variable.";
#endif

        public override float Value
        {
            get => (TargetAs<ColorVariable>()?.Value ?? default).maxColorComponent;
            set { }
        }
    }
}
