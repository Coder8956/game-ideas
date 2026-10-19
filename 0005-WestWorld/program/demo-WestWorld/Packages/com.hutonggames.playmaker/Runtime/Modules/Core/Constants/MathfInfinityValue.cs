using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue, HideDebugValue]
    [DataType(typeof(float))]
    public sealed class MathfInfinityValue : Variable<float>
    {
        public override string Name => "Infinity";
        public override float Value => Mathf.Infinity;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "A representation of infinity.";
        
        #endif
    }
}