using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(Vector2))]
    public sealed class Vector2PositiveInfinityValue : Variable<Vector2>
    {
        public override string Name => "Vector2.positiveInfinity";
        public override Vector2 Value => Vector2.positiveInfinity;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "A Vector2 value of Vector2(float.PositiveInfinity, float.PositiveInfinity).";
        
        #endif
    }
}