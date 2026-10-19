using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue, HideDebugValue]
    [DataType(typeof(int))]
    public sealed class IntegeraMaxValue : Variable<int>
    {
        public override string Name => "MaxValue";
        public override int Value => int.MaxValue;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "The largest possible value of an Integer.";
        
        #endif
    }
}