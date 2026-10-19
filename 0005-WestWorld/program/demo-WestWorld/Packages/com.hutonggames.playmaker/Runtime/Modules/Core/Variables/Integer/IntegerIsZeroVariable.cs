using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(IntegerVariable), typeof(bool), "isZero", false)]
    public class IntegerIsZeroVariable : BaseVariableProperty<int, bool>
    {
        public override string PropertyName => "isZero";

#if UNITY_EDITOR
        public override string Description => "True if the integer is zero.";
#endif

        public override bool Value
        {
            get => Mathf.Abs(TargetAs<IntegerVariable>()?.Value ?? 0) == 0;
            set { }
        }
    }
}
