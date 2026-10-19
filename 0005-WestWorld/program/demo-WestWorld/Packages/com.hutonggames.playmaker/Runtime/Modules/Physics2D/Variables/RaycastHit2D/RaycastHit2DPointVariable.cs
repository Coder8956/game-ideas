using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHit2DVariable), typeof(Vector2), "point", false)]
    public class RaycastHit2DPointVariable : BaseVariableProperty<RaycastHit2D, Vector2>
    {
        public override string PropertyName => "point";
        
#if UNITY_EDITOR
        public override string Description => "The point in world space where the ray hit the collider's surface.";
#endif

        public override Vector2 Value
        {
            get => TargetAs<RaycastHit2DVariable>()?.Value.point ?? Vector2.zero;
            set { }
        }
    }
}
