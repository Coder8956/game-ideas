using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(FloatVariable), typeof(bool), "isNegative", false)]
    public class FloatIsNegativeVariable : BaseVariableProperty<float, bool>
    {
        public override string PropertyName => "isNegative";

#if UNITY_EDITOR
        public override string Description => "True if the float is less than zero.";
#endif

        public override bool Value
        {
            get => (TargetAs<FloatVariable>()?.Value ?? 0) < 0;
            set { }
        }
    }
}
