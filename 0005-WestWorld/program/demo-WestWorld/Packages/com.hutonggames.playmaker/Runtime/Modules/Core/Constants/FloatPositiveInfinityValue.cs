using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue, HideDebugValue]
    [DataType(typeof(float))]
    public sealed class FloatPositiveInfinityValue : Variable<float>
    {
        public override string Name => "PositiveInfinity";
        public override float Value => float.PositiveInfinity;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "A representation of positive infinity.";
        
        #endif
    }
}