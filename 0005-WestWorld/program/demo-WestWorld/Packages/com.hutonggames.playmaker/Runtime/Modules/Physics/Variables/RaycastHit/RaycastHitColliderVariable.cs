using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHitVariable), typeof(Collider), "collider", false)]
    public class RaycastHitColliderVariable : BaseVariableProperty<RaycastHit, Collider>
    {
        public override string PropertyName => "collider";
        
#if UNITY_EDITOR
        public override string Description => "The Collider that was hit.";
#endif

        public override Collider Value
        {
            get => (Target as RaycastHitVariable)?.Value.collider;
            set { }
        }
    }
}