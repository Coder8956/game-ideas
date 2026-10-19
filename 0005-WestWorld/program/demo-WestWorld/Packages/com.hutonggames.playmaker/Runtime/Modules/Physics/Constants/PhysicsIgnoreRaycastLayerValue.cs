using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(LayerMask))]
    public sealed class PhysicsIgnoreRaycastLayerValue : Variable<LayerMask>
    {
        public override string Name => "Physics Ignore Raycast Layer";
        public override LayerMask Value => Physics.IgnoreRaycastLayer;
        public override bool IsConstant => true;
        
#if UNITY_EDITOR
        public override string Description => "Layer mask constant for the default layer that ignores raycasts.";
        
#endif
    }
}