using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHitVariable), typeof(Transform), "transform", false)]
    public class RaycastHitTransformVariable : BaseVariableProperty<RaycastHit, Transform>
    {
        public override string PropertyName => "transform";
        
#if UNITY_EDITOR
        public override string Description => "The Transform of the rigidbody or collider that was hit.";
#endif

        public override Transform Value
        {
            get => (Target as RaycastHitVariable)?.Value.transform;
            set { }
        }
    }
}