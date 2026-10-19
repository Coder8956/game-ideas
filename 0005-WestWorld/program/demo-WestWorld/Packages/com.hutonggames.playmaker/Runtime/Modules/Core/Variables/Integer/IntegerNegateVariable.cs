using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(IntegerVariable), typeof(int), "negate", false)]
    public class IntegerNegateVariable : BaseVariableProperty<int, int>
    {
        public override string PropertyName => "negate";

#if UNITY_EDITOR
        public override string Description => "Negate the value of an integer.";
#endif

        public override int Value
        {
            get => -(TargetAs<IntegerVariable>()?.Value ?? 0);
            set { }
        }
    }
}
