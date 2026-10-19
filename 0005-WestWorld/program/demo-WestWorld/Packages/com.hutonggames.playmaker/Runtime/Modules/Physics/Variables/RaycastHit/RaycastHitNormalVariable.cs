using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHitVariable), typeof(Vector3), "normal", false)]
    public class RaycastHitNormalVariable : BaseVariableProperty<RaycastHit, Vector3>
    {
        public override string PropertyName => "normal";
        
#if UNITY_EDITOR
        public override string Description => "The normal of the surface the ray hit.";
#endif

        public override Vector3 Value
        {
            get => (Target as RaycastHitVariable)?.Value.normal ?? Vector3.zero;
            set { }
        }
    }
}