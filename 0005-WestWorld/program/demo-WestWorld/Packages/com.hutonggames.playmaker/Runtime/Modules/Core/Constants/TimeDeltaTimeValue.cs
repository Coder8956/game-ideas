using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue, HideDebugValue]
    [DataType(typeof(float))]
    public sealed class TimeDeltaTimeValue : Variable<float>
    {
        public override string Name => "Time.deltaTime";
        public override float Value => Time.deltaTime;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "The time in seconds it took to complete the last frame.";
        
        #endif
    }
}