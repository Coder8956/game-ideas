using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(Quaternion))]
    public sealed class QuaternionIdentityValue : Variable<Quaternion>
    {
        public override string Name => "Quaternion.identity";
        public override Quaternion Value => Quaternion.identity;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "The identity rotation (Read Only).";
        
        #endif
    }
}