using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(Vector3))]
    public sealed class Vector3PositiveInfinityValue : Variable<Vector3>
    {
        public override string Name => "Vector3.positiveInfinity";
        public override Vector3 Value => Vector3.positiveInfinity;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "A Vector3 value of Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity).";
        
        #endif
    }
}