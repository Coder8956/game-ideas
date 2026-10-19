using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(Camera))]
    public sealed class MainCameraValue : Variable<Camera>
    {
        public override string Name => "MainCamera";
        public override Camera Value => Camera.main;
        
#if UNITY_EDITOR        
        public override string Description => "The first enabled Camera component that is tagged \"MainCamera\".";
#endif

    }
}