using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(Vector3))]
    public sealed class Vector3NegativeInfinityValue : Variable<Vector3>
    {
        public override string Name => "Vector3.negativeInfinity";
        public override Vector3 Value => Vector3.negativeInfinity;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "A Vector3 value of Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity).";
        
        #endif
    }
}