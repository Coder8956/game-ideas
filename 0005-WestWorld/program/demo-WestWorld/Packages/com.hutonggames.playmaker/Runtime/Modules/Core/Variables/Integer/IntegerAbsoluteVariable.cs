using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(IntegerVariable), typeof(int), "absolute", false)]
    public class IntegerAbsoluteVariable : BaseVariableProperty<int, int>
    {
        public override string PropertyName => "absolute";

#if UNITY_EDITOR
        public override string Description => "The absolute value of an integer value.";
#endif

        public override int Value
        {
            get => Mathf.Abs(TargetAs<IntegerVariable>()?.Value ?? 0);
            set { }
        }
    }
}
