using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue, HideDebugValue]
    [DataType(typeof(float))]
    public sealed class FloatNegativeInfinityValue : Variable<float>
    {
        public override string Name => "NegativeInfinity";
        public override float Value => float.NegativeInfinity;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "A representation of negative infinity.";
        
        #endif
    }
}