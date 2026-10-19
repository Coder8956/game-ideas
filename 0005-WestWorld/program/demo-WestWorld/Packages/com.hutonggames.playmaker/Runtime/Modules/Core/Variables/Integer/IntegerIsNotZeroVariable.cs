using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(IntegerVariable), typeof(bool), "isNotZero", false)]
    public class IntegerIsNotZeroVariable : BaseVariableProperty<int, bool>
    {
        public override string PropertyName => "isNotZero";

#if UNITY_EDITOR
        public override string Description => "True if the integer is not zero.";
#endif

        public override bool Value
        {
            get => Mathf.Abs(TargetAs<IntegerVariable>()?.Value ?? 0) > 0;
            set { }
        }
    }
}
