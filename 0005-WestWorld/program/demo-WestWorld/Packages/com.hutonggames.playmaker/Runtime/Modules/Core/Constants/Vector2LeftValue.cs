using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(Vector2))]
    public sealed class Vector2LeftValue : Variable<Vector2>
    {
        public override string Name => "Vector2.left";
        public override Vector2 Value => Vector2.left;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "A Vector2 value of (-1, 0).";
        
        #endif
    }
}