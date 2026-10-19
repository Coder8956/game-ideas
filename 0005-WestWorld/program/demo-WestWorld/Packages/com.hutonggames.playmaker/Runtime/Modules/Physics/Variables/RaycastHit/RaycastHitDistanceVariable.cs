using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHitVariable), typeof(float), "distance", false)]
    public class RaycastHitDistanceVariable : BaseVariableProperty<RaycastHit, float>
    {
        public override string PropertyName => "distance";
        
#if UNITY_EDITOR
        public override string Description => "The distance from the ray's origin to the impact point.";
#endif

        public override float Value
        {
            get => (Target as RaycastHitVariable)?.Value.distance ?? 0;
            set { }
        }
    }
}