using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue, HideDebugValue]
    [DataType(typeof(string))]
    public sealed class StringNewLineValue : Variable<string>
    {
        public override string Name => "NewLine";
        public override string Value => Environment.NewLine;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "Gets the newline string defined for this environment.";
        
        #endif
    }
}