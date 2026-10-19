using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue, HideDebugValue]
    [DataType(typeof(int))]
    public sealed class IntegerMinValue : Variable<int>
    {
        public override string Name => "MinValue";
        public override int Value => int.MinValue;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "The smallest possible value of an Integer.";
        
        #endif
    }
}