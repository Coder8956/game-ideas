using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(FloatVariable), typeof(bool), "isZero", false)]
    public class FloatIsZeroVariable : BaseVariableProperty<float, bool>
    {
        public override string PropertyName => "isZero";

#if UNITY_EDITOR
        public override string Description => "True if the float is zero.";
#endif

        public override bool Value
        {
            get => Mathf.Abs(TargetAs<FloatVariable>()?.Value ?? 0) == 0;
            set { }
        }
    }
}
