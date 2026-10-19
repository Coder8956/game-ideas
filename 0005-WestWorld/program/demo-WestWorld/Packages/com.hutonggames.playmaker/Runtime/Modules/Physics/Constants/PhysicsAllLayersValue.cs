using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(LayerMask))]
    public sealed class PhysicsAllLayersValue : Variable<LayerMask>
    {
        public override string Name => "Physics All Layers";
        public override LayerMask Value => Physics.AllLayers;
        public override bool IsConstant => true;
        
#if UNITY_EDITOR
        public override string Description => "Layer mask constant that includes all layers.";
        
#endif
    }
}