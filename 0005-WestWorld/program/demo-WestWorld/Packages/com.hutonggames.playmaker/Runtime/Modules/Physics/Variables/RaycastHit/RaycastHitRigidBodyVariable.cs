using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHitVariable), typeof(Rigidbody), "rigidbody", false)]
    public class RaycastHitRigidBodyVariable : BaseVariableProperty<RaycastHit, Rigidbody>
    {
        public override string PropertyName => "rigidbody";
        
#if UNITY_EDITOR
        public override string Description => "The Rigidbody of the collider that was hit. " +
                                              "If the collider is not attached to a rigidbody then it is null.";
#endif
        
        public override Rigidbody Value
        {
            get
            {
                var raycast =  (Target as RaycastHitVariable)?.Value;
                return raycast?.rigidbody;
            }
        }
    }
}
