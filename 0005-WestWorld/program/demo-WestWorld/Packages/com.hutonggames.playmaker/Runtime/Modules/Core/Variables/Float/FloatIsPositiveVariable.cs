using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(FloatVariable), typeof(bool), "isPositive", false)]
    public class FloatIsPositiveVariable : BaseVariableProperty<float, bool>
    {
        public override string PropertyName => "isPositive";

#if UNITY_EDITOR
        public override string Description => "True if the float is greater than zero.";
#endif

        public override bool Value
        {
            get => (TargetAs<FloatVariable>()?.Value ?? 0) > 0;
            set { }
        }
    }
}
