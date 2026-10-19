using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Collider2DVariable), typeof(Rigidbody2D), "attachedRigidbody", false)]
    public class Collider2DRigidBody2DVariable : BaseVariableProperty<Collider2D, Rigidbody2D>
    {
        public override string PropertyName => "attachedRigidbody";
        
#if UNITY_EDITOR
        public override string Description => "The Rigidbody2D attached to the Collider2D.";
#endif
        
        public override Rigidbody2D Value
        {
            get
            {
                var collider =  ((Variable<Collider2D>)Target)?.Value;
                return collider ? collider.attachedRigidbody : null;
            }
        }
    }
}
