using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(IntegerVariable), typeof(bool), "isPositive", false)]
    public class IntegerIsPositiveVariable : BaseVariableProperty<int, bool>
    {
        public override string PropertyName => "isPositive";

#if UNITY_EDITOR
        public override string Description => "True if the integer is greater than zero.";
#endif

        public override bool Value
        {
            get => (TargetAs<IntegerVariable>()?.Value ?? 0) > 0;
            set { }
        }
    }
}
