using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(LayerMask))]
    public sealed class Physics2DDefaultRaycastLayersValue : Variable<LayerMask>
    {
        public override string Name => "Physics2D Default Raycast Layers";
        public override LayerMask Value => Physics2D.DefaultRaycastLayers;
        public override bool IsConstant => true;
        
#if UNITY_EDITOR
        public override string Description => "Layer mask constant that includes all layers participating in raycasts by default.";
        
#endif
    }
}