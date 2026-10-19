using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue, HideDebugValue]
    [DataType(typeof(string))]
    public sealed class StringEmptyValue : Variable<string>
    {
        public override string Name => "Empty";
        public override string Value => string.Empty;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "Represents the empty string. You can use this as a clear way to initialise a string as empty instead of using null or \"\"";
        
        #endif
    }
}