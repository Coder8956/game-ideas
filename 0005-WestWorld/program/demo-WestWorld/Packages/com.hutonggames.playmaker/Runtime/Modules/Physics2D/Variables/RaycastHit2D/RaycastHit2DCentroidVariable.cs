using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHit2DVariable), typeof(Vector2), "centroid", false)]
    public class RaycastHit2DCentroidVariable : BaseVariableProperty<RaycastHit2D, Vector2>
    {
        public override string PropertyName => "centroid";
        
#if UNITY_EDITOR
        public override string Description => "The centroid of the primitive used to perform the cast.";
#endif

        public override Vector2 Value
        {
            get => TargetAs<RaycastHit2DVariable>()?.Value.centroid ?? Vector2.zero;
            set { }
        }
    }
}
