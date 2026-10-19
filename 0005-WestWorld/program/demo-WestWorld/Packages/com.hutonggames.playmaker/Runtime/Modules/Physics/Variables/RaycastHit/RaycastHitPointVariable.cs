using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHitVariable), typeof(Vector3), "point", false)]
    public class RaycastHitPointVariable : BaseVariableProperty<RaycastHit, Vector3>
    {
        public override string PropertyName => "point";
        
#if UNITY_EDITOR
        public override string Description => "The impact point in world space where the ray hit the collider.";
#endif

        public override Vector3 Value
        {
            get => (Target as RaycastHitVariable)?.Value.point ?? Vector3.zero;
            set { }
        }
    }
}