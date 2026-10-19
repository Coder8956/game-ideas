using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(Vector2))]
    public sealed class Vector2ZeroValue : Variable<Vector2>
    {
        public override string Name => "Vector2.zero";
        public override Vector2 Value => Vector2.zero;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "A Vector2 value of (0, 0).";
        
        #endif
    }
}