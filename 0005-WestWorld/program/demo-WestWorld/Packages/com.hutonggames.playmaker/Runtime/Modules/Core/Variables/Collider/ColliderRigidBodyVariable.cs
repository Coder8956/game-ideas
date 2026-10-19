using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(ColliderVariable), typeof(Rigidbody), "attachedRigidbody", false)]
    public class ColliderRigidBodyVariable : BaseVariableProperty<Collider, Rigidbody>
    {
        public override string PropertyName => "attachedRigidbody";
        
#if UNITY_EDITOR
        public override string Description => "The Rigidbody attached to the Collider.";
#endif
        
        public override Rigidbody Value
        {
            get
            {
                var collider =  ((Variable<Collider>)Target)?.Value;
                return collider ? collider.attachedRigidbody : null;
            }
        }
    }
}
