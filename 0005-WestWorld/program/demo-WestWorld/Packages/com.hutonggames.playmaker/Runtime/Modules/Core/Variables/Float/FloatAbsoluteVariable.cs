using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(FloatVariable), typeof(float), "absolute", false)]
    public class FloatAbsoluteVariable : BaseVariableProperty<float, float>
    {
        public override string PropertyName => "absolute";

#if UNITY_EDITOR
        public override string Description => "The absolute value of a float value.";
#endif

        public override float Value
        {
            get => Mathf.Abs(TargetAs<FloatVariable>()?.Value ?? 0);
            set { }
        }
    }
}
