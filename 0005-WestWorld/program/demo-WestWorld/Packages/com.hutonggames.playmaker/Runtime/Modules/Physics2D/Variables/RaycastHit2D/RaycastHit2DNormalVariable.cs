using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHit2DVariable), typeof(Vector2), "normal", false)]
    public class RaycastHit2DNormalVariable : BaseVariableProperty<RaycastHit2D, Vector2>
    {
        public override string PropertyName => "normal";
        
#if UNITY_EDITOR
        public override string Description => "The normal vector of the surface hit by the ray.";
#endif

        public override Vector2 Value
        {
            get => TargetAs<RaycastHit2DVariable>()?.Value.normal ?? Vector2.zero;
            set { }
        }
    }
}
