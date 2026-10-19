using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(FloatVariable), typeof(float), "negate", false)]
    public class FloatNegateVariable : BaseVariableProperty<float, float>
    {
        public override string PropertyName => "negate";

#if UNITY_EDITOR
        public override string Description => "Negate the value of a float.";
#endif

        public override float Value
        {
            get => -(TargetAs<FloatVariable>()?.Value ?? 0);
            set { }
        }
    }
}
