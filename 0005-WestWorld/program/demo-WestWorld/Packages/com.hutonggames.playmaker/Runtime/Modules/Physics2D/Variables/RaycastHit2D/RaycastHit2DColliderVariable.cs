using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHit2DVariable), typeof(Collider2D), "collider", false)]
    public class RaycastHit2DColliderVariable : BaseVariableProperty<RaycastHit2D, Collider2D>
    {
        public override string PropertyName => "collider";
        
#if UNITY_EDITOR
        public override string Description => "The collider hit by the ray.";
#endif

        public override Collider2D Value
        {
            get => TargetAs<RaycastHit2DVariable>()?.Value.collider;
            set { }
        }
    }
}
