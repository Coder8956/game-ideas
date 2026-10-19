using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(LayerMask))]
    public sealed class Physics2DIgnoreRaycastLayerValue : Variable<LayerMask>
    {
        public override string Name => "Physics2D Ignore Raycast Layer";
        public override LayerMask Value => Physics2D.IgnoreRaycastLayer;
        public override bool IsConstant => true;
        
#if UNITY_EDITOR
        public override string Description => "Layer mask constant for the default layer that ignores raycasts.";
        
#endif
    }
}