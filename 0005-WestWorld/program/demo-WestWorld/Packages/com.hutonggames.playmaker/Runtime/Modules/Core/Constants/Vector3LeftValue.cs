using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(Vector3))]
    public sealed class Vector3LeftValue : Variable<Vector3>
    {
        public override string Name => "Vector3.left";
        public override Vector3 Value => Vector3.left;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "A Vector3 value of (-1, 0, 0).";
        
        #endif
    }
}