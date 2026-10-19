using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHit2DVariable), typeof(float), "distance", false)]
    public class RaycastHit2DDistanceVariable : BaseVariableProperty<RaycastHit2D, float>
    {
        public override string PropertyName => "distance";
        
#if UNITY_EDITOR
        public override string Description => "The distance from the ray origin to the impact point.";
#endif

        public override float Value
        {
            get => TargetAs<RaycastHit2DVariable>()?.Value.distance ?? 0;
            set { }
        }
    }
}
