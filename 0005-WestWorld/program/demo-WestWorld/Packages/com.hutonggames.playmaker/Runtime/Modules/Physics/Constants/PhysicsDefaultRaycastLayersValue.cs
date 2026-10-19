using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(LayerMask))]
    public sealed class PhysicsDefaultRaycastLayersValue : Variable<LayerMask>
    {
        public override string Name => "Physics Default Raycast Layers";
        public override string ShortName => "Default";
        public override LayerMask Value => Physics.DefaultRaycastLayers;
        public override bool IsConstant => true;

#if UNITY_EDITOR
        public override string Description => "Layer mask constant that includes all layers participating in raycasts by default.";
        
#endif
    }
}