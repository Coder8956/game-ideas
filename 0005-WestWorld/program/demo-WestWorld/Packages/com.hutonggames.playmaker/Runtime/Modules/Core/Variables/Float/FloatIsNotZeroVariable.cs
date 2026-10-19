using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(FloatVariable), typeof(bool), "isNotZero", false)]
    public class FloatIsNotZeroVariable : BaseVariableProperty<float, bool>
    {
        public override string PropertyName => "isNotZero";

#if UNITY_EDITOR
        public override string Description => "True if the float is not zero.";
#endif

        public override bool Value
        {
            get => Mathf.Abs(TargetAs<FloatVariable>()?.Value ?? 0) > 0;
            set { }
        }
    }
}
