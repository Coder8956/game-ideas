using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(IntegerVariable), typeof(bool), "isNegative", false)]
    public class IntegerIsNegativeVariable : BaseVariableProperty<int, bool>
    {
        public override string PropertyName => "isNegative";

#if UNITY_EDITOR
        public override string Description => "True if the integer is less than zero.";
#endif

        public override bool Value
        {
            get => (TargetAs<IntegerVariable>()?.Value ?? 0) < 0;
            set { }
        }
    }
}
