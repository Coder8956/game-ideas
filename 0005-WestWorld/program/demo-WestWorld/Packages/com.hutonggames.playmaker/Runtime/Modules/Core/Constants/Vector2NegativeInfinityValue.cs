using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(Vector2))]
    public sealed class Vector2NegativeInfinityValue : Variable<Vector2>
    {
        public override string Name => "Vector2.negativeInfinity";
        public override Vector2 Value => Vector2.negativeInfinity;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "A Vector2 value of Vector2(float.negativeInfinity, float.negativeInfinity).";
        
        #endif
    }
}