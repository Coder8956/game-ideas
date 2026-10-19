using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue, HideDebugValue]
    [DataType(typeof(float))]
    public sealed class FloatEpsilonValue : Variable<float>
    {
        public override string Name => "Epsilon";
        public override float Value => Mathf.Epsilon;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "The smallest value that a float can have different from zero.";
        
        #endif
    }
}