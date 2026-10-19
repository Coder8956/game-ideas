using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue, HideDebugValue]
    [DataType(typeof(float))]
    public sealed class FloatPiValue : Variable<float>
    {
        public override string Name => "PI";
        public override float Value => Mathf.PI;
        public override bool IsConstant => true;
        
#if UNITY_EDITOR        
        public override string Description => "The well-known 3.14159265358979... value.";
#endif

    }
}